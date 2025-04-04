using Newtonsoft.Json;

namespace SemanticKernalApplication.WebAPI.Models.CDP
{

    public class CDP_ResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("client_key")]
        public string Client_key { get; set; }
        [JsonProperty("ref")]
        public string Ref { get; set; }
        [JsonProperty("customer_ref")]
        public string Customer_ref { get; set; }
    }

    public class CDP_GuestReferenceResponseModel
    {
        [JsonProperty("guestRef")]
        public string GuestReferenceId { get; set; }
    }

    public class CDP_ApiResponseModel
    {
        public string Version { get; set; }
        public string BrowserId { get; set; }
        public string CustomerId { get; set; }
        public string Reference { get; set; }
    }
}
