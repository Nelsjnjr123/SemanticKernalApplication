using System.Text.Json.Serialization;

namespace SemanticKernalApplication.WebAPI.Models.Event
{
    public class EventRequestModel
    {
        [JsonPropertyName("requestType")]
        public string RequestType { get; set; }

        [JsonPropertyName("SFID")]
        public string SFID { get; set; }

        [JsonPropertyName("eventList")]
        public List<EventList> EventList { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("eventType")]
        public string EventType { get; set; }
        public string OriginPage { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Personna { get; set; }
        public string BrowserId { get; set; }

        #region SFMC
        public string FirstName { get; set; }
        #endregion
    }

    public class EventList
    {
        [JsonPropertyName("eventId")]
        public string EventId { get; set; }
        [JsonPropertyName("eventName")]
        public string EventName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("eventType")]
        public string EventType { get; set; }


        [JsonPropertyName("SFID")]
        public string SFID { get; set; }
        #region SFMC
        [JsonPropertyName("eventStartDate")]
        public string EventStartDate { get; set; }
        #endregion
    }

    public class EventCRMResponseModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("eventList")]
        public List<EventList> EventList { get; set; }
    }
}
