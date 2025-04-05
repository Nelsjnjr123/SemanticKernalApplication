using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.TextToImage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SemanticKernalApplication.Core;
using SemanticKernalApplication.Models;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Controllers;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;
using SemanticKernalApplication.WebAPI.Respositories;
using static SemanticKernalApplication.Core.Constants;

namespace SemanticKernalApplication.Controllers
{
#pragma warning disable SKEXP0001, SKEXP0010
    public class ThemeGeneratorController : BaseApiController
    {
        #region variable        
        IGraphQLService _graphQLService;
        private readonly ILogger<LayoutRepository> _logger;
        private readonly IModelMapperService _modelMapper;
        private readonly IBaseScreenMappingService _baseScreenMapping;
        private readonly ICacheService _cacheService;
        private readonly IOptions<SemanticKernalApplicationSettings> _options;
        private readonly IAPIWrapper _wrapper;
        Kernel _kernel;
        #endregion
        #region constructor
        public ThemeGeneratorController(IGraphQLService graphQLService, ILogger<LayoutRepository> logger,
            IModelMapperService modelMapper, IBaseScreenMappingService baseScreenMapping,
            ICacheService cacheService, IOptions<SemanticKernalApplicationSettings> options,IAPIWrapper wrapper)
        {
            _graphQLService = graphQLService;
            _logger = logger;
            _modelMapper = modelMapper;
            _baseScreenMapping = baseScreenMapping;
            _cacheService = cacheService;
            _options = options;
            _wrapper = wrapper;
        }
        #endregion
        #region property
        /// <summary>
        /// Getting the Semantic Kernel object
        /// </summary>
        private Kernel kernel
        {
            get
            {
                var builder = Kernel.CreateBuilder();
                builder.AddAzureOpenAIChatCompletion(
                         _options.Value.AzureOpenAISettings.OpenAIModel,   // Azure OpenAI Deployment Name
                          _options.Value.AzureOpenAISettings.Endpoint,  // Azure OpenAI Endpoint
                         _options.Value.AzureOpenAISettings.ApiKey);      // Azure OpenAI Key

                builder.AddAzureOpenAITextToImage(_options.Value.AzureOpenAISettings.Dalle3Model,
                    _options.Value.AzureOpenAISettings.Endpoint,
                     _options.Value.AzureOpenAISettings.ApiKey);

                _kernel = builder.Build();
                return _kernel;
            }
            set
            {
                _kernel = value;
            }

        }
        #endregion
        #region public method
        /// <summary>
        /// Generate the theme based on the user prompt or default theme
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("ThemeGenerator")]
        [HttpPost]
        public async Task<IActionResult> GetThemeAsync([FromBody] RequestModel model)
        {
            if (!string.IsNullOrEmpty(model.UserPrompt) && string.IsNullOrEmpty(model.ScreenName))
            {
                var result = await GetThemeFromUserPromptAsync(model);
                return Ok(JsonConvert.SerializeObject(result));
            }
            else if (!string.IsNullOrEmpty(model.UserPrompt) && !string.IsNullOrEmpty(model.ScreenName) && model.ScreenName == "Flashy")
            {
                var result = await GetFlashImageBasedOnEventsAsync(model);
                return Ok(JsonConvert.SerializeObject(result));
            }
            else
            {
                var requestArray = new[] { "Sitethemes", model?.Brand, model?.Language, model?.DeviceId };
                string cacheKey = $"{string.Join("_", requestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";
                var mainThemerequestArray = new[] { "MainTheme", model?.Brand, model?.Language, model?.DeviceId };
                string mainThemecacheKey = $"{string.Join("_", mainThemerequestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";

                var executionSettings = new AzureOpenAIPromptExecutionSettings
                {
                    ResponseFormat = typeof(ThemesListData)
                };

                ChatHistory history = new ChatHistory();
                string input = "Generate a flutter app theme in json format, which will be used to generate the dynamic theme based on the json properties. The json file should contain the following properties: primary color, secondary color, background color, text color, button default state color, button hover state color, typography font name, typography heading size, typography body text size, spacing padding size and spacing margin size. The json file should be in a valid format and should not contain any additional information or comments.";
                var siteTheming = GetSiteSettings(model.SiteName, model.Brand);
                string globalThemePath = siteTheming.GlobalTheme;
                var globalThemeData = System.IO.File.ReadAllLines(globalThemePath).ToList();
                globalThemeData.ForEach(line => input += line);
                string globalTheme = string.Join("", globalThemeData);

                string siteThemePath = siteTheming.SiteTheme;
                var siteThemeData = System.IO.File.ReadAllLines(siteThemePath).ToList();
                siteThemeData.ForEach(line => input += line);
                string siteTheme = string.Join("", siteThemeData);

                history.AddSystemMessage("You are theme generator and always mandatory for you to generate the 4 theme array structure.");
                string prompt = $$"""
                    Input Theme start: "{{input}}" Input Theme end.
                    Provide the theme based on the input theme provided and follow guidelines provided and suggest similar theme that will be useful for the brand sites, use the above json theme content as the base theme which is used by the tenant and provide suggestion.
                    Also specifically target the font color only.
                    Provide only the modified json properties with the same hierarchical structure (parent child relationship should match input) in the response targeted the font color only in same input theme format and structure.
                    Don't provide any other information apart from json structure, generate the 4 theme array structure.
                """;

                history.AddUserMessage(prompt);
                var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
                var result = await kernel.InvokePromptAsync(prompt, new(executionSettings));

                string fullMessage = result.ToString();
                var mainTheme = JsonConvert.DeserializeObject<ThemeUpdated>(globalTheme);
                var currentSiteTheme = JsonConvert.DeserializeObject<ThemeUpdated>(siteTheme);

                _cacheService.Set(mainThemecacheKey, mainTheme);
                var themeList = ProcessAITheme(fullMessage, mainTheme, model.Brand, currentSiteTheme);
                _cacheService.Set(cacheKey, themeList);

                return Ok(JsonConvert.SerializeObject(themeList));
            }
        }

