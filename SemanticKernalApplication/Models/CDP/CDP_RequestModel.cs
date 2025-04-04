using SemanticKernalApplication.WebAPI.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SemanticKernalApplication.WebAPI.Models.CDP
{
    public class CDP_RequestModel
    {
        public string BrowserId { get; set; }
        public string Type { get; set; }
        public string EventType { get; set; }
        public string OriginPage { get; set; }
        public string DestinationPage { get; set; }
        public string EventName { get; set; }
        public string EventId { get; set; }
        public string Personna { get; set; }
        public string SFID { get; set; }
    }
    public class CDP_GuestDetails
    {
        [JsonPropertyName("guestRef")]
        public string GuestRef { get; set; }
        [JsonPropertyName("guestType")]
        public string GuestType { get; set; }
    }
    public class CDP_DataExtensionRequestBaseModel
    {
        #region These properties will be used to get the guestRef Id  

        [Required]
        [JsonPropertyName("channelName")]
        public string ChannelName { get; set; } = "WEB";

        [Required]
        [NotDefault]
        [JsonPropertyName("browserId")]
        public string BrowserId { get; set; }

        #endregion
    }


    //Reference: https://doc.sitecore.com/cdp/en/developers/api/guest-data-extension-rest-api.html
    public class CDP_CreateDataExtensionRequestModel : CDP_DataExtensionRequestBaseModel
    {
        //[JsonPropertyName("format")]
        //public string Format { get; set; } = "HTML";

        //Note: We have added flexibility to add data extension by simply passing the extension name and attributes(key-value) details,
        //      which means we have to be very careful while adding new and it should be defined from different channels(like WEB, MOBILE_APP).
        [Required]
        [JsonPropertyName("dataExtensionName")]
        public string DataExtensionName { get; set; }   // Example: extEmailPreferences

        /// <summary>
        /// Pass objects like:
        //  [{"CRM_ID", 12345}, {"Order_ID": 4567}, {"Order_Status": "PURCHASED"}]
        /// </summary>
        [Required]
        [JsonPropertyName("dataExtensionAttributes")]
        public List<KeyWithDynmicValue> DataExtensionAttributes { get; set; }

        //[JsonPropertyName("shortDescription")]
        //public string ShortDescription { get; set; }

        //[JsonPropertyName("longDescription")]
        //public string LongDescription { get; set; }
    }

    public class KeyWithDynmicValue
    {
        [Required]
        [JsonPropertyName("key")]
        public string Key { get; set; }

        //TODO: We might need to add some constraints for value (currently it allows any object to pass)
        [Required]
        [JsonPropertyName("value")]
        public object Value { get; set; }
    }
}
