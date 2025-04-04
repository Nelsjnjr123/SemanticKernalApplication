using SemanticKernalApplication.WebAPI.Models;
using Newtonsoft.Json.Linq;

namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface IGraphQLRepository
    {
        //TODO: This can be optimized to make a layout query by targeting settings page item
        Task<MobileAppConfigResponseModel> GetMobileAppConfigurations();
        Task<MobileAppDictionaryResponseModel> GetMobileAppDictionary();
    }
}