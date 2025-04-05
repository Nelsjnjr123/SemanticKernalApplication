using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Helpers;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;
using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using static SemanticKernalApplication.Core.Constants;
using SemanticKernalApplication.Models;

namespace SemanticKernalApplication.WebAPI.Respositories
{
    public class LayoutRepository : ILayoutRepository
    {
        #region variable        
        IGraphQLService _graphQLService;
        private readonly ILogger<LayoutRepository> _logger;
        private readonly IModelMapperService _modelMapper;
        private readonly IBaseScreenMappingService _baseScreenMapping;
        private readonly ICacheService _cacheService;
        private readonly IPersonalizationRepository _personalizationRepository;
        private readonly IOptions<SemanticKernalApplicationSettings> _options;

        //private readonly IAlgoliaService _algoliaService;
        #endregion

        #region constructor
        public LayoutRepository(IGraphQLService graphQLService, ILogger<LayoutRepository> logger,
            IModelMapperService modelMapper, IBaseScreenMappingService baseScreenMapping,
            ICacheService cacheService, IPersonalizationRepository personalizationRepository, IOptions<SemanticKernalApplicationSettings> options
           )
        {
            _graphQLService = graphQLService;
            _logger = logger;
            _modelMapper = modelMapper;
            _baseScreenMapping = baseScreenMapping;
            _cacheService = cacheService;
            _personalizationRepository = personalizationRepository;
            _options = options;

        }
        #endregion

