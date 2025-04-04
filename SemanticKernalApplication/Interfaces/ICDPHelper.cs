using SemanticKernalApplication.WebAPI.Models;
using SemanticKernalApplication.WebAPI.Models.CDP;


using Newtonsoft.Json.Linq;
using System.Collections.Specialized;

namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface ICDPHelper
    {
        Task<ApiResponseModel<CDP_ApiResponseModel>> GetBrowserIdAsync();
        Task<ApiResponseModel<CDP_ApiResponseModel>> IdentitfyUserAsync(CDP_EventModel model);
        Task<ApiResponseModel<CDP_ApiResponseModel>> TriggerEventAsync(CDPBase model);
        Task<ApiResponseModel<CDP_ApiResponseModel>> OrderCheckoutAsync(CDP_Order_Checkout model);
    }
}