namespace SemanticKernalApplication.WebAPI.Models
{
    /// <summary>
    /// Wrapper Model to get the response and if error message from the response
    /// </summary>
    /// <typeparam name="T">Response</typeparam>
    public class ApiResponseModel<T>
    {
        /// <summary>
        /// Expected output for the Request
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Status whether the request is success or failed
        /// </summary>
        public bool IsSuccess { get; set; } = false;

        /// <summary>
        /// List of errors if request failed
        /// </summary>
        public List<ApiResponseErrorModel> Errors { get; set; }

        public string Message { get; set; }
        public object StatusCode { get; set; }
        public string SubStatusCode { get; set; }

        public ApiResponseModel()
        { }

        public ApiResponseModel(T data, string message = null)
        {
            IsSuccess = true;
            Message = message;
            Data = data;
        }

        public void SetErrorResponse(string message)
        {
            IsSuccess = false;
            Message = message;
        }
    }
}
