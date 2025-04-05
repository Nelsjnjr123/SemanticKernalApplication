using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using System.Collections;
using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Helpers;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;

namespace SemanticKernalApplication.WebAPI.Respositories
{
    /// <summary>
    /// This repository is to get the Sitecore Publishing data and pushing it to Algolia index
    /// </summary>
    public class HooksRepository : IHooksRepository
    {
        #region variable
        IGraphQLService _graphQLService;
        private readonly ILogger<HooksRepository> _logger;
        private readonly ICacheService _cacheService;
        #endregion
        #region constructor
        public HooksRepository(IGraphQLService graphQLService, ILogger<HooksRepository> logger, ICacheService cacheService)
        {
            _graphQLService = graphQLService;
            _logger = logger;
            _cacheService = cacheService;
        }
        #endregion

        #region public methods
        /// <summary>
        /// This method process the Sitecore publishing hooks details into Algolia
        /// </summary>
        /// <param name="data">Hook data</param>
        /// <returns>bool</returns>
        //public async Task<bool> ProcessHooksEventsAsync(string data)
        //{
        //    ItemPublishModel model = JsonConvert.DeserializeObject<ItemPublishModel>(data);
        //    var datas = model.DataItem.VersionedFields.Where(p => ConstantsKeyValue.ErrorMessages.Values.Contains(p.Id)).ToList();
        //    var search = _searchService.GetResults<Item>(model.DataItem.Id);
        //    try
        //    {
        //        //for processing from graphQl
        //        var searchResultFromGraphql = await _graphQLService.GetResultsAsync<ItemSearchResult>(GenerateQuery(), null);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogInformation("starting ================" + ex.Message);
        //    }

        //    if (search == null)
        //        return false;
        //    switch (ConstantsKeyValue.Templates[model.DataItem.TemplateId])
        //    {
        //        case "ErrorTemplate":
        //            if (search.Hits.Count > 0)
        //                await _searchService.AddOrUpdateIndexAsync<Item>(SetData<Item>(model, datas), true);
        //            else
        //                await _searchService.AddOrUpdateIndexAsync<Item>(SetData<Item>(model, datas), false);
        //            break;
        //        default:
        //            break;
        //    }
        //    return true;
        //}
        /// <summary>
        /// Fetching the data from xmcoud using GraphQL
        /// </summary>
        /// <returns></returns>
        public async Task<bool> FetchGraphQLResultsAsync()
        {
            try
            {
                //for processing from graphQl
                var searchResultFromGraphql = await _graphQLService.GetResultsAsync<ItemSearchResult>(GenerateQuery(), null);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("starting ================" + ex.Message);
            }


            return true;
        }

        public async Task<bool> ProcessClearCacheHookAsync(string data)
        {
            // Dispose can not be used as there will be no re-initialisation of memory object
            //_memoryCache.Dispose();
            _logger.LogInformation("=============Clearing cache ================");
            _cacheService.RemoveAll();

            await Task.CompletedTask;
            return true;
        }

        #endregion
        #region private method
        /// <summary>
        /// Binding data for Algolia index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        private T SetData<T>(ItemPublishModel model, List<ItemFields> datas)
        {
            ItemBaseModel hookData = new ItemBaseModel(
                        model.DataItem.Name,
                        model.DataItem.Id,
                        model.DataItem.TemplateId,
                        model.DataItem.Language,
                        model.DataItem.Version,
                        model.DataItem.Id);
            switch (typeof(T))
            {
                case Type type when type == typeof(Item):
                    Item data = new Item(hookData);
                    foreach (var prop in data.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly))
                    {
                        if (ConstantsKeyValue.ErrorMessages.TryGetValue(prop.Name, out string value))
                        {
                            var item = datas.Where(p => p.Id == value).FirstOrDefault();
                            if (item != null)
                                prop.SetValue(data, item.Value, null);
                        }
                    }

                    return (T)(object)data;
                default:
                    break;
            }
            return default(T);
        }
        /// <summary>
        /// Query for Fetching template item details from xmcloud
        /// </summary>
        /// <returns></returns>
        private string GenerateQuery()
        {

            var query = $@"query {{
              result: search(
                 where: {{
                   AND: [
                    {{
                     name: ""_path""
                     value:""{{AB6EDE68-81E1-42D5-9745-C0A70378648F}}""
                     operator: CONTAINS
                   }}
                     {{
                       name: ""_templates""
                       value: ""{{C3620BD5-2613-43CF-A57A-ACB7EAAAF872}}""
                       operator: CONTAINS
                     }}

                   ]
                 }}
                 # defaults to 10
                 first: 10
               ) {{
                 total
                 pageInfo {{
                   endCursor
                   hasNext
                 }}
                 results {{
                  id,
                  
                  language{{   
                    name                 
                  }}
                  template{{
					id   
                  name}},
                  ...SearchResultsItems
                  path,
                   url {{
                     path
                   }}
                 }}
               }}
             }}
             fragment SearchResultsItems on Item {{
                 fields
                  {{
                    name
                    value
                    id                    
                  }}  
            }}";

            return query;
        }

        #endregion
    }
}