        #region public method(s)
        /// <summary>
        /// Getting the page components and process it
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<object> GetPageComponents(RequestModel model)
        {
            _logger.LogInformation("========LayoutRepository.GetPageComponents =======: screenName:" + model?.ScreenName + " \r\n" + JsonSerializer.Serialize(model));
            string pageName = String.Empty;
            string headerVariant = String.Empty;
            bool isServices = false;
            BaseAppResponse response = new BaseAppResponse
            {
                SectionComponents = new List<object>()
            };
            BuildModelParameter buildModelParameter = new BuildModelParameter();
            string cacheKey = String.Empty;
            string serialzedfilter = String.Empty;
            try
            {
          
                var results = await CreateAndGetAllTaskResults(model, serialzedfilter);

                //  var contextItemHeading = results.sitecoreLayoutModel.FieldData?.ToObject<HeadingContentModel>();
                // string title = !String.IsNullOrWhiteSpace(contextItemHeading?.Heading?.Value) ? contextItemHeading?.Heading?.Value : contextItemHeading?.Title?.Value;
                pageName = !String.IsNullOrWhiteSpace("") ? "" : String.Empty;
                var mainPlaceholders = results.sitecoreLayoutModel?.PlaceholderData;
                var mobileMainPlaceholders = results.sitecoreLayoutModel?.MobilePlaceholderData;
                var mobilePlaceholderComponents = new JArray();
                List<PlaceholderComponents> mobileSitecoreComponents = new List<PlaceholderComponents>();
                if (mobileMainPlaceholders != null)
                {
                    mobilePlaceholderComponents = JArray.FromObject(mobileMainPlaceholders);
                    mobileSitecoreComponents = mobilePlaceholderComponents?.ToObject<List<PlaceholderComponents>>();
                }
                var placeholderComponents = new JArray();

                List<PlaceholderComponents> sitecoreComponents = new List<PlaceholderComponents>();
                if (mainPlaceholders != null)
                {
                    placeholderComponents = JArray.FromObject(mainPlaceholders);
                    sitecoreComponents = placeholderComponents?.ToObject<List<PlaceholderComponents>>();


                    switch (model.ScreenName.ToLower())
                    {
                        case Constants.ScreenName.SettingsPageScreen:
                            await _baseScreenMapping.GetSettingsScreenComponents(sitecoreComponents, response);
                            break;
                        case Constants.ScreenName.HomePageScreen:
                            await _baseScreenMapping.GetHomeScreenComponents(sitecoreComponents, response, model, results.sitecoreLayoutModel.FieldData, buildModelParameter);
                            break;

                    }

                }
                else
                {
                    if (model.ScreenName.ToLower() == ScreenName.SettingsPageScreen)
                    {
                        var themeFields = results.sitecoreLayoutModel.FieldData.ToArray().Where(x => (string)x["name"] == "SiteTheme" || (string)x["name"] == "GlobalTheme").ToList();

                        List<SettingsModel> settings = new List<SettingsModel>();
                        foreach (var item in themeFields)
                        {
                            SettingsModel settingsModel = new SettingsModel();
                            settingsModel.Key = (string)item.SelectToken("name");
                            settingsModel.Value = (string)item.SelectToken("jsonValue.value.src");

                            settings.Add(settingsModel);
                        }

                        var textFields = results.sitecoreLayoutModel.FieldData.ToArray().Where(x => (string)x["name"] == "System Input" || (string)x["name"] == "User Input" || (string)x["name"] == "Seasonal Input").ToList();
                        foreach (var item in textFields)
                        {
                            SettingsModel settingsModel = new SettingsModel();
                            settingsModel.Key = (string)item.SelectToken("name");
                            settingsModel.Value = (string)item.SelectToken("jsonValue.value");

                            settings.Add(settingsModel);
                        }

                        response.SectionComponents.Add(settings);
                    }
                    if (model.ScreenName.ToLower() == ScreenName.SeasonsPageScreen)
                    {
                        List<SettingsModel> settings = new List<SettingsModel>();
                        var textFields = results.sitecoreLayoutModel.FieldData.ToArray().Where(x => (string)x["name"] == "Start Date" || (string)x["name"] == "End Date" || (string)x["name"] == "Name" || (string)x["name"] == "Prompt Input").ToList();

                        foreach (var item in textFields)
                        {
                            SettingsModel settingsModel = new SettingsModel();
                            settingsModel.Key = (string)item.SelectToken("name");
                            settingsModel.Value = (string)item.SelectToken("jsonValue.value");

                            settings.Add(settingsModel);
                        }

                        response.SectionComponents.Add(settings);
                    }
                    _logger.LogInformation($"======== LayoutRepository.GetPageComponents =======:screenName: {model?.ScreenName} No Placeholder found for this page");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in LayoutRepository.GetPageComponents. Message: {ex.Message}", ex);
            }
            if (_options.Value.CDPSettings.EnableCDP && !String.IsNullOrEmpty(model?.BrowserId) &&
                (!String.IsNullOrEmpty(model.ScreenName) && !model.ScreenName.Equals(Constants.ScreenName.OnboardingPageScreen, StringComparison.InvariantCultureIgnoreCase)))
            {

                //Fire and forget
                _ = TriggerViewEventAsync(model, !String.IsNullOrEmpty(pageName) ? pageName : model?.ScreenName, isServices);
            }
            return response;
        }

        #endregion

        #region private method(s)
        /// <summary>
        /// Triggering view event
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pageName"></param>
        /// <param name="isServices">Whatson / experience(Art, dine , news podcast etc)</param>
        /// <returns></returns>
        private async Task TriggerViewEventAsync(RequestModel model, string pageName, bool isServices = false)
        {

            //Adding page view event
            CDPBase personalizationModel = new CDPBase()
            {
                BrowserId = model?.BrowserId,
                Channel = _options.Value?.CDPSettings.Channel,
                Currency = _options.Value?.CDPSettings.Currency,
                Language = _options.Value?.CDPSettings.Language,
                Page = pageName ?? model?.ScreenName,
                Pos = _options.Value?.CDPSettings.Pos,
                Type = Core.Constants.PageViewEvent,
                SessionData = new CDP_Session()
                {
                    
                    
                    ScreenName = model?.ScreenName,                  
                    PageTitle = pageName

                }
            };
            //Add the Services Types(whatson /Experience)
            if (isServices)
            {
                var extension = new CDPBaseExtensions()
                {
                 
                  
                    PageTitle = pageName,
                    ScreenName = model?.ScreenName
                 
                };
                personalizationModel.Ext = extension;
            }
            else
            {
                var extension = new CDPBaseExtensions()
                {                    
                
                    PageTitle = pageName,
                    ScreenName = model?.ScreenName,
                  
                };
                personalizationModel.Ext = extension;
            }
            await _personalizationRepository.TriggerEventAsync(personalizationModel, model?.BrowserId);
        }

        async Task<(SitecoreLayoutModel sitecoreLayoutModel, BuildModelParameter buildModelParameter, string cacheKey)> CreateAndGetAllTaskResults(RequestModel model, String Serialzedfilter)
        {
            BuildModelParameter buildModelParameter = new BuildModelParameter();
            string cacheKey = String.Empty;
            List<Task<object>> tasks = new List<Task<object>>();
            bool isFromCache = false;
            var requestArray = new[] { "GetSitecoreLayoutComponents", model?.Language,   model?.ScreenName,  };
            string personnaLayoutBasedCacheKey = $"{string.Join("_", requestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";
            var nonRequestArray = new[] { "GetSitecoreLayoutComponents", model?.Language,   model?.ScreenName };
            string nonPersonnaBasedCacheKey = $"{string.Join("_", nonRequestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";

            SitecoreLayoutModel sitecoreLayoutModel = new SitecoreLayoutModel();
            //Getting the layout cache details of sitecore layout/item query
            if (_cacheService.TryGetValue(cacheKey, out SitecoreLayoutModel cachedSitecoreLayoutModel)
               && cachedSitecoreLayoutModel?.PlaceholderData != null)
            {
                isFromCache = true;
                sitecoreLayoutModel = cachedSitecoreLayoutModel;

            }
            else
            {

                tasks.Add(_modelMapper.GetSitecoreLayoutComponents(model, false));
            }

            try
            {
                await Task.WhenAll(tasks);
                //Fetch record from the Sitecore/Edge using GraphQL              
                foreach (var item in tasks)
                {
                    if (item.Result is SitecoreLayoutModel)
                    {
                        sitecoreLayoutModel = (SitecoreLayoutModel)item.Result;

                    }

                }
            }
            catch (AggregateException allExceptions)
            {
                foreach (var ex in allExceptions.Flatten().InnerExceptions)
                {
                    _logger.LogError($"Error occur from method CreateAndGetAllTaskResults ==Error :{ex.Message} == {ex.StackTrace}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occur from method CreateAndGetAllTaskResults ==Error :{ex.Message} == {ex.StackTrace}");
            }
            return (sitecoreLayoutModel, buildModelParameter, cacheKey);
        }
        #endregion
    }
}
