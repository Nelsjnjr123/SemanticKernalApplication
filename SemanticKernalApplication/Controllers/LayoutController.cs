using SemanticKernalApplication.Core;
using SemanticKernalApplication.WebAPI.Attributes;

using SemanticKernalApplication.WebAPI.Helpers;
using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.Models;
using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SemanticKernalApplication.WebAPI.Controllers
{
    /// <summary>
    /// Layout from sitecore processed
    /// </summary>
    // [Route("api/[controller]/v{version:apiVersion}")]
  
 
    public class LayoutController : BaseApiController
    {
        #region variable
        readonly ILayoutRepository _layoutRepository;
        #endregion

        #region contructor    

        public LayoutController(ILayoutRepository layoutRepository)
        {
            _layoutRepository = layoutRepository;
        }
        #endregion

        /// <summary>
        /// Get page layout with all components
        /// </summary>
        /// <remarks>
        /// Sample request:       
        ///  POST /Layout/GetPageComponents
        /// </remarks>       

        /// <param name="model">Request Model</param>
        /// <returns>Page Components</returns>
        [HttpPost]
  

        [Route("GetPageComponents")]
     
        public async Task<IActionResult> GetPageComponents([FromBody]RequestModel model)
        {
            try
            {
           
                
                var results = await _layoutRepository.GetPageComponents(model);
                BaseAppResponse baseAppResponse = (BaseAppResponse)results;
                if (baseAppResponse != null && baseAppResponse.SectionComponents.Count > 0)
                {
                    return GetResponse<object>(new ApiResponseModel<object>()
                    {
                        Errors = new List<ApiResponseErrorModel>(),
                        IsSuccess = true,
                        Data = baseAppResponse,
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Message = String.Empty
                    });
                }
                else
                {
                    return GetResponse<object>(new ApiResponseModel<object>()
                    {
                        Errors = new List<ApiResponseErrorModel>(),
                        IsSuccess = false,
                        Data = new AppComponents(),
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        Message = Constants.HttpStatusCode400
                    });

                }
            }
            catch (Exception ex)
            {
                return GetResponse<object>(new ApiResponseModel<object>()
                {
                    Errors = new List<ApiResponseErrorModel>(),
                    IsSuccess = false,
                    Data = new AppComponents(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = Constants.HttpStatusCode500
                });
            }
        }
        /// <summary>
        /// Getting screen details for the all pages configured in the settings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ScreenDetails")]
        [NonAction]
        public async Task<IActionResult> GetMobileAppScreenDetails()
        {
            var requestModel = new RequestModel
            {
                ScreenName = Constants.ScreenName.SettingsPageScreen
            };
            return await GetPageComponents(requestModel);
        }
    }
}
