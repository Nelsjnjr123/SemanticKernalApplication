namespace SemanticKernalApplication.WebAPI.Models
{
    public class BaseResponseModel
    {
        public string VersionNumber { get; set; }
    }

    public class MobileAppConfigResponseModel : BaseResponseModel
    {
        public Dictionary<string, string> ConfigDetails { get; set; }
    }

    public class MobileAppDictionaryResponseModel : BaseResponseModel
    {
        public Dictionary<string, string> DictionaryDetails { get; set; }
    }
}
