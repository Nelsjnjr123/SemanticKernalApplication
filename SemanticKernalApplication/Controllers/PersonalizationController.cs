using SemanticKernalApplication.Core;
using SemanticKernalApplication.WebAPI.Attributes;

using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models.CDP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SemanticKernalApplication.WebAPI.Controllers
{
    /// <summary>
    /// Personalization
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalizationController : BaseApiController
    {
        #region variable
        private readonly IOptions<SemanticKernalApplicationSettings> _options;
        private IPersonalizationRepository _personalizationRespository;

        #endregion

        #region constuctor
        public PersonalizationController(IPersonalizationRepository personalizationRespository, IOptions<SemanticKernalApplicationSettings> options)
        {
            _personalizationRespository = personalizationRespository;
            _options = options;
        }

        #endregion
        #region action method
        /// <summary>
        /// Getting the browser id for the new user or first time app opened
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getbrowserid")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBrowserId()
        {
            var result = await _personalizationRespository.GetBrowserIdAsync();
            return GetResponse(result);
        }

        /// <summary>
        /// triggering different types of events like (VIEW,IDENTITY,CUSTOMEVENT etc)
        /// </summary>
        /// <example>{
        ///   "browserId": "6a466904-0b4f-457e-971c-87c55015ad2d",
        ///    "channel": "MOBILE_APP",
        ///     "type": "ADD_TO_CALANDAR",
        ///     "language": "EN",
        ///     "currency": "AED",
        ///     "page": "Listing",
        ///     "pos": "SemanticKernalApplication_experience_edge",
        ///     "extensions": [
        ///     {
        ///       "name": "ext",
        ///       "key": "default",
        ///       "sfid": "",
        ///       "employeeId": "",
        ///       "bpNumber": "",
        ///       "deviceId": "ddddd",
        ///       "azureId": "",
        ///       "originPage":"Home",
        ///       "pageId":"{7a466904-0b4f-457e-971c-87c55015ad2d}",
        ///       "screenName":"WhatsOnListing",
        ///       "type":"Blog",
        ///      "extensions": [
        ///        {
        ///          "name": "ext",
        ///          "key": "default",
        ///          "sfid": "",
        ///          "employeeId": "",
        ///          "bpNumber": "",
        ///          "deviceId": "ddddd",
        ///          "azureId": "",
        ///          "filters": [
        ///            {
        ///              "Category": "Author",
        ///              "Filtercriteria": [
        ///                {
        ///                  "Id": "{75C247F8-8E5C-4716-999C-DC42A54D89AB}",
        ///                  "Name": "Author1"
        ///                },
        ///                {
        ///                  "Id": "{75C247F8-8E5C-4716-999C-DC42A54D89AB}",
        ///                  "Name": "Author2"
        ///                }
        ///              ]
        ///            }
        ///          ]}]"
        ///     }
        ///   ]
        /// }
        /// </example>
        /// <param name="model"></param>   
        /// <returns></returns>

        [HttpPost]
        [Route("events")]
       
        public async Task<IActionResult> TriggerEvents(CDP_RequestModel model)
        {
            CDP_EventModel request = new CDP_EventModel()
            {
                BrowserId = model.BrowserId,
                Channel = _options.Value?.CDPSettings.Channel,
                Currency = _options.Value?.CDPSettings.Currency,
                Language = _options.Value?.CDPSettings.Language,
                Page = model?.DestinationPage,
                Pos = _options.Value?.CDPSettings.Pos,
                Type = model?.Type ?? model?.EventType,
                SessionData = new CDP_Session()
                {
                    Guest_Type = model.Personna,
                    Is_logged_in = !String.IsNullOrEmpty(model.SFID) ? true : false,
                    Type = model.Type

                },
                Ext = new CDPBaseExtensions(){
                          Key=Constants.ExtensionKey,
                          Name=Constants.ExtensionName,
                          EventId=model.EventId,
                          EventName=model.EventName
                      }
                
            };
            var result = await _personalizationRespository.TriggerEventAsync(request,model?.BrowserId);
            return GetResponse(result);
        }
        /// <summary>
        /// Creating Guest data extension
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("data-extensions")]
      
        [AllowAnonymous]
        public async Task<IActionResult> TriggerDataExtensions(CDP_CreateDataExtensionRequestModel model)
        {
            var result = await _personalizationRespository.TriggerDataExtensionsAsync(model);
            return GetResponse(result);
        }
        #endregion
    }
}
