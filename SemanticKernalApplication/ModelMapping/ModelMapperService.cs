using Azure.Core;
using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Helpers;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;

using SemanticKernalApplication.WebAPI.Models.CDP;
using SemanticKernalApplication.WebAPI.Models.Event;

using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;

using Microsoft.Extensions.Options;

using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static SemanticKernalApplication.Core.Constants;

namespace SemanticKernalApplication.WebAPI.ModelMapping
{
    public class ModelMapperService : IModelMapperService
    {
        #region variable      
        string wayFinderUrl { get; set; }
        IGraphQLService _graphQLService;
      
        private readonly ICacheService _cacheService;
        private readonly IOptions<SemanticKernalApplicationSettings> _options;
       
        private readonly ILogger<ModelMapperService> _logger;
        private readonly IAPIWrapper _wrapper;
        private readonly IConfiguration _configuration;
        #endregion
        #region constructor
        public ModelMapperService(IGraphQLService graphQLService, IOptions<SemanticKernalApplicationSettings> options,
            ICacheService cacheService,
            ILogger<ModelMapperService> logger,  IAPIWrapper wrapper, IConfiguration configuration)
        {
            wayFinderUrl = options.Value.WayFinderSettings.WayFinderURL;
            _graphQLService = graphQLService;
           
            _cacheService = cacheService;
            _options = options;
            _logger = logger;
            _configuration = configuration;
            _wrapper = wrapper;
        }
        #endregion
        #region public method(s)
        /// <summary>
        /// Getting the Components from the sitecore layout
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isReCacheRequired"></param>
        /// <returns></returns>
        public async Task<object> GetSitecoreLayoutComponents(RequestModel model, bool isReCacheRequired = false)
        {
            SitecoreLayoutModel sitecoreLayoutModel = new SitecoreLayoutModel();
            JToken results = null;
            JToken mobileResults = null;
           
            var graphQLQueryVariable = new GraphQLQueryVariable();
            if (ScreenName.ProfileSupportPageScreen.Equals(Constants.ScreenName.ProfileSupportPageScreen, StringComparison.InvariantCultureIgnoreCase))
            {
                graphQLQueryVariable = new GraphQLQueryVariable()
                {
                    sitename = "difcwebsite",
                    language = model.Language
                };
            }

            var graphQuery = Constants.GraphQlQueries.GetItemLayout;
            var itemPath = String.Empty;
            if ((!String.IsNullOrEmpty(model.PageType) && (model.PageType.Equals(Constants.Details, StringComparison.InvariantCultureIgnoreCase) ||
                model.PageType.Equals(Constants.Listing, StringComparison.InvariantCultureIgnoreCase) ||
                model.PageType.Equals(Constants.FILTERS, StringComparison.InvariantCultureIgnoreCase))))
            {
                graphQuery = Constants.GraphQlQueries.GetItem;
                itemPath = model.Id;
            }
            else
            {
                //Get the graphql query based on the type of screen name ie) sitecore item 
                switch (model.ScreenName.ToLower())
                {

                    case ScreenName.SettingsPageScreen:
                        graphQuery = Constants.GraphQlQueries.GetItem;
                        itemPath = SETTINGS_PATH;
                        break;
                    case ScreenName.HomePageScreen:
                        // graphQuery = Constants.GraphQlQueries.GetItem;
                        if (!string.IsNullOrEmpty(model.Personna))
                        {
                            itemPath = model.Personna.ToLower() switch
                            {
                                VISITOR => VISITOR_HOME_PATH,
                                EMPLOYEE => EMPLOYEE_HOME_PATH,
                                GUEST => GUEST_HOME_PATH,
                                STUDENT => ACADAMY_HOME_PATH,
                                _ => ""
                            };
                        }
                        break;
                  
                    default:
                        break;
                }
            }

      

            if (ScreenName.ProfileSupportPageScreen.Equals(Constants.ScreenName.ProfileSupportPageScreen, StringComparison.InvariantCultureIgnoreCase))
            {
                graphQLQueryVariable.path = itemPath;
                mobileResults = await _graphQLService.GetResultsAsync<JToken>(graphQuery, graphQLQueryVariable,true);
                //Filtering the components from headless-main placeholder
                var mobileMainPlaceholders = mobileResults?.SelectToken(Constants.HeadlessLayoutMobilePlacholderXPath);
                if (mobileMainPlaceholders == null)   // Fallback Check
                {
                    mobileMainPlaceholders = mobileResults?.SelectToken(Constants.HeadlessMobilePlacholderXPath);
                }
                sitecoreLayoutModel.MobilePlaceholderData = mobileMainPlaceholders;
            }
            graphQLQueryVariable = new GraphQLQueryVariable()
            {
                sitename = SiteName,
                language = model.Language
            };
            graphQLQueryVariable.path = itemPath;
            results = await _graphQLService.GetResultsAsync<JToken>(graphQuery, graphQLQueryVariable);
            //Filtering the components from headless-main placeholder
            var mainPlaceholders = results?.SelectToken(Constants.HeadlessLayoutMobilePlacholderXPath);
            if (mainPlaceholders == null)   // Fallback Check
            {
                mainPlaceholders = results?.SelectToken(Constants.HeadlessMobilePlacholderXPath);
            }
            sitecoreLayoutModel.PlaceholderData = mainPlaceholders;

            //Fetching context Items Fields
            var fieldData = results?.SelectToken(Constants.HeadlessItemFieldXPath);
            if (fieldData == null)   // Fallback Check
            {
                fieldData = results?.SelectToken(Constants.HeadlessLayoutFieldXPath);
            }
            sitecoreLayoutModel.FieldData = fieldData;
            var templateId = results?.SelectToken(Constants.TemplateIdFieldXPath)?.ToObject<string>();
            sitecoreLayoutModel.TemplateId = templateId;
            var pageUrl = results?.SelectToken(Constants.ItemPageUrlXPath)?.ToObject<string>();
            sitecoreLayoutModel.PageUrl = pageUrl ?? String.Empty;

            return sitecoreLayoutModel;
        }

