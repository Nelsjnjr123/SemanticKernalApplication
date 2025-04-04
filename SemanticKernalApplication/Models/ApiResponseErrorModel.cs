namespace SemanticKernalApplication.WebAPI.Models
{
    public class ApiResponseErrorModel
    {
        public ApiResponseErrorModel(string key, string errorMessage)
        {
            Key = key;
            ErrorMessage = errorMessage;
        }

        public string Key { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class FailedEntityErrors
    {
        public object Entity { get; set; }
        public List<ApiResponseErrorModel> Errors { get; set; }
    }

    public class ModelValidationErrors
    {
        public List<FailedEntityErrors> FailedEntities { get; set; }
    }
}
