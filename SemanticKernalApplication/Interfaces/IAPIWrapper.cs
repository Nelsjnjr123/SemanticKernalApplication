using SemanticKernalApplication.WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface IAPIWrapper
    {
        Task<ApiResponseModel<T>> DeleteAsync<T>([Required] string url, IDictionary<string, string> headers = null, string authenticationType = "Bearer");
        Task<ApiResponseModel<T>> GetAsync<T>([Required] string url, string contentType = "application/json", IDictionary<string, string> headers = null, string authenticationType = "Bearer");
        Task<ApiResponseModel<T>> PostAsync<T>([Required] string url, FormUrlEncodedContent formcontent, IDictionary<string, string> headers = null, string authenticationType = "Bearer");
        Task<ApiResponseModel<T>> PostAsync<T>([Required] string url, MultipartFormDataContent content, IDictionary<string, string> headers = null, string authenticationType = "Bearer");
        Task<ApiResponseModel<T>> PostAsync<T>([Required] string url, StringContent content, IDictionary<string, string> headers = null, string authenticationType = "Bearer");
        Task<ApiResponseModel<T>> PostAsync<T, U>([Required] string url, U body, string contentType = "application/json", IDictionary<string, string> headers = null, string authenticationType = "Bearer") where U : class;
        Task<ApiResponseModel<T>> PutAsync<T>([Required] string url, T body, IDictionary<string, string> headers = null, string authenticationType = "Bearer");
        Task<ApiResponseModel<T>> SendAsync<T>([Required] string url, string contentType = "application/json", IDictionary<string, string> headers = null, HttpContent content = null, HttpMethod httpMethod = null, string authenticationType = "Bearer", CancellationToken ct = default);
    }
}