        /// <summary>
        /// Get Sitecore Item Details
        /// </summary>
        /// <param name="model"></param>
        /// 
        /// <param name="path"></param>
        /// <param name="graphQuery"></param>
        /// <param name="templateId"></param>
        /// <param name="paginationCusor"></param>
        /// <param name="pagesize"></param>
        /// <param name="requestMethodName"></param>
        /// <returns></returns>
        public async Task<JToken> GetSitecoreItemDetails(RequestModel model, string path = "", string graphQuery = "", string templateId = "", string paginationCusor = "", int pagesize = 10, string requestMethodName = "")
        {
            var graphQLQueryVariable = new GraphQLQueryVariable()
            {
                sitename = SiteName,
                language = model?.Language
            };
            graphQuery = !String.IsNullOrEmpty(graphQuery) ? graphQuery : Constants.GraphQlQueries.GetItemLayout;
            var itemPath = path;

            graphQLQueryVariable.path = itemPath;
            graphQLQueryVariable.templates = templateId;
            graphQLQueryVariable.cursor = paginationCusor == null ? "" : paginationCusor;
            graphQLQueryVariable.pagesize = pagesize;
            JToken result;
            result = await _graphQLService.GetResultsAsync<JToken>(graphQuery, graphQLQueryVariable);
            return result;
        }


