using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace SemanticKernalApplication.WebAPI.Wrapper
{
    /// <summary>
    /// A generic wrapper class to REST API calls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class APIWrapper : IAPIWrapper
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<APIWrapper> _logger;
       
        public APIWrapper(IHttpClientFactory clientFactory, ILogger<APIWrapper> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        
        }
        /// <summary>
        /// Executing the API call to GET the resource from the Server
        /// </summary>
        /// <param name="url">Resource locator URL</param>
        /// <param name="contentType">Request Content type(Json / XML)</param>
        /// <param name="headers">Request Header</param>
        /// <param name="authenticationType">Bearer / Basic etc</param>
        /// <returns>Response</returns>
        public async Task<ApiResponseModel<T>> GetAsync<T>([Required] string url, string contentType = "application/json", IDictionary<string, string> headers = null, string authenticationType = Constants.Bearer)
        {
            ApiResponseModel<T>? result = null;
            var httpClient = _clientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Setting content type.  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (header.Key == Constants.HeaderName)
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationType, header.Value);
                    else
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            HttpResponseMessage response = await httpClient.GetAsync(new Uri(url), HttpCompletionOption.ResponseHeadersRead);
            result = await ProcessResponse<T>(response);
            
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="contentType"></param>
        /// <param name="headers"></param>
        /// <param name="content"></param>
        /// <param name="httpMethod"></param>
        /// <param name="authenticationType">Bearer / Basic etc</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<ApiResponseModel<T>> SendAsync<T>([Required] string url, string contentType = "application/json", IDictionary<string, string> headers = null, HttpContent content = null, HttpMethod httpMethod = null, string authenticationType = Constants.Bearer, CancellationToken ct = default)
        {
            ApiResponseModel<T> result = new ApiResponseModel<T>();
            var httpClient = _clientFactory.CreateClient();
            if (httpMethod == null)
            {
                httpMethod = HttpMethod.Get;
            }
            var request = new HttpRequestMessage(httpMethod, url);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Setting content type.  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (header.Key == Constants.HeaderName)
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationType, header.Value);
                    else
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            if (content != null)
            {
                request.Content = content;
            }
            try
            {
                HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);
                result = await ProcessResponse<T>(response);
               
            }
            catch (Exception ex)
            {
                var errors = new List<ApiResponseErrorModel>
                {
                    new ApiResponseErrorModel(HttpStatusCode.InternalServerError.ToString(),ex.Message)
                };
                _logger.LogError($"{url} ============{ex.Message}");
                result.Errors = errors;
                result.IsSuccess = false;

            }
            return result;
        }

        /// <summary>
        /// Executing the API call to POST the resource to the Server
        /// </summary>
        /// <param name="url">Resource locator URL</param>
        /// <param name="body">Data passed to be passed to the API</param>
        /// <param name="contentType">Request Content type(Json / XML)</param>
        /// <param name="headers">Request Headers</param>
        /// <param name="authenticationType">Bearer / Basic etc</param>
        /// <returns>Response</returns>
        public async Task<ApiResponseModel<T>> PostAsync<T, U>([Required] string url, U body, string contentType = "application/json", IDictionary<string, string> headers = null, string authenticationType = Constants.Bearer) where U : class
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return await SendAsync<T>(url, contentType: contentType, content: content, headers: headers, httpMethod: HttpMethod.Post, authenticationType: authenticationType).ConfigureAwait(false);
        }

        /// <summary>
        /// Executing the API call to POST the resource to the Server
        /// </summary>
        /// <param name="url">Resource locator URL</param>
        /// <param name="stringContent">Data passed to be passed to the API</param>
        /// <param name="headers">Request Headers</param>
        /// <param name="authenticationType">Bearer / Basic etc</param>
        /// <returns>Response</returns>
        public async Task<ApiResponseModel<T>> PostAsync<T>([Required] string url, StringContent stringContent, IDictionary<string, string> headers = null, string authenticationType = Constants.Bearer)
        {
            return await SendAsync<T>(url, content: stringContent, headers: headers, httpMethod: HttpMethod.Post, authenticationType: authenticationType).ConfigureAwait(false);
        }

        /// <summary>
        /// Executing the API call to POST the resource to the Server
        /// </summary>
        /// <param name="url">Resource locator URL</param>
        /// <param name="formcontent">Data passed to be passed to the API</param>
        /// <param name="headers">Request Headers</param>
        /// <param name="authenticationType">Bearer / Basic etc</param>
        /// <returns>Response</returns>
        public async Task<ApiResponseModel<T>> PostAsync<T>([Required] string url, FormUrlEncodedContent formcontent, IDictionary<string, string> headers = null, string authenticationType = Constants.Bearer)
        {
            return await SendAsync<T>(url, content: formcontent, headers: headers, httpMethod: HttpMethod.Post, authenticationType: authenticationType).ConfigureAwait(false);
        }
        /// <summary>
        /// Executing the API call to POST the resource to the Server
        /// </summary>
        /// <param name="url">Resource locator URL</param>
        /// <param name="content">Data passed to be passed to the API</param>
        /// <param name="headers">Request Headers</param>
        /// <param name="authenticationType">Bearer / Basic etc</param>
        /// <returns>Response</returns>
        public async Task<ApiResponseModel<T>> PostAsync<T>([Required] string url, MultipartFormDataContent content, IDictionary<string, string> headers = null, string authenticationType = Constants.Bearer)
        {
            return await SendAsync<T>(url, content: content, headers: headers, httpMethod: HttpMethod.Post, authenticationType: authenticationType).ConfigureAwait(false);
        }
        /// <summary>
        /// Executing the API call to update(PUT) the resource to the Server
        /// </summary>
        /// <param name="url">Resource locator URL</param>
        /// <param name="body">Data passed to be passed to the API</param>
        /// <param name="headers">Request Headers</param>
        /// <param name="authenticationType">Bearer / Basic etc</param>
        /// <returns>Response</returns>
        public async Task<ApiResponseModel<T>> PutAsync<T>([Required] string url, T body, IDictionary<string, string> headers = null, string authenticationType = Constants.Bearer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return await SendAsync<T>(url, content: content, headers: headers, httpMethod: HttpMethod.Put, authenticationType: authenticationType).ConfigureAwait(false);
        }
        /// <summary>
        /// Executing the API call to Delete(DELETE) the resource from the Server
        /// </summary>
        /// <param name="url">Resource locator URL</param>
        /// <param name="headers">Request Headers</param>
        /// <param name="authenticationType">Bearer / Basic etc</param>
        /// <returns>Response</returns>
        public async Task<ApiResponseModel<T>> DeleteAsync<T>([Required] string url, IDictionary<string, string> headers = null, string authenticationType = Constants.Bearer)
        {
            ApiResponseModel<T>? result = null;
            var httpClient = _clientFactory.CreateClient();
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (header.Key == Constants.HeaderName)
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationType, header.Value);
                    else
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            HttpResponseMessage response = await httpClient.DeleteAsync(url).ConfigureAwait(false);
            result = await ProcessResponse<T>(response);
            
            return result;
        }

        /// <summary>
        /// Processing the response from the server
        /// </summary>
        /// <typeparam name="T">Type of the response from the server </typeparam>
        /// <param name="response">Actual respopnse</param>
        /// <param name="ct">Actual respopnse</param>
        /// <returns>Response</returns>
        /// <exception cref="Exception">Throws any server expection </exception>
        private async Task<ApiResponseModel<T>> ProcessResponse<T>(HttpResponseMessage response, CancellationToken ct = default)
        {

            ApiResponseModel<T> result = new ApiResponseModel<T>();
            if (response.IsSuccessStatusCode)
            {
                using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var reader = new StreamReader(stream))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    try
                    {
                        result.Data = serializer.Deserialize<T>(jsonReader);
                        result.IsSuccess = true;
                        result.StatusCode = response.StatusCode;
                    }
                    catch (Exception ex)
                    {
                        var errors = new List<ApiResponseErrorModel>
                        {
                            new ApiResponseErrorModel(response.StatusCode.ToString(),ex.Message)
                        };
                        result.StatusCode = response.StatusCode;
                        result.Errors = errors;
                        result.IsSuccess = false;
                        _logger.LogError(ex.Message);
                    }
                }
                return result;
            }
            else
            {
                if (response.StatusCode.Equals(HttpStatusCode.GatewayTimeout))
                {
                    _logger.LogError("API Gateway Timeout");
                    throw new Exception("API Gateway Timeout");
                }
                else if (response.StatusCode.Equals(HttpStatusCode.BadRequest) ||
                    response.StatusCode.Equals(HttpStatusCode.InternalServerError) ||
                    response.StatusCode.Equals(HttpStatusCode.NotFound) ||
                    response.StatusCode.Equals(HttpStatusCode.ServiceUnavailable))
                {
                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        _logger.LogError($"Error occured in the Request, Error details from api : {x?.Result} ");
                        if (x.IsFaulted)
                        {
                            var errors = new List<ApiResponseErrorModel>
                            {
                                new ApiResponseErrorModel(response.StatusCode.ToString(),x.Exception.Message)
                            };
                            _logger.LogError(x.Exception.Message);
                            result.Errors = errors;
                        }

                    });
                    result.StatusCode = response.StatusCode;
                    result.IsSuccess = false;
                    return result;
                }
                else
                {
                    var errors = new List<ApiResponseErrorModel>
                    {
                         new ApiResponseErrorModel(response.StatusCode.ToString(),Constants.Exception)
                    };
                    _logger.LogError($"{response.StatusCode.ToString()} {Constants.Exception}");
                    result.Errors = errors;
                    result.StatusCode = response.StatusCode;
                    return result;
                }
            }
        }
    }
}



