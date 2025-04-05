using System.ComponentModel.DataAnnotations;

namespace SemanticKernalApplication.WebAPI.Models
{
    public class RequestModel
    {
        [Required]
        public string Brand { get; set; }
        /// <summary>
        /// PageName
        /// </summary>
        /// <example>Home</example>
        [Required]
        public string ScreenName { get; set; }
        /// <summary>
        /// Sitecore item GUID for fetching item by graphql
        /// </summary>
        /// <example>{34EFCBB3-CF94-4752-B14D-08CE210D8A73}</example>
        public string Id { get; set; }
        [Required]
        public string DeviceId { get; set; }
        public string UserPrompt { get; set; }
        public string ThemeId { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        /// <example>en</example>
        public string Language { get; set; } = "en";  

        public string BrowserId { get; set; }
        public string OriginPage { get; set; }
       
        public string Email { get; set; }
   
    }
    public class FilterOptions
    {
        public bool IsKeywordFilter { get; set; } = false;
        public string FilterField { get; set; }
        public List<string> FilterOptionId { get; set; }
        public List<FilterDetails> FilterDetails { get; set; }
        public string Category { get; set; }
        public string ServiceNo { get; set; }
        public string ServiceId { get; set; }
    }
    public class FilterDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string SearchKeyword { get; set; }
    }
}
