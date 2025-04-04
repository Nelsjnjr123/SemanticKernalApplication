using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels
{
    public class PlaceholderComponents
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("componentName")]
        public string ComponentName { get; set; }
        [JsonProperty("dataSource")]
        public string DataSource { get; set; }
        [JsonProperty("fields")]
        public JToken Fields { get; set; }
        [JsonProperty("params")]
        public VariantParams Params { get; set; }
        [JsonProperty("experiences")]
        public JToken VariantExperiences { get; set; }

    }
    public class VariantParams
    {
        public string FieldNames { get; set; }
    }
    public class AppComponents
    {
        public dynamic Components { get; set; } = new object();
    }

}
