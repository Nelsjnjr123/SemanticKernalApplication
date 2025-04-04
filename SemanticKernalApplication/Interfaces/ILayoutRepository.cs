using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;
using SemanticKernalApplication.WebAPI.Models;

namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface ILayoutRepository
    {
        Task<object> GetPageComponents(RequestModel model);
      
    }
}
