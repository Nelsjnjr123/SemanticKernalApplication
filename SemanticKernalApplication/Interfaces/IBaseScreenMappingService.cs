using SemanticKernalApplication.WebAPI.Models;

using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;
using Newtonsoft.Json.Linq;

namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface IBaseScreenMappingService
    {
        Task GetSettingsScreenComponents(List<PlaceholderComponents> sitecoreComponents, BaseAppResponse response);
        Task GetHomeScreenComponents(List<PlaceholderComponents> sitecoreComponents, BaseAppResponse response, RequestModel model = null, JToken fieldsData = null,  BuildModelParameter buildModelParameter = null);
       
    }
}