        /// <summary>
        /// Processing the Layout service reponse to map with proper model
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>     
        /// <param name="component"></param>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <param name="fieldsData"></param>
        /// <param name="requestTemplateId"></param>
        /// <returns></returns>
        public async Task<object> BuildModel<T>(PlaceholderComponents component, string name, RequestModel model = null, JToken fieldsData = null, string requestTemplateId = null, string pageUrl = "", string headerVariant = "", BuildModelParameter buildModelParameter = null)
        {
            string query = string.Empty;
            StringBuilder sb = new StringBuilder();
            string[] requestArray = null;
            requestArray = new[] { $"BuildModel_{typeof(T).Name}",  model?.Language,
                    model?.Id, model?.ScreenName, model?.PageType, model?.Type,component?.DataSource };
            string cacheKey = string.Join("_", requestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant();
            bool userInsideSemanticKernalApplication = false;
            try
            {
                //switch (typeof(T))
                //{
                //    #region CarouselFullPages
                //    //CarouselFullPages Component
                //    case Type type when type == typeof(CarouselFullPagesResponseModelList):
                //        CarouselFullPagesResponseModelList carouselFullPagesResponseModelList = new CarouselFullPagesResponseModelList();
                //        var carourolCackey = cacheKey + nameof(CarouselFullPagesList.Slides);
                //        //if (_cacheService.TryGetValue(cacheKey, out T cacheCarouselFullPagesResponse) && cacheCarouselFullPagesResponse != null)
                //        //{
                //        //    if (cacheCarouselFullPagesResponse is CarouselFullPagesResponseModelList cacheData)
                //        //    {
                //        //        carouselFullPagesResponseModelList = cacheData;
                //        //        return (T)(object)carouselFullPagesResponseModelList;
                //        //    }
                //        //}
                //        //else if (_cacheService.TryGetValue(carourolCackey, out T carourolCackeyCarouselFullPagesResponse) && carourolCackeyCarouselFullPagesResponse != null)
                //        //{
                //        //    if (carourolCackeyCarouselFullPagesResponse is CarouselFullPagesResponseModelList cacheData)
                //        //    {
                //        //        carouselFullPagesResponseModelList = cacheData;
                //        //        return (T)(object)carouselFullPagesResponseModelList;
                //        //    }
                //        //}
                //        return await CarouselFullPagesAsync<CarouselFullPagesResponseModelList>(component, name, model, fieldsData, requestTemplateId, pageUrl, headerVariant, buildModelParameter, cacheKey);

                //    #endregion

                //    #region MobileScreens Component
                //    case Type type when type == typeof(MobileScreenResponseModelList):
                //        var appMobileScreenList = component.Fields?.ToObject<MobileScreenList>();
                //        var mobileScreenList = new List<MobileScreenResponseModel>();
                //        foreach (var mobileScreen in appMobileScreenList.MobileScreens)
                //        {
                //            if (mobileScreen != null)
                //            {
                //                mobileScreenList.Add(new MobileScreenResponseModel()
                //                {
                //                    ScreenName = mobileScreen.MobileScreenFields?.ScreenName?.Value ?? String.Empty,
                //                    ScreenId = mobileScreen.MobileScreenFields?.ScreenItem?.Value?.Id ?? String.Empty
                //                });
                //            }
                //        }
                //        var result = new MobileScreenResponseModelList()
                //        {
                //            MobileScreens = mobileScreenList
                //        };
                //        return (T)(object)result;
                //    #endregion

                //    #region AppCard Component
                //    case Type type when type == typeof(AppCardsResponseModelList):
                //        List<AppCardsResponseModel> cardList;
                //        var appcards = component.Fields?.ToObject<AppCardsModelList>();
                //        cardList = new List<AppCardsResponseModel>();
                //        if (appcards?.Cards != null && appcards?.Cards.Length > 0)
                //        {
                //            foreach (var item in appcards.Cards)
                //            {
                //                if (item != null)
                //                {
                //                    AppCardsResponseModel cards = new AppCardsResponseModel();
                //                    cards.CardName = item.ComponentsFields.CardName?.Value ?? String.Empty;
                //                    var appcardsMobileScreenFields = new MobileScreenResponseModel
                //                    {
                //                        ScreenName = item?.ComponentsFields.CTAAction?.MobileScreenFields?.ScreenName?.Value,
                //                        ScreenId = item?.ComponentsFields.CTAAction?.MobileScreenFields?.ScreenItem?.Value?.Id,
                //                    };
                //                    var appcardsScreenId = item.ComponentsFields?.CTALink?.Value?.Id;
                //                    if (!string.IsNullOrEmpty(appcardsScreenId))
                //                    {
                //                        appcardsMobileScreenFields.ScreenId = appcardsScreenId;
                //                    }
                //                    cards.CTAAction = appcardsMobileScreenFields.ScreenName ?? String.Empty;
                //                    cards.Id = appcardsMobileScreenFields.ScreenId ?? String.Empty;
                //                    cards.Image = item.ComponentsFields?.Image?.Value?.Src ?? String.Empty;
                //                    cards.Type = item.ComponentsFields?.CardType?.Fields?.Value?.Value ?? String.Empty;
                //                    cards.OverlayImage = item.ComponentsFields?.OverlayImage?.Value?.Src ?? String.Empty;
                //                    cardList.Add(cards);
                //                }

                //            }
                //        }
                //        var appList = new AppCardsResponseModelList();
                //        appList.Title = appcards?.Title?.Value ?? String.Empty;
                //        appList.Position = appcards?.Position?.Value ?? String.Empty;
                //        appList.VariantType = Constants.APP_CARDS;
                //        appList.ComponentData = new List<AppCardsResponseModel>();
                //        appList.ComponentData.AddRange(cardList);
                //        return (T)(object)appList;
                //    #endregion

               
                //    default:
                //        break;
                //}
            }
            catch (AggregateException allExceptions)
            {
                foreach (var ex in allExceptions.Flatten().InnerExceptions)
                {
                    _logger.LogError($"Error occur from method ModelMapperService.BuildModel ==Error :{ex.Message} == {ex.StackTrace}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occur from method ModelMapperService.BuildModel ==Error :{ex.Message} == {ex.StackTrace}");
            }
            await Task.CompletedTask;
            return default(T);
        }


       
        
     
        #endregion

        #region private method(s)

        /// <summary>
        /// Get the graphql results based on the item GUID passed
        /// </summary>
        /// <param name="model"></param>
        /// <param name="path"></param>
        /// <param name="query"></param>
        /// <param name="templateId"></param>
        /// <param name="paginationCursor"></param>
        /// <param name="pagesize"></param>
        /// <param name="requestMethodName"></param>
        /// <returns></returns>
        private Task<JToken> GetResultsByItemId(RequestModel model, string path, string query, string templateId = "", string paginationCursor = "", int pagesize = 10, string requestMethodName = "")
        {
            return GetSitecoreItemDetails(model, path, query, templateId, paginationCursor, pagesize, requestMethodName);

        }
        /// <summary>
        /// //Generating the query for listing / Filters
        /// </summary>
        /// <param name="model"></param>
        /// <param name="query"></param>
        /// <param name="sb"></param>
        private void GenerateDynamicQueryForListingFilter(RequestModel model, string type, out string query, string path = null, string templateId = null)
        {
            StringBuilder sb = new StringBuilder();
            var sortorder = Constants.Descending;
            //With filter for listing
            if (model.Filters != null && model.Filters.Count > 0)
            {
                sb.Append("where:{");
                sb.Append("AND:[");
                sb.Append($@"{{ name: ""_hasLayout"" value: ""true"" }}");
                sb.Append($@"{{ name: ""_path"" value: ""{path}"", operator: CONTAINS }}");
                sb.Append($@"{{ name: ""_templates"" value: ""{templateId}"", operator: CONTAINS }}");
                //As per functional spec all filters in AND condition
                //sb.Append("{");
                //sb.Append("OR:[");

                bool isDate = false;
                string formattedDate = "";
                bool isNotDateFilter = true;
                if (model?.Filters != null)
                {
                    var dateFilterData = model?.Filters.Where(p => p.FilterField.Equals(Constants.Date, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (dateFilterData != null)
                    {
                        isNotDateFilter = false;
                        //Date field is available in Events only
                        if (type == Constants.Events && dateFilterData.FilterField.ToLower() == Constants.Date.ToLower())
                        {
                            sortorder = Constants.Ascending;
                            isDate = true;
                            if (_options.Value.SitecoreGraphQLSettings.SC_ApiKeyName.Equals(Constants.Sc_apikey, StringComparison.InvariantCultureIgnoreCase))
                                formattedDate = Convert.ToDateTime(dateFilterData.FilterOptionId?.FirstOrDefault()).ToString("yyyy-MM-ddT00:00:00Z");
                            else
                                formattedDate = Convert.ToDateTime(dateFilterData.FilterOptionId?.FirstOrDefault()).ToString("yyyyMMdd");
                            sb.Append($@"{{ name: ""{Constants.Date}"", value: ""{formattedDate}"", operator: CONTAINS }}");
                        }
                        //Publish date / Expiry is used for Offers
                        else if (type == Constants.Offers && dateFilterData.FilterField.ToLower() == Constants.Date.ToLower())
                        {
                            sortorder = Constants.Ascending;
                            isDate = true;
                            if (_options.Value.SitecoreGraphQLSettings.SC_ApiKeyName.Equals(Constants.Sc_apikey, StringComparison.InvariantCultureIgnoreCase))
                                formattedDate = Convert.ToDateTime(dateFilterData.FilterOptionId?.FirstOrDefault()).ToString("yyyy-MM-ddT00:00:00Z");
                            else
                                formattedDate = Convert.ToDateTime(dateFilterData.FilterOptionId?.FirstOrDefault()).ToString("yyyyMMdd");

                            sb.Append($@"{{ name: ""{Constants.ExpiryDate}"", value: ""{formattedDate}"", operator: CONTAINS }}");
                            sb.Append($@"{{ name: ""{Constants.PublishDate}"", value: ""{formattedDate}"", operator: CONTAINS }}");
                        }
                        //Publish date is used for News/Blogs/Podcast
                        else if (type != Constants.Events && dateFilterData.FilterField.ToLower() == Constants.Date.ToLower())
                        {
                            sortorder = Constants.Descending;
                            isDate = true;
                            if (_options.Value.SitecoreGraphQLSettings.SC_ApiKeyName.Equals(Constants.Sc_apikey, StringComparison.InvariantCultureIgnoreCase))
                                formattedDate = Convert.ToDateTime(dateFilterData.FilterOptionId?.FirstOrDefault()).ToString("yyyy-MM-ddT00:00:00Z");
                            else
                                formattedDate = Convert.ToDateTime(dateFilterData.FilterOptionId?.FirstOrDefault()).ToString("yyyyMMdd");

                            sb.Append($@"{{ name: ""{Constants.PublishDate}"", value: ""{formattedDate}"", operator: CONTAINS }}");
                        }
                    }
                }
                foreach (var filters in model.Filters.Where(p => !p.FilterField.Equals(Constants.Date, StringComparison.InvariantCultureIgnoreCase)))
                {
                    isNotDateFilter = true;
                    sb.Append("{");
                    sb.Append("OR:[");
                    if (_options.Value.CDPSettings.EnableCDP)
                    {
                        foreach (var filter in filters.FilterOptionId)
                        {
                            //Author filter from Author field
                            if (filters.FilterField.ToLower().Contains(Constants.Author.ToLower()))
                                sb.Append($@"{{ name: ""{Constants.Author}"", value: ""{filter}"", operator: CONTAINS }}");
                            else if (filters.IsKeywordFilter)//For keyword search
                                sb.Append($@"{{ name: ""{Constants.Heading}"", value: ""{filter}"", operator: CONTAINS }}");
                            else//For facet filtering from the categories field of the item
                                sb.Append($@"{{ name: ""{Constants.FacetFilterCategories}"", value: ""{filter}"", operator: CONTAINS }}");

                        }
                    }
                   
                    sb.Append("]");
                    sb.Append("}");
                }
                if (isNotDateFilter)
                {
                    //Date range filteration
                    //Publish date is used for Events/Offer
                    if (type.Equals(Constants.Events, StringComparison.InvariantCultureIgnoreCase) && model.IsFutureCardsRequired)
                    {
                        //Only show future events if we get && model.IsFutureCardsRequired =true for listing
                        sb.Append($@"{{ name: ""Date"" value: ""{DateTime.Now.ToString("yyyyMMddT000000Z")}"", operator: GTE }}");
                    }
                    else if (type.Equals(Constants.Offers, StringComparison.InvariantCultureIgnoreCase))
                    {
                        sb.Append("{");
                        sb.Append("OR:[");
                        sb.Append($@"{{ name : ""PublishDate"" value: ""{DateTime.Now.ToString("yyyyMMddT000000Z")}"", operator: GTE }}");
                        sb.Append($@"{{ name : ""MobileValidityExpiryDate"" value: ""{DateTime.Now.ToString("yyyyMMddT000000Z")}"", operator: GTE }}");
                        sb.Append("]");
                        sb.Append("}");
                    }
                }
                sb.Append("]");
                sb.Append("}");
                if (model.PageType == null || (model.PageType != null && !model.PageType.Equals(Constants.Listing, StringComparison.InvariantCultureIgnoreCase)))
                    query = Constants.GraphQlQueries.GetListing.Replace("where", sb.ToString());
                else
                    query = Constants.GraphQlQueries.GetServiceListing.Replace("where", sb.ToString());

            }
            else
            {
                //without filters for listing
                sb = new StringBuilder();
                sb.Append("where:{");
                sb.Append("AND:[");
                sb.Append($@"{{ name: ""_hasLayout"" value: ""true"" }}");
                sb.Append($@"{{ name: ""_path"" value: ""{path}"", operator: CONTAINS }}");
                sb.Append($@"{{ name: ""_templates"" value: ""{templateId}"", operator: CONTAINS }}");

                //Date range filteration
                //Publish date is used for Events/Offer
                if (type.Equals(Constants.Events, StringComparison.InvariantCultureIgnoreCase) && model.IsFutureCardsRequired)
                {
                    sortorder = Constants.Descending;
                    //Only show future events if we get && model.IsFutureCardsRequired =true for listing
                    sb.Append($@"{{ name: ""Date"" value: ""{DateTime.Now.ToString("yyyyMMddT000000Z")}"", operator: GTE }}");
                }
                else if (type.Equals(Constants.Offers, StringComparison.InvariantCultureIgnoreCase))
                {
                    sortorder = Constants.Ascending;
                    sb.Append("{");
                    sb.Append("OR:[");
                    sb.Append($@"{{ name : ""PublishDate"" value: ""{DateTime.Now.ToString("yyyyMMddT000000Z")}"", operator: GTE }}");
                    sb.Append($@"{{ name : ""MobileValidityExpiryDate"" value: ""{DateTime.Now.ToString("yyyyMMddT000000Z")}"", operator: GTE }}");
                    sb.Append("]");
                    sb.Append("}");
                }
                sb.Append("]");
                sb.Append("}");
                if (model.PageType == null || (model.PageType != null && !model.PageType.Equals(Constants.Listing, StringComparison.InvariantCultureIgnoreCase)))
                    query = Constants.GraphQlQueries.GetListing.Replace("where", sb.ToString());
                else
                    query = Constants.GraphQlQueries.GetServiceListing.Replace("where", sb.ToString());

            }

            if (!string.IsNullOrEmpty(model.SortOrder) && model.SortOrder.Equals(Constants.Ascending, StringComparison.InvariantCultureIgnoreCase))
            {
                sortorder = Constants.Ascending;
            }
            else if (!string.IsNullOrEmpty(model.SortOrder) && model.SortOrder.Equals(Constants.Descending, StringComparison.InvariantCultureIgnoreCase))
            {
                sortorder = Constants.Descending;
            }
            var orderByTitle = String.Empty;
            if (!String.IsNullOrEmpty(model.SortBy) && model.SortBy.Equals(Constants.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                orderByTitle = $"orderBy: {{ name: \"Heading\", direction: {sortorder} }}";
                query = query.Replace("ORDERBY", orderByTitle);
            }
            else
            {
                var orderByPublishDate = $"orderBy: {{ name: \"PublishDate\", direction: {sortorder} }}";
                var orderByDate = $"orderBy: {{ name: \"Date\", direction:{sortorder} }}";
                var orderByExpiryDate = $"orderBy: {{ name: \"MobileValidityExpiryDate\", direction: {sortorder} }}";
                switch (type)
                {
                    case var variantType when Constants.News.Contains(variantType):
                        query = query.Replace("ORDERBY", orderByPublishDate);
                        break;
                    case var variantType when Constants.Events.Contains(variantType):
                        query = query.Replace("ORDERBY", orderByDate);
                        break;
                    case var variantType when Constants.Blogs.Contains(variantType):
                        query = query.Replace("ORDERBY", orderByPublishDate);
                        break;
                    case var variantType when Constants.Podcast.Contains(variantType):
                        query = query.Replace("ORDERBY", orderByPublishDate);
                        break;
                    case var variantType when Constants.Offers.Contains(variantType):
                        query = query.Replace("ORDERBY", orderByExpiryDate);
                        break;
                    default:
                        query = query.Replace("ORDERBY", null);
                        break;

                }
            }
        }
     

        #endregion

    

    }
}
