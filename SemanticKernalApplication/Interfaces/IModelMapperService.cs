using SemanticKernalApplication.WebAPI.Models;

using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;
using Newtonsoft.Json.Linq;

namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface IModelMapperService
    {
        Task<object> BuildModel<T>(PlaceholderComponents placeholderComponent=null,string componentName=null,RequestModel model=null, JToken fieldsData = null, string requestTemplateId = null,string pageUrl="",string headerVariant="", BuildModelParameter buildModelParameter=null);
        Task<object> GetSitecoreLayoutComponents(RequestModel model,bool isRecacheRequired = false);
      
    
    }
}