using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;

using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;

using Newtonsoft.Json.Linq;
using System.Text.Json;

using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace SemanticKernalApplication.WebAPI.ModelMapping
{
    /// <summary>
    /// The Service Mapping Screens with Output JSON
    /// </summary>
    public class ScreenMappingService : IBaseScreenMappingService
    {
        #region variable                
        private readonly ILogger<ScreenMappingService> _logger;
        private readonly IModelMapperService _modelMapper;
       
        private readonly ICacheService _cacheService;
      
        private readonly IOptions<SemanticKernalApplicationSettings> _options;
        private readonly IConfiguration _configuration;
        private readonly IAPIWrapper _wrapper;
        #endregion

        #region constructor
        public ScreenMappingService(ILogger<ScreenMappingService> logger, IAPIWrapper wrapper, IConfiguration configuration, IOptions<SemanticKernalApplicationSettings> options, IModelMapperService modelMapper, ICacheService cacheService)
        {
            _logger = logger;
            _modelMapper = modelMapper;

            _cacheService = cacheService;

            _options = options;
            _configuration = configuration;
            _wrapper = wrapper;
        }
        #endregion
   

        /// <summary>
        /// Get Settings Screen Components
        /// </summary>
        /// <param name="sitecoreComponents"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public async Task GetSettingsScreenComponents(List<PlaceholderComponents> sitecoreComponents, BaseAppResponse response)
        {
            foreach (var component in sitecoreComponents)
            {
                var componentName = JsonNamingPolicy.CamelCase.ConvertName(component.ComponentName);
                switch (component.ComponentName.ToLower())
                {
                    case string name when name.StartsWith(Constants.MOBILE_SCREEN_DETAILS):
                        _logger.LogInformation($"=====Processing {Constants.MOBILE_SCREEN_DETAILS} components ============");
                        response.SectionComponents.Add(await TryGetFromCache<MobileScreenResponseModelList>(response, component, componentName, requestMethodName: nameof(GetSettingsScreenComponents)));
                        //response.SectionComponents.Add(await _modelMapper.BuildModel<MobileScreenResponseModelList>(component, componentName));
                        _logger.LogInformation($"=====Finished Processing {Constants.MOBILE_SCREEN_DETAILS} components ============");
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Get Home Screen Components
        /// </summary>
        /// <param name="sitecoreComponents"></param>
        /// <param name="response"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task GetHomeScreenComponents(List<PlaceholderComponents> sitecoreComponents, BaseAppResponse response, RequestModel model = null, JToken fieldsData = null, BuildModelParameter buildModelParameter = null)
        {
            response.SectionComponents = new List<object>();
            List<Task<object>> tasks = new List<Task<object>>();

            foreach (var component in sitecoreComponents)
            {
                var componentName = JsonNamingPolicy.CamelCase.ConvertName(component.ComponentName);
                switch (component.ComponentName.ToLower())
                {
                    case string name when name.StartsWith(Constants.APP_CARDS):
                        tasks.Add(_modelMapper.BuildModel<object>(component, componentName));
                        break;
                   
                    default:
                        break;
                }
            }
            try
            {
                await Task.WhenAll(tasks);

            }
            catch (AggregateException allExceptions)
            {
                foreach (var ex in allExceptions.Flatten().InnerExceptions)
                {
                    _logger.LogError($"Error occur from method GetHomeScreenComponents ==Error :{ex.Message} == {ex.StackTrace}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occur from method GetHomeScreenComponents ==Error :{ex.Message} == {ex.StackTrace}");
            }
            tasks.ForEach(component => response.SectionComponents.Add(component.Result));
        }
       

        private async Task<object> TryGetFromCache<T>(BaseAppResponse response, PlaceholderComponents component, string componentName, RequestModel model = null, JToken fieldsData = null, string requestTemplateId = null, string pageUrl = "", string requestMethodName = "", string headerVariant = "", bool isEnableLatLngCache = false, bool isSfidRequired = false, BuildModelParameter buildModelParameter = null)
        {
            string[] requestArray = null;
            string filters = string.Empty;
          
            if (model == null)
                requestArray = new[] { $"BuildModel_{typeof(T).Name}", requestMethodName };
            else
            {
                //ignoring latlong for cache key, this will mostly needed in terms location based content changes
                requestArray = new[] { $"BuildModel_{typeof(T).Name}", requestMethodName, model.Language,
                model?.ScreenName, component?.DataSource };
            }
            string cacheKey = string.Join("_", requestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant();
            if (_cacheService.TryGetValue(cacheKey, out T cacheResponse) && cacheResponse != null)
            {
                return cacheResponse;
            }
            else
            {
                var buildModelResponse = await _modelMapper.BuildModel<T>(component, componentName, model, fieldsData: fieldsData, requestTemplateId: requestTemplateId, pageUrl, headerVariant, buildModelParameter: buildModelParameter);
                //  _cacheService.Set(cacheKey, buildModelResponse);
                return buildModelResponse;
            }
        }
       
    }

}