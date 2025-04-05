using System.ComponentModel.DataAnnotations;

namespace SemanticKernalApplication.WebAPI.Models
{
    public class RequestModel
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public string ScreenName { get; set; }
        public string SiteName { get; set; }

        [Required]
        public string DeviceId { get; set; }
        public string UserPrompt { get; set; }
        public string EventDate { get; set; }
        public string ThemeId { get; set; }

        public string Language { get; set; } = "en";

        public string BrowserId { get; set; }


    }

}
