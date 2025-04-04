using SemanticKernalApplication.Core;
using SemanticKernalApplication.WebAPI.Helpers;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;
using SemanticKernalApplication.WebAPI.Models.CDP;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using static SemanticKernalApplication.Core.Constants;

namespace SemanticKernalApplication.WebAPI.Respositories
{
    /// <summary>
    /// Personalization and Tracking
    /// </summary>
    public class PersonalizationRepository : IPersonalizationRepository
    {
        #region variable    
        private readonly IConfiguration _configuration;
        private readonly IOptions<SemanticKernalApplicationSettings> _options;
        private readonly ILogger<PersonalizationRepository> _logger;
        private readonly IAPIWrapper _wrapper;
        #endregion

        #region constructor

        public PersonalizationRepository(IOptions<SemanticKernalApplicationSettings> options, ILogger<PersonalizationRepository> logger, IConfiguration configuration, IAPIWrapper wrapper)
        {
            _options = options;
            _logger = logger;
            _configuration = configuration;
            _wrapper = wrapper;
        }
        #endregion

        #region public method(s)
        /// <summary>
        /// Generating browserid for the user in cdp
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponseModel<BaseAPIResponse>> GetBrowserIdAsync()
        {
            BaseAPIResponse baseResponse = new BaseAPIResponse()
            {
                Results = new List<object>()
            };

            ApiResponseModel<BaseAPIResponse> response = new ApiResponseModel<BaseAPIResponse>();

            var clientKey = (bool)_options?.Value?.EnableKeyVault ? _configuration[_options.Value?.CDPSettings.ClientKey] : _options.Value?.CDPSettings.ClientKey;
            var result = await _wrapper.GetAsync<CDP_ResponseModel>(String.Format($"{_options.Value?.CDPSettings.BaseUrl}{_options.Value?.CDPSettings.GetBrowserIdUrl}", clientKey));
            if (result != null && result.IsSuccess && result.Data.Status == System.Net.HttpStatusCode.OK.ToString())
            {
                CDP_ApiResponseModel responseModel = new CDP_ApiResponseModel()
                {
                    BrowserId = result.Data.Ref,
                    CustomerId = result.Data.Customer_ref
                };
                baseResponse.Results = responseModel;
                response.Data = baseResponse;
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = true;
                response.Message = Constants.BrowserIdCreated;
                return CommonUtility.GenerateResponse(response);
            }
            else
            {
                response.Data = new BaseAPIResponse();
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.Message = Constants.CreateBrowserIdFailed;
                return CommonUtility.GenerateResponse(response, true);
            }
        }

        public async Task<CDP_GuestDetails> GetGuestDetailsAsync(CDP_DataExtensionRequestBaseModel model)
        {
            var request = new CDP_CallFlowsModel()
            {
                channel = model.ChannelName,
                clientKey = (bool)_options?.Value?.EnableKeyVault ? _configuration?[_options.Value?.CDPSettings.ClientKey] : _options.Value?.CDPSettings.ClientKey,
                friendlyId = Constants.FriendlyId_GetGuestId,
                pointOfSale = _options.Value?.CDPSettings.Pos,
                browserId = model.BrowserId,
            };
            string url = String.Format($"{_options.Value?.CDPSettings.BaseUrl}{_options.Value?.CDPSettings.CallFlowsUrl}");
            var result = await _wrapper.PostAsync<CDP_GuestDetails, CDP_CallFlowsModel>(url, body: request);
            if (result != null && result.IsSuccess && result.Data != null && !string.IsNullOrEmpty(result.Data.GuestRef))
            {
                return result.Data;
            }

            return new CDP_GuestDetails();
        }


