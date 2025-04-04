using SemanticKernalApplication.Core;
using SemanticKernalApplication.Core.Models;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;
using Newtonsoft.Json.Linq;
using System.Text;

namespace SemanticKernalApplication.WebAPI.Helpers
{
    public class CommonHelper : ICommonHelper
  {
    #region variable                      
    private readonly ILogger<CommonHelper> _logger;

    IGraphQLService _graphQLService;
    #endregion

    #region constructor
    public CommonHelper(ILogger<CommonHelper> logger, IGraphQLService graphQLService)
    {
      _logger = logger;

      _graphQLService = graphQLService;
    }
    #endregion

    
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
    public async Task<JToken> GetSitecoreItemDetail(string language, string path = "", string graphQuery = "", string templateId = "", string paginationCusor = "", int pagesize = 10, string requestMethodName = "")
    {
      var graphQLQueryVariable = new GraphQLQueryVariable()
      {
        sitename = Constants.SiteName,
        language = language
      };
      graphQuery = !String.IsNullOrEmpty(graphQuery) ? graphQuery : Constants.GraphQlQueries.GetItemLayout;

      graphQLQueryVariable.path = path;

      if (!string.IsNullOrWhiteSpace(templateId))
        graphQLQueryVariable.templates = templateId;

      graphQLQueryVariable.cursor = paginationCusor == null ? "" : paginationCusor;
      graphQLQueryVariable.pagesize = pagesize;
      JToken result;
      result = await _graphQLService.GetResultsAsync<JToken>(graphQuery, graphQLQueryVariable);
      return result;
    }

  }
}
