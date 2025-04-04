
using Newtonsoft.Json.Linq;

namespace SemanticKernalApplication.WebAPI.Models
{
    public class BuildModelParameter
    {
        public int count { get; set; }
        public JToken ListingResults { get; set; }
     
        public string ListingCacheKey { get; set; }
    }

}