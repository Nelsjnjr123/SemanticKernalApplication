using SemanticKernalApplication.Core;
using SemanticKernalApplication.WebAPI.Helpers;
using SemanticKernalApplication.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SemanticKernalApplication.WebAPI.Controllers
{
   
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[ApiVersion("1.0")]
    public abstract class BaseApiController : ControllerBase
    {
        //TODO: This can be removed and we should use CommonUtility.GenerateResponse() method
        [NonAction]
        protected IActionResult GetResponse<T>(ApiResponseModel<T> result)
        {
            var message = CommonUtility.GetMessage(result?.Message);
            if (result.IsSuccess)
            {
                return Ok(new ApiResponseModel<object>()
                {
                    Errors = new List<ApiResponseErrorModel>(),
                    IsSuccess = true,
                    Data = result.Data,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = message.message,
                    SubStatusCode = message.subStatusCode
                });
            }
            else
            {
                if ((HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.BadRequest ||
                    (HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.NotFound ||
                    (HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    var messageNotAcceptable = CommonUtility.GetMessage(Constants.HttpStatusCode400);
                    return BadRequest(new ApiResponseModel<object>()
                    {
                        Errors = new List<ApiResponseErrorModel>(),
                        IsSuccess = false,
                        Data = result.Data,
                        StatusCode =  Constants.AppCustomErrorCode,
                        Message = message.message ?? messageNotAcceptable.message,
                        SubStatusCode = message.subStatusCode ?? messageNotAcceptable.subStatusCode
                    });

                }
                else if ((HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.PartialContent)
                {
                    var messageNotAcceptable = CommonUtility.GetMessage(Constants.HttpStatusCode204);
                    return StatusCode(StatusCodes.Status206PartialContent, new ApiResponseModel<object>()
                    {
                        Errors = new List<ApiResponseErrorModel>(),
                        IsSuccess = false,
                        Data = result.Data,
                        StatusCode = System.Net.HttpStatusCode.PartialContent,
                        Message = message.message ?? messageNotAcceptable.message,
                        SubStatusCode = message.subStatusCode ?? messageNotAcceptable.subStatusCode
                    });
                }
                else if ((HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.NotAcceptable)
                {
                    var messageNotAcceptable = CommonUtility.GetMessage(Constants.HttpStatusCode204);
                    return StatusCode(StatusCodes.Status406NotAcceptable, new ApiResponseModel<object>()
                    {
                        Errors = new List<ApiResponseErrorModel>(),
                        IsSuccess = false,
                        Data = result.Data,
                        StatusCode = System.Net.HttpStatusCode.NotAcceptable,
                        Message = message.message ?? messageNotAcceptable.message,
                        SubStatusCode = message.subStatusCode ?? messageNotAcceptable.subStatusCode
                    });

                }
                else if ((HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var messageError = CommonUtility.GetMessage(Constants.HttpStatusCode500);
                    return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseModel<object>()
                    {
                        Errors = new List<ApiResponseErrorModel>(),
                        IsSuccess = false,
                        Data = result.Data,
                        StatusCode =  Constants.AppCustomErrorCode,
                        Message = message.message ?? messageError.message,
                        SubStatusCode = message.subStatusCode ?? messageError.subStatusCode

                    });
                }
            }
            return Ok(result);
        }
    }
}
