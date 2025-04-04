
using Newtonsoft.Json;

namespace SemanticKernalApplication.WebAPI.Models.CDP
{
    public class CDP_EventModel : CDPBase
    {
        [JsonProperty("identifiers")]
        public Identifier[] Identifiers { get; set; }

        [JsonProperty("emails")]
        public List<string> Email { get; set; }

        [JsonProperty("firstName")]
        public string Firstname { get; set; }

        [JsonProperty("lastName")]
        public string Lastname { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
       
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }
        [JsonProperty("phoneNumbers")]
        public List<string> PhoneNumber { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("street")]
        public List<string> Street { get; set; }
        [JsonProperty("postCode")]
        public string ZipCode { get; set; }
      

    }

    public class Identifier
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
      
    } 

}
