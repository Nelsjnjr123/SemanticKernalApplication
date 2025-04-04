using Newtonsoft.Json.Linq;

namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface ICommonHelper
  {
    
    /// <summary>
    /// Method is used to get context item detail
    /// </summary>
    /// <param name="language">string</param>
    /// <param name="path">string</param>
    /// <param name="graphQuery">string</param>
    /// <param name="templateId">string</param>
    /// <param name="paginationCusor">string</param>
    /// <param name="pagesize">string</param>
    /// <param name="requestMethodName">string</param>
    /// <returns>Task<JToken></returns>
    Task<JToken> GetSitecoreItemDetail(string language, string path = "", string graphQuery = "", string templateId = "", string paginationCusor = "", int pagesize = 10, string requestMethodName = "");
  }
}
