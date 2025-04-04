
using Newtonsoft.Json.Linq;

namespace SemanticKernalApplication.WebAPI.Models
{
    public class SitecoreLayoutModel
    {
        public JToken PlaceholderData { get; set; }
        public JToken MobilePlaceholderData { get; set; }
        public JToken FieldData { get; set; }
        public string TemplateId { get; set; }
        public string PageUrl { get; set; }
 
        
    }
}
