using SemanticKernalApplication.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace SemanticKernalApplication.Controllers
{
    /// <summary>
    /// Hooks events captured and processed
    /// </summary>
    public class HooksController : ControllerBase
    {
        #region variable
        IHooksRepository _hooksRepository;
        private readonly ILogger<HooksController> _logger;
        #endregion
        #region contructor
        public HooksController(IHooksRepository hooksRepository, ILogger<HooksController> logger)
        {
            _hooksRepository = hooksRepository;
            _logger = logger;
        }
        #endregion
        #region action methods
        /// <summary>
        /// Process the sitecore publish event item and store in algolia index
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>


        //[NonAction]
        //[HttpPost]
        //[Route("eventshooks")]
        //public async Task<bool> Events([FromBody] object events)
        //{
        //    var data = JObject.Parse(events.ToString());
        //    string json = data.ToString(Newtonsoft.Json.Formatting.None);
        //    return await _hooksRepository.ProcessHooksEventsAsync(json);
        //}

        /// <summary>
        /// ClearCache
        /// </summary>
        /// <param name="clearCache"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("clearcachehook")]
        public async Task<bool> ClearCache([FromBody] object clearCache)
        {
            var data = JObject.Parse(clearCache.ToString());
            string json = data.ToString(Newtonsoft.Json.Formatting.None);
            _logger.LogInformation($"Recieved Hook From Sitecore for Clearing Cache :: Request :: {json}");
            return await _hooksRepository.ProcessClearCacheHookAsync(json);
        }
        #endregion

    }
}