        /// <summary>
        /// Triggering different types event for the user like Page view,identity,order checkout ,custom events etc
        /// </summary>
        /// <param name="model"></param>
        /// <param name="browserId"></param>
        /// <returns></returns>        
        public async Task<ApiResponseModel<BaseAPIResponse>> TriggerEventAsync<T>(T model, string browserId)
        {
            BaseAPIResponse baseResponse = new BaseAPIResponse()
            {
                Results = new List<object>()
            };
            ApiResponseModel<BaseAPIResponse> response = new ApiResponseModel<BaseAPIResponse>();
            if (!String.IsNullOrEmpty(browserId))
            {
                JsonSerializerSettings option = new()
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                var dataModel = JsonConvert.SerializeObject(model, option);
                var clientKey = (bool)_options?.Value?.EnableKeyVault ? _configuration?[_options.Value?.CDPSettings.ClientKey] : _options.Value?.CDPSettings.ClientKey;
                string url = String.Format($"{_options.Value?.CDPSettings.BaseUrl}{_options.Value?.CDPSettings.EventUrl}", clientKey, dataModel);
                var result = await _wrapper.GetAsync<CDP_ResponseModel>(url, headers: GetAuthenticationHeader(), authenticationType: Constants.Basic);
                if (result != null && result.IsSuccess && result.Data.Status == System.Net.HttpStatusCode.OK.ToString())
                {
                    var data = new CDP_ApiResponseModel()
                    {
                        Reference = result.Data.Ref
                    };
                    baseResponse.Results = data;
                    response.Data = baseResponse;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    response.IsSuccess = true;
                    response.Message = Constants.EventsCreated;
                    return CommonUtility.GenerateResponse(response);
                }
                else
                {
                    response.Data = new BaseAPIResponse();
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.Message = Constants.EventsCreationFailed;
                    return CommonUtility.GenerateResponse(response, true);
                }
            }
            response.Data = new BaseAPIResponse();
            response.StatusCode = System.Net.HttpStatusCode.NotFound;
            response.IsSuccess = false;
            response.Message = Constants.EventsCreationFailed;
            return CommonUtility.GenerateResponse(response, true);
        }
        /// <summary>
        /// This method is used to create/update the data extensions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponseModel<BaseAPIResponse>> TriggerDataExtensionsAsync(CDP_CreateDataExtensionRequestModel model)
        {
            ApiResponseModel<BaseAPIResponse> response = new ApiResponseModel<BaseAPIResponse>()
            {
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Message = Constants.HttpStatusCode400,
                Data = new BaseAPIResponse()
            };
            try
            {
                if (_options.Value.CDPSettings.EnableCDP)
                {
                    if (!(model.DataExtensionAttributes != null && model.DataExtensionAttributes.Any()))
                    {
                        _logger.LogError($"Error in PersonalizationRepository.TriggerCreateDataExtensionsAsync. empty data extensions: {model?.BrowserId}");
                        return response;
                    }

                    var duplicateKeys = model.DataExtensionAttributes.GroupBy(x => x.Key).Where(y => y.Count() > 1).Select(z => z.Key);
                    if (duplicateKeys != null && duplicateKeys.Count() > 0)
                    {
                        response.Message = Constants.DuplicateEntriesMessage;
                        _logger.LogError($"Error in PersonalizationRepository.TriggerCreateDataExtensionsAsync.Duplicate data extensions: {model?.BrowserId}");
                        return response;
                    }
                    // Get guest reference Id
                    var dataExtensionRequestBaseModel = new CDP_DataExtensionRequestBaseModel
                    {
                        ChannelName = model.ChannelName,
                        BrowserId = model.BrowserId,
                    };
                    var guestDetails = await GetGuestDetailsAsync(dataExtensionRequestBaseModel);

                    if (string.IsNullOrEmpty(guestDetails.GuestRef))
                    {
                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
                        response.Message = Constants.UserNotFound;
                        _logger.LogError($"Error in PersonalizationRepository.TriggerCreateDataExtensionsAsync.Guest Ref not found for browserId: {model?.BrowserId}");
                        return response;
                    }
                    //Note: The Data Extension Name should start with "ext"
                    var dataExtensionName = model.DataExtensionName;
                    if (model.DataExtensionName.ToLower().StartsWith(Constants.ExtensionName))
                    {
                        dataExtensionName = model.DataExtensionName.Substring(3);
                    }
                    if (!Enum.IsDefined(typeof(CDP_DataExtensionNames), dataExtensionName))
                    {
                        _logger.LogError($"Error in PersonalizationRepository.TriggerCreateDataExtensionsAsync. data extensions enum is not allowed: {dataExtensionName} for  {model?.BrowserId}");
                        return response;
                    }

                    dynamic request = new System.Dynamic.ExpandoObject();
                    request.key = Constants.ExtensionKey;
                    foreach (var dataExtension in model.DataExtensionAttributes)
                    {
                        if (dataExtension?.Value == null)
                            continue;
                        dynamic value = dataExtension?.Value;
                        try
                        {
                            //Directly coming from the model
                            if (dataExtension?.Value is int intData)
                            {
                                value = intData;
                            }
                            else if (dataExtension?.Value is string stringData)
                            {
                                value = stringData;
                            }
                            else if (dataExtension?.Value is bool boolData)
                            {
                                value = boolData;
                            }
                            else
                            {
                                //This is coming as JSON from request
                                switch (((System.Text.Json.JsonElement)((object)dataExtension?.Value)).ValueKind)
                                {
                                    case System.Text.Json.JsonValueKind.Number:
                                        value = Convert.ToInt32(dataExtension?.Value.ToString());
                                        break;
                                    case System.Text.Json.JsonValueKind.String:
                                        value = dataExtension?.Value.ToString();
                                        break;
                                    case System.Text.Json.JsonValueKind.True:
                                        value = Convert.ToBoolean(dataExtension?.Value.ToString());
                                        break;
                                    case System.Text.Json.JsonValueKind.False:
                                        value = Convert.ToBoolean(dataExtension?.Value.ToString());
                                        break;
                                }
                            }
                        }
                        catch
                        {
                            value = dataExtension?.Value;
                        }
                        CommonUtility.AddComponentSection(request, dataExtension.Key, value);
                    }

                    var body = JsonConvert.DeserializeObject<object>(JsonConvert.SerializeObject(request));
                    string url = String.Format($"{_options.Value?.CDPSettings.BaseUrl}{_options.Value?.CDPSettings.CreateDataExtensionsUrl}", guestDetails.GuestRef, $"{Constants.ExtensionName}{dataExtensionName}");
                    var result = await _wrapper.PostAsync<BaseAPIResponse, dynamic>(url, body, headers: GetAuthenticationHeader(), authenticationType: Constants.Basic);
                    if (result != null && result.IsSuccess)
                    {
                        response.IsSuccess = true;
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                        response.Message = Constants.DataExtensionsCreated;
                        response.Data = result.Data;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        response.Message = Constants.DataExtensionsCreationFailed;
                        response.Data = result.Data;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in PersonalizationRepository.TriggerCreateDataExtensionsAsync. Error Message: {ex.Message}", ex);
                response.IsSuccess = false;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Message = Constants.HttpStatusCode500;
            }

            return response;
        }
        #endregion

        #region private method(s)
        private Dictionary<string, string> GetAuthenticationHeader()
        {
            var clientKey = (bool)_options?.Value?.EnableKeyVault ? _configuration?[_options.Value?.CDPSettings.ClientKey] : _options.Value?.CDPSettings.ClientKey;
            var apiToken = (bool)_options?.Value?.EnableKeyVault ? _configuration?[_options.Value?.CDPSettings.ApiToken] : _options.Value?.CDPSettings.ApiToken;

            //Basic Authentication
            var authenticationString = $"{clientKey}:{apiToken}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
            var authenticationHeader = new Dictionary<string, string>()
            {
                [Core.Constants.HeaderName] = base64EncodedAuthenticationString
            };

            return authenticationHeader;
        }
        #endregion
    }


}
