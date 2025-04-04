using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace SemanticKernalApplication.WebAPI.Respositories
{
    public class GraphQLRepository : IGraphQLRepository
    {
        #region variable        
        IGraphQLService _graphQLService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<GraphQLRepository> _logger;
        #endregion

        #region constructor
        public GraphQLRepository(IGraphQLService graphQLService, IMemoryCache memoryCache, ILogger<GraphQLRepository> logger)
        {
            _graphQLService = graphQLService;
            _memoryCache = memoryCache;
            _logger = logger;
        }
        #endregion

        #region public method(s)

        /// <summary>
        /// Get Mobile App Configurations
        /// </summary>
        /// <returns></returns>
        public async Task<MobileAppConfigResponseModel> GetMobileAppConfigurations()
        {
            var mobileAppConfigResponseModel = new MobileAppConfigResponseModel();

            try
            {
                var headerVariables = new
                {
                    pageSize = 1,
                    endCursor = string.Empty,
                    websiteRootId = Constants.SemanticKernalApplication_WEBSITE_ROOT_ITEM_SHORT_ID,
                    mobileAppConfigurationsTemplateId = Constants.MOBILE_APP_CONFIGURATIONS_TEMPLATE_SHORT_ID
                };

                var results = await _graphQLService.GetResultsAsync<Models.GraphQLResponseModels.ItemSearchResult>(Constants.GraphQlQueries.GetMobileAppConfigurations, headerVariables);

                if (results != null && results.Search != null && (results.Search.Results != null && results.Search.Results.Any()))
                {
                    var firstResult = results.Search.Results.FirstOrDefault();
                    if (firstResult != null && (firstResult.Fields != null && firstResult.Fields.Any()))
                    {
                        var configurationsField = firstResult.Fields.FirstOrDefault(x => x.Name == Constants.ConfigurationsFieldName);
                        if (configurationsField != null && !string.IsNullOrWhiteSpace(configurationsField.Value))
                        {
                            var keyValueList = GetKeyValueList(configurationsField);

                            if (!_memoryCache.TryGetValue(Constants.CacheKeys.MobileAppConfigurationsCacheKey, out MobileAppConfigResponseModel cachedMobileAppConfigResponseModel))
                            {
                                mobileAppConfigResponseModel.ConfigDetails = keyValueList;
                                mobileAppConfigResponseModel.VersionNumber = Guid.NewGuid().ToString();

                                _memoryCache.Set(Constants.CacheKeys.MobileAppConfigurationsCacheKey, mobileAppConfigResponseModel, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(24)));
                            }
                            else
                            {
                                if (cachedMobileAppConfigResponseModel != null && !IsDictionariesAreSame(cachedMobileAppConfigResponseModel.ConfigDetails, keyValueList))
                                {
                                    mobileAppConfigResponseModel.ConfigDetails = keyValueList;
                                    mobileAppConfigResponseModel.VersionNumber = Guid.NewGuid().ToString();

                                    _memoryCache.Set(Constants.CacheKeys.MobileAppConfigurationsCacheKey, mobileAppConfigResponseModel, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(24)));
                                }
                                else
                                {
                                    mobileAppConfigResponseModel = cachedMobileAppConfigResponseModel;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GraphQLRepository.GetMobileAppConfigurations. Message: {ex.Message}", ex);
            }

            return mobileAppConfigResponseModel;
        }

        /// <summary>
        /// Get Mobile App Dictionary
        /// </summary>
        /// <returns></returns>
        public async Task<MobileAppDictionaryResponseModel> GetMobileAppDictionary()
        {
            var mobileAppDictionaryResponseModel = new MobileAppDictionaryResponseModel();

            try
            {
                var headerVariables = new
                {
                    pageSize = 1,
                    endCursor = string.Empty,
                    websiteRootId = Constants.SemanticKernalApplication_WEBSITE_ROOT_ITEM_SHORT_ID,
                    mobileAppConfigurationsTemplateId = Constants.MOBILE_APP_CONFIGURATIONS_TEMPLATE_SHORT_ID
                };

                var results = await _graphQLService.GetResultsAsync<Models.GraphQLResponseModels.ItemSearchResult>(Constants.GraphQlQueries.GetMobileAppConfigurations, headerVariables);

                if (results != null && results.Search != null && (results.Search.Results != null && results.Search.Results.Any()))
                {
                    var firstResult = results.Search.Results.FirstOrDefault();
                    if (firstResult != null && (firstResult.Fields != null && firstResult.Fields.Any()))
                    {
                        var configurationsField = firstResult.Fields.FirstOrDefault(x => x.Name == Constants.DictionaryDetailsFieldName);
                        if (configurationsField != null && !string.IsNullOrWhiteSpace(configurationsField.Value))
                        {
                            var keyValueList = GetKeyValueList(configurationsField);

                            if (!_memoryCache.TryGetValue(Constants.CacheKeys.MobileAppDictionaryDetailsCacheKey, out MobileAppDictionaryResponseModel cachedMobileAppDictionaryResponseModel))
                            {
                                mobileAppDictionaryResponseModel.DictionaryDetails = keyValueList;
                                mobileAppDictionaryResponseModel.VersionNumber = Guid.NewGuid().ToString();

                                _memoryCache.Set(Constants.CacheKeys.MobileAppDictionaryDetailsCacheKey, mobileAppDictionaryResponseModel, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(24)));
                            }
                            else
                            {
                                if (cachedMobileAppDictionaryResponseModel != null && !IsDictionariesAreSame(cachedMobileAppDictionaryResponseModel.DictionaryDetails, keyValueList))
                                {
                                    mobileAppDictionaryResponseModel.DictionaryDetails = keyValueList;
                                    mobileAppDictionaryResponseModel.VersionNumber = Guid.NewGuid().ToString();

                                    _memoryCache.Set(Constants.CacheKeys.MobileAppDictionaryDetailsCacheKey, mobileAppDictionaryResponseModel, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(24)));
                                }
                                else
                                {
                                    mobileAppDictionaryResponseModel = cachedMobileAppDictionaryResponseModel;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GraphQLRepository.GetMobileAppDictionary. Message: {ex.Message}", ex);
            }

            return mobileAppDictionaryResponseModel;
        }

        #endregion

        #region private method(s)
        /// <summary>
        /// Get Key Value List
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetKeyValueList(Models.GraphQLResponseModels.Field field)
        {
            var keyValueList = new Dictionary<string, string>();

            var nameValues = field.Value.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameValues != null && nameValues.Length > 0)
            {
                foreach (var nameValue in nameValues)
                {
                    if (!string.IsNullOrEmpty(nameValue) && nameValue.Contains('='))
                    {
                        var nameValueInfo = nameValue.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        if (nameValueInfo != null && nameValueInfo.Length == 2)
                        {
                            keyValueList.Add(nameValueInfo[0], Uri.UnescapeDataString(nameValueInfo[1]));
                        }
                    }
                }
            }

            return keyValueList;
        }

        /// <summary>
        /// Is Dictionaries Are Same
        /// </summary>
        /// <param name="dictionary1"></param>
        /// <param name="dictionary2"></param>
        /// <returns></returns>
        private bool IsDictionariesAreSame(Dictionary<string, string> dictionary1, Dictionary<string, string> dictionary2)
        {
            var isEqual = false;
            if (dictionary1.Count == dictionary2.Count)
            {
                isEqual = true;
                foreach (var pair in dictionary1)
                {
                    string value;
                    if (dictionary2.TryGetValue(pair.Key, out value))
                    {
                        if (value != pair.Value)
                        {
                            isEqual = false;
                            break;
                        }
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
            }

            return isEqual;
        }

        #endregion
    }
}
