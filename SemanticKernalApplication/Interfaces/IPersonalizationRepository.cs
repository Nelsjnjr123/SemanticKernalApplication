using SemanticKernalApplication.WebAPI.Models;
using SemanticKernalApplication.WebAPI.Models.CDP;
using Newtonsoft.Json.Linq;

namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface IPersonalizationRepository
    {
        Task<ApiResponseModel<BaseAPIResponse>> GetBrowserIdAsync();
        Task<CDP_GuestDetails> GetGuestDetailsAsync(CDP_DataExtensionRequestBaseModel model);
        Task<ApiResponseModel<BaseAPIResponse>> TriggerEventAsync<T>(T model,string browserId);

        /// <summary>
        /// This method is used to create/update the data extensions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ApiResponseModel<BaseAPIResponse>> TriggerDataExtensionsAsync(CDP_CreateDataExtensionRequestModel model);
    }
}
