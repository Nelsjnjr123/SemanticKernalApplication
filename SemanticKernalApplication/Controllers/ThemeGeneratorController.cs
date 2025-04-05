using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using System.ComponentModel;

using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Embeddings;
using Microsoft.SemanticKernel.TextToImage;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using RestSharp;
using Newtonsoft.Json;
using SemanticKernalApplication.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;
using SemanticKernalApplication.WebAPI.Models;
using SemanticKernalApplication.WebAPI.Controllers;
using System.Net;
using System.Text;
using Microsoft.Extensions.Options;
using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Respositories;
using SemanticKernalApplication.Services.Services;
using SemanticKernalApplication.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Nodes;

namespace SemanticKernalApplication.Controllers
{
    public class ThemeGeneratorController : BaseApiController
    {
        #region variable        
        IGraphQLService _graphQLService;
        private readonly ILogger<LayoutRepository> _logger;
        private readonly IModelMapperService _modelMapper;
        private readonly IBaseScreenMappingService _baseScreenMapping;
        private readonly ICacheService _cacheService;
        private readonly IOptions<SemanticKernalApplicationSettings> _options;

        //private readonly IAlgoliaService _algoliaService;
        #endregion
        public ThemeGeneratorController(IGraphQLService graphQLService, ILogger<LayoutRepository> logger,
            IModelMapperService modelMapper, IBaseScreenMappingService baseScreenMapping,
            ICacheService cacheService, IOptions<SemanticKernalApplicationSettings> options)
        {
            _graphQLService = graphQLService;
            _logger = logger;
            _modelMapper = modelMapper;
            _baseScreenMapping = baseScreenMapping;
            _cacheService = cacheService;

            _options = options;
        }
        private readonly IMemoryCache _memoryCache;

        Kernel GetKernel()
        {
            var builder = Kernel.CreateBuilder();
            builder.AddAzureOpenAIChatCompletion(
                     "gpt-4o",   // Azure OpenAI Deployment Name
                     "https://testopenaiforxmc.openai.azure.com/",  // Azure OpenAI Endpoint
                     "3FL54ElYA2wLKoygrNRvNDUJvQVVvSR7zGVgLpomlHOPGehxGOkRJQQJ99BDACYeBjFXJ3w3AAABACOGsdx7");      // Azure OpenAI Key

            return builder.Build();
        }

        [Route("ThemeGenerator")]
        [HttpPost]
        public async Task<IActionResult> GetTheme([FromBody] RequestModel model)
        {
            if (!String.IsNullOrEmpty(model.UserPrompt))
            {
                var result = await GetThemeFromUserPromptAsync(model);
                return Ok(JsonConvert.SerializeObject(result));
            }
            else
            {
#pragma warning disable SKEXP0001, SKEXP0010
                var requestArray = new[] { "Sitethemes", model?.Brand, model?.Language, model?.DeviceId };
                string cacheKey = $"{string.Join("_", requestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";
                var mainThemerequestArray = new[] { "MainTheme", model?.Brand, model?.Language, model?.DeviceId };
                string mainThemecacheKey = $"{string.Join("_", mainThemerequestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";
                var kernel = GetKernel();
                var executionSettings = new AzureOpenAIPromptExecutionSettings
                {
                    ResponseFormat = typeof(ThemesListData)
                };
                ChatHistory history = [];
                string input = "Generate a flutter app theme in json format, which will be used to generate the dynamic theme based on the json properties,The json file should contain the following properties: primary color, secondary color, background color, text color, button default state color, button hover state color, typography font name, typography heading size, typography body text size, spacing padding size and spacing margin size. The json file should be in a valid format and should not contain any additional information or comments.";
                string path = Path.Combine(Directory.GetCurrentDirectory(), @"Theme\TenantC.json");

                var fileData = System.IO.File.ReadAllLines(path)
                               .ToList();
                fileData.ForEach(line => input += line);
                string themedata = "";
                fileData.ForEach(line => themedata += line);
                history.AddSystemMessage("You are theme generator and always mandatory for you to generate the 4 theme array structure.");
                string prmopt = $$"""

                        Input Theme start: "{{input}}"   Input Theme end. 
                        
                        Provide the theme based on the input theme provided and follow guidelines provided and suggest similar theme that will be useful for the 
                        brand sites, use the above json theme content as the base theme which is used by the tenant and provide suggestion.
 
                       

                      Also specifically target the font color only.
                      Provide only the modified json properties with the same hierarchical structure(parent child relationship should match input) in the response targeted the font color only in same input theme format and structure.
                     dont provide any other information apart from json structure, generate the 4 theme array structure.
                    """;
                history.AddUserMessage(prmopt);
                var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
                var result = await kernel.InvokePromptAsync(prmopt, new(executionSettings));

                //var result = chatCompletionService.GetStreamingChatMessageContentsAsync(history, kernel: kernel);

                string fullMessage = result.ToString();
                var mainTheme = JsonConvert.DeserializeObject<ThemeUpdated>(themedata);
                _cacheService.Set(mainThemecacheKey, mainTheme);
                var themeList = ProcessAITheme(fullMessage, mainTheme, model.Brand);
                _cacheService.Set(cacheKey, themeList);

                return Ok(JsonConvert.SerializeObject(themeList));
            }

        }
        [NonAction]
        public async Task<List<JObject>> GetThemeFromUserPromptAsync(RequestModel model)
        {
#pragma warning disable SKEXP0001, SKEXP0010

            var requestArray = new[] { "Sitethemes", model?.Brand, model?.Language, model?.DeviceId };
            string cacheKey = $"{string.Join("_", requestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";
            var mainThemerequestArray = new[] { "MainTheme", model?.Brand, model?.Language, model?.DeviceId };
            string mainThemecacheKey = $"{string.Join("_", mainThemerequestArray.Where(s => !string.IsNullOrEmpty(s)))?.ToLowerInvariant()}";
            var kernel = GetKernel();
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"Theme\TenantB.json");
            var executionSettings = new AzureOpenAIPromptExecutionSettings
            {
                ResponseFormat = typeof(ThemeUpdated)
            };
            var fileData = System.IO.File.ReadAllLines(path)
                           .ToList();