        [Route("GetSiteTheme")]
        public async Task<IActionResult> GetSiteThemeAsync()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"Theme\mock.json");

            var jsonContent = System.IO.File.ReadAllText(path);
            // Deserialize into an object
            var jsonData = JsonConvert.DeserializeObject(jsonContent);

            // Serialize without indentation (compact JSON)
            var compactJson = JsonConvert.SerializeObject(jsonData, Formatting.None);

            return Ok(compactJson);
        }

        #endregion

        #region private method
        /// <summary>
        /// Provide the theme based on the user prompt and update the theme with the user requested changes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        private async Task<ThemesList> GetThemeFromUserPromptAsync(RequestModel model)
        {
            ThemesList themeList = null;
            var requestArray = new[] { "Sitethemes", model?.Brand, model?.Language, model?.DeviceId };
            string cacheKey = $"{string.Join("_", requestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";
            var mainThemerequestArray = new[] { "MainTheme", model?.Brand, model?.Language, model?.DeviceId };
            string mainThemecacheKey = $"{string.Join("_", mainThemerequestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";

            var executionSettings = new AzureOpenAIPromptExecutionSettings
            {
                ResponseFormat = typeof(ThemeUpdated)
            };

            if (model != null && !string.IsNullOrEmpty(model.ThemeId))
            {
                if (_cacheService.TryGetValue(cacheKey, out ThemesList cachedTheme) &&
                    cachedTheme.templates != null &&
                    cachedTheme.templates.Count > 0)
                {
                    var userTheme = cachedTheme.templates.Find(p => p.TemplateId == model.ThemeId);
                    if (!userTheme.Equals(default(ThemeUpdated)))
                    {
                        ChatHistory history = new ChatHistory();
                        string input = JsonConvert.SerializeObject(userTheme);

                        string prompt = $$"""
                            You are a theme editor and you will receive the theme as input and just update the user requested changes in the provided theme.
                            User input theme: {{input}} and send me only the modified json properties with the same hierarchical structure (parent-child relationship should match input) in the response.
                            {{model.UserPrompt}}
                        """;
                        history.AddUserMessage(prompt);
                        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
                        var result = await kernel.InvokePromptAsync(prompt, new(executionSettings));

                        string fullMessage = result.ToString();
                        if (_cacheService.TryGetValue(mainThemecacheKey, out ThemeUpdated cachedMainTheme))
                        {
                            ThemeUpdated siteTheme = new ThemeUpdated();
                            themeList = ProcessAITheme(fullMessage, cachedMainTheme, model.Brand, siteTheme, true);
                            _cacheService.Set(cacheKey, themeList);
                        }
                    }
                }

            }
            return themeList;
        }
        /// <summary>
        /// Getting the Flashy image based on the events configured from the cms
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        private async Task<IActionResult> GetFlashImageBasedOnEventsAsync(RequestModel model)
        {
            var dallE = kernel.GetRequiredService<ITextToImageService>();
            string prompt = $$"""

                     You are the image generator, based on the user input generate the single .gif flash image, instead of a collage.
                    
                     user input:{{model.UserPrompt}}
                    generate image with animated.gif extension
                    """;

            var executionSettings = new OpenAIPromptExecutionSettings
            {
                MaxTokens = 256,
                Temperature = 1,
                ResponseFormat = typeof(ThemeUpdated)
            };
            // Use DALL-E 3 to generate an image. OpenAI in this case returns a URL 
            var imageUrl = await dallE.GenerateImageAsync(prompt.Trim(), 1024, 1024);
            return Ok(imageUrl);

        }
        /// <summary>
        /// Process the AI generated theme and merge it with the main theme to provide theme list
        /// </summary>
        /// <param name="aiGeneratedContent"></param>
        /// <param name="maintheme"></param>
        /// <param name="brandname"></param>
        /// <param name="isUserPrompt"></param>
        /// <returns></returns>
        private ThemesList ProcessAITheme(string aiGeneratedContent, ThemeUpdated maintheme, string brandname,ThemeUpdated SiteTheme, bool isUserPrompt = false)
        {
            string output = "";
            JObject jsonObject = JObject.FromObject(maintheme);
            var themeList = new List<ThemeUpdated>();
            List<JObject> list = new List<JObject>();
            ThemesList aithemeList = new();
            List<ThemeUpdated> data = new List<ThemeUpdated>();
            int i = 0;
            if (!isUserPrompt)
            {
                aithemeList = JsonConvert.DeserializeObject<ThemesList>(aiGeneratedContent);

                data = aithemeList.templates.Select(obj =>
                {
                    obj.TemplateId = i.ToString();
                    obj.brand_name = brandname;
                    i++;
                    return obj;
                }).ToList();
                aithemeList = new ThemesList() { templates = data };
            }
            else
            {
                aithemeList.templates = new List<ThemeUpdated>() { JsonConvert.DeserializeObject<ThemeUpdated>(aiGeneratedContent) };

            }
            foreach (ThemeUpdated item in aithemeList.templates)
            {
                JObject siteTheme = JObject.FromObject(item);

                jsonObject.Merge(siteTheme, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Merge,
                    MergeNullValueHandling = MergeNullValueHandling.Ignore
                });
                list.Add(jsonObject);
                jsonObject = JObject.FromObject(maintheme);

            }
            data = new List<ThemeUpdated>();
            foreach (var item in list)
            {
                data.Add(item.ToObject<ThemeUpdated>());
            }
            ThemesList themesList = new ThemesList()
            {
                mainTheme = !SiteTheme.Equals(default(ThemeUpdated))? SiteTheme:maintheme,
                templates = data
            };

            return themesList;
        }        
        private SiteLevelSettings GetSiteSettings(string siteName, string brand)
        {
            string cacheKey = $"Sitesettings_{siteName}_{brand}";
            SiteLevelSettings siteLevelSettings = new SiteLevelSettings();
            //await _wrapper.PostAsync<>();
            if (_cacheService.TryGetValue(cacheKey, out SiteLevelSettings cachedSiteLevelSettings) && cachedSiteLevelSettings !=null)                  
            {
                return cachedSiteLevelSettings;
            }
            else
            {
                //TODO fetch the site level settings from the cms
                _cacheService.Set(cacheKey, siteLevelSettings);
            }
            return siteLevelSettings;
        }
       
        #endregion

    }
}
