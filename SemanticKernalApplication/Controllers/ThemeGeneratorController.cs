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

namespace SemanticKernalApplication.Controllers
{
    public class ThemeGeneratorController : Controller
    {
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
        public async Task<IActionResult> GetTheme()
        {
#pragma warning disable SKEXP0001, SKEXP0010

            var kernel = GetKernel();
            ChatHistory history = [];
            string input = "Generate a flutter app theme in json format, which will be used to generate the dynamic theme based on the json properties,The json file should contain the following properties: primary color, secondary color, background color, text color, button default state color, button hover state color, typography font name, typography heading size, typography body text size, spacing padding size and spacing margin size. The json file should be in a valid format and should not contain any additional information or comments.";
            var fileData = System.IO.File.ReadAllLines("C:\\Users\\HP\\source\\repos\\SemanticKernalApplication\\SemanticKernalApplication\\Theme\\TenantB.json")
                           .ToList();
            fileData.ForEach(line => input += line);
            string themedata = "";
            fileData.ForEach(line => themedata += line);
            string prmopt = $$"""

                        Input Theme start: "{{input}}"   Input Theme end. 
                        
                        Provide the theme based on the input theme provided and follow guidelines provided and suggest similar theme that will be useful for the 
                        brand sites, use the above json theme content as the base theme which is used by the tenant and provide suggestion.

                        
                       
                      Always Generate the 4 json with like json structure as below
                      
                     {
                      "brand": {
                        "typography": {
                          "fontFamily": "Roboto"
                          
                          },
                          "body": {
                            "fontSize": 16,
                            "fontWeight": "regular",
                            
                          },
                          "caption": {
                            "fontSize": 12,
                            "fontWeight": "regular",
                           
                          },
                          "button": {
                            "fontSize": 14,
                            "fontWeight": "medium",
                           
                            "fontFamily": "Montserrat"
                          }
                        },
                        "spacing": {
                          "small": 8,
                          "medium": 16,
                          "large": 24,
                          "xlarge": 32
                        }  
                      }
                    }
                      
                     Also specifically target the font color, spacing and font name and only.
                      Provide only the modified json properties with the same hierarchical structure(parent child relationship should match input) in the response targeted the font color, spacing and font name and only in same input theme format and structure
                    , dont provide any other information apart from json structure.
                    """;
            history.AddUserMessage(prmopt);
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            var result = chatCompletionService.GetStreamingChatMessageContentsAsync(history, kernel: kernel);

            string fullMessage = "";

            await foreach (var content in result)
            {
                Console.Write(content);
                fullMessage += content;
            }

            var mainTheme = JsonConvert.DeserializeObject<ThemeModel>(themedata);
            return Ok(ProcessAITheme(fullMessage, mainTheme));
        }
        public async Task<IActionResult> GetThemeFromUserPrompt(String prompt)
        {
#pragma warning disable SKEXP0001, SKEXP0010

            var endpoint = "https://testopenaiforxmc.openai.azure.com/";
            var key = "3FL54ElYA2wLKoygrNRvNDUJvQVVvSR7zGVgLpomlHOPGehxGOkRJQQJ99BDACYeBjFXJ3w3AAABACOGsdx7";

            var builder = Kernel.CreateBuilder();
            builder.AddAzureOpenAIChatCompletion(
                     "gpt-4o",   // Azure OpenAI Deployment Name
                     endpoint,  // Azure OpenAI Endpoint
                     key);      // Azure OpenAI Key

            var kernel = builder.Build();
            ChatHistory history = [];
            string input = "Generate a flutter app theme in json format, which will be used to generate the dynamic theme based on the json properties,The json file should contain the following properties: primary color, secondary color, background color, text color, button default state color, button hover state color, typography font name, typography heading size, typography body text size, spacing padding size and spacing margin size. The json file should be in a valid format and should not contain any additional information or comments.";
            System.IO.File.ReadAllLines("C:\\Users\\HP\\source\\repos\\SemanticKernalApplication\\SemanticKernalApplication\\Theme\\TenantA.json")
                          .ToList().ForEach(line => input += line);
            string prmopt = $$"""
                        You are a theme generator, usually generating application or website site theme, you will receive the input theme from the user and provide 5 theme suggested based on the brand guidelines of the tenant
                        Brand guidelines : the Dark Mode Theme is designed for readability and accessibility in low-light environments. The primary color (#ff6600) is used for key brand elements, while the secondary color (#0055ff) provides contrast. The background (#121212) ensures a dark base, with text (#ffffff) providing high contrast. Buttons follow a structured styling: the default state has a #ff6600 background with white text, while the hover state darkens to #e65c00. Typography is consistent with the Inter, sans-serif font; headings use 2rem size, while body text is set at 1rem. Spacing follows a structured system with 16px padding and 8px margins for a balanced layout. All elements should maintain accessibility standards, ensuring a minimum 4.5:1 contrast ratio
                        Provide the theme based on the tenant and follow guidelines provided and suggest similar theme that will be useful for the brand sites, use the below json theme content as the base theme which is used by the tenant and provide suggestion
                        {{input}}
                       
                    Generate the 4 json file with the newly created theme and specifically target the font color, spacing and font name and only provide this 3 json properities as response in .json file, dont provide any other information apart from json structure"
                    {{prompt}}
                    """;
            history.AddUserMessage(prmopt);
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

            var result = chatCompletionService.GetStreamingChatMessageContentsAsync(history, kernel: kernel);

            string fullMessage = "";

            await foreach (var content in result)
            {
                Console.Write(content);
                fullMessage += content;
            }
            return Ok(ProcessAITheme(fullMessage,null));
        }

        private ThemeModelData ProcessAITheme(string aiGeneratedContent,ThemeModel maintheme)
        {
            string target1 = "```json";
            aiGeneratedContent = aiGeneratedContent.Substring(aiGeneratedContent.IndexOf(target1));
            string lineToRemovePrefix = "###";

            // Split the string into lines
            string[] lines = aiGeneratedContent.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None);

            // Filter out the lines that start with the specified prefix
            string[] filteredLines = lines
                .Where(line => !line.TrimStart().StartsWith(lineToRemovePrefix))
                .ToArray();

            // Join the remaining lines back into a single string
            string result = string.Join(Environment.NewLine, filteredLines);
            var splitedTheme = result.Split(target1).ToList();
            var joinedTheme = string.Join(",", splitedTheme);
            joinedTheme = joinedTheme.Replace("```", null);
            joinedTheme = joinedTheme.TrimStart(',').TrimEnd(',');
            string output = "";
            if (joinedTheme.IndexOf("[")>0)
            {
                output = "{\"data\":" + joinedTheme + "}";
                

            }
            else
            {
                output = "{\"data\":[" + joinedTheme + "]}";
            }

       
            var aithemeList= JsonConvert.DeserializeObject<ThemeModelData>(output);

            JObject jsonObject = JObject.FromObject(maintheme);
            var themeList = new List<ThemeModel>();

            List<JObject> list = new List<JObject>();   


            foreach (var item in aithemeList.data)
            {
                JObject siteTheme = JObject.FromObject(item);

                jsonObject.Merge(siteTheme, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union,
                    MergeNullValueHandling = MergeNullValueHandling.Ignore
                });
                list.Add(jsonObject);
            }
            return null;
        }


    }
}