            string themedata = "";
            fileData.ForEach(line => themedata += line);
            if (model != null && !String.IsNullOrEmpty(model.ThemeId))
            {

                if (_cacheService.TryGetValue(cacheKey, out List<JObject> cachedTheme))
                {
                    List<ThemeUpdated> listOfMyClasses = cachedTheme
                    .Select(jObject => jObject.ToObject<ThemeUpdated>())
                    .ToList();

                    var userTheme = listOfMyClasses.Where(p => p.TemplateId == model.ThemeId);
                    if (userTheme != null)
                    {
                        ChatHistory history = [];
                        string input = JsonConvert.SerializeObject(userTheme);

                        string prmopt = $$"""
                        
                       Your a theme editor and you will receive the theme as input and just update the user requested changes in the provided theme.
                       user :input theme {{input}} and sent me only the modified json properties with the same hierarchical structure(parent child relationship should match input) in the response.
                       {{model.UserPrompt}}
                       """;
                        history.AddUserMessage(prmopt);
                        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
                        var result = await kernel.InvokePromptAsync(prmopt, new(executionSettings));

                        string fullMessage = result.ToString();
                        if (_cacheService.TryGetValue(mainThemecacheKey, out ThemeUpdated cachedMainTheme))
                        {
                            var themeList = ProcessAITheme(fullMessage, cachedMainTheme, model.Brand,true);
                            _cacheService.Set(cacheKey, themeList);
                            return themeList;
                        }
                        return null;

                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        private List<JObject> ProcessAITheme(string aiGeneratedContent, ThemeUpdated maintheme, string brandname, bool isUserPrompt = false)
        {
            string target1 = "```json";
            // aiGeneratedContent = aiGeneratedContent.Substring(aiGeneratedContent.IndexOf(target1));
            //string lineToRemovePrefix = "###";

            //// Split the string into lines
            //string[] lines = aiGeneratedContent.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None);

            //// Filter out the lines that start with the specified prefix
            //string[] filteredLines = lines
            //    .Where(line => !line.TrimStart().StartsWith(lineToRemovePrefix))
            //    .ToArray();

            //// Join the remaining lines back into a single string
            //string result = string.Join(Environment.NewLine, filteredLines);
            //var splitedTheme = result.Split(target1).ToList();
            // var joinedTheme = string.Join(",", splitedTheme);
            var joinedTheme = aiGeneratedContent.Replace("```", null);
            joinedTheme = joinedTheme.TrimStart(',').TrimEnd(',');
            string output = "";
            //if (joinedTheme.IndexOf("[") > 0)
            //{
            //    output = "{\"data\":" + joinedTheme + "}";


            //}
            //else
            //{
            //    output = "{\"data\":[" + joinedTheme + "]}";
            //}
            ThemesList aithemeList = new();
            if (!isUserPrompt)
                aithemeList = JsonConvert.DeserializeObject<ThemesList>(aiGeneratedContent);
            else
            {
                aithemeList.templates= new List<ThemeUpdated>() { JsonConvert.DeserializeObject<ThemeUpdated>(aiGeneratedContent) };
            }

            JObject jsonObject = JObject.FromObject(maintheme);
            //JObject jsonObject2 = JObject.FromObject(maintheme);
            //JObject jsonObject3 = JObject.FromObject(maintheme);
            //JObject jsonObject4 = JObject.FromObject(maintheme);          
            var themeList = new List<ThemeUpdated>();

            List<JObject> list = new List<JObject>();


            int i = 0;
            var data = aithemeList.templates.Select(obj =>
            {
                obj.TemplateId = i.ToString();
                obj.brand_name = brandname;
                i++;
                return obj;
            }).ToList();
            var ddd = new ThemesList() { templates = data };
            //aithemeList.templates.ForEach(p => p.TemplateId = i++);
            foreach (ThemeUpdated item in ddd.templates)
            {
                JObject siteTheme = JObject.FromObject(item);

                jsonObject.Merge(siteTheme, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Merge,
                    MergeNullValueHandling = MergeNullValueHandling.Ignore
                });
                list.Add(jsonObject);
                jsonObject = JObject.FromObject(maintheme);
                i++;
            }
            return list;
        }


    }
}
