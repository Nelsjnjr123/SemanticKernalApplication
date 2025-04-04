using Newtonsoft.Json;

namespace SemanticKernalApplication.WebAPI.Models
{
    public class MobileScreenResponseModelList
    {
        [JsonProperty("mobileScreens")]
        public List<MobileScreenResponseModel> MobileScreens { get; set; }
    }

    public class MobileScreenResponseModel
    {
        [JsonProperty("screenName")]
        public string ScreenName { get; set; }

        [JsonProperty("screenId")]
        public string ScreenId { get; set; }    // = Sitecore Item Id
    }

    //==== POCO classes to map GraphQL response ====
    public class MobileScreenList
    {
        public List<MobileScreen> MobileScreens { get; set; }
    }

    public class MobileScreen
    {
        [JsonProperty("fields")]
        public MobileScreenModel MobileScreenFields { get; set; }
    }

    public class MobileScreenModel
    {
        public Values ScreenName { get; set; }
        public LinkValues ScreenItem { get; set; }
    }
}
