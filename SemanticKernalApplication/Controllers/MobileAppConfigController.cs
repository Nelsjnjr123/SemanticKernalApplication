using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace SemanticKernalApplication.WebAPI.Controllers
{
    public class MobileAppConfigController : BaseApiController
    {
        #region variable
        readonly IGraphQLRepository _graphQLRepository;
        #endregion

        #region contructor
        public MobileAppConfigController(IGraphQLRepository graphQLRepository)
        {
            _graphQLRepository = graphQLRepository;
        }
        #endregion

        #region action methods

        [HttpGet]
        [Route("Configurations")]
        public async Task<IActionResult> GetMobileAppConfigurations()
        {
            var results = await _graphQLRepository.GetMobileAppConfigurations();
            var response = new ApiResponseModel<MobileAppConfigResponseModel>(results);

            return Ok(response);
        }

        [HttpGet]
        [Route("Dictionary")]
        public async Task<IActionResult> GetMobileAppDictionary()
        {
            var results = await _graphQLRepository.GetMobileAppDictionary();
            var response = new ApiResponseModel<MobileAppDictionaryResponseModel>(results);

            return Ok(response);
        }

        #endregion

    }
}
