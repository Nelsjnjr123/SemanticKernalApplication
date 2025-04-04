using Newtonsoft.Json;

namespace SemanticKernalApplication.Models
{
    public class NewThemeData
    {
        public List<NewTheme> data { get; set; }
    }
    public class NewTheme
    {
        [JsonProperty("themeName")]
        public string ThemeName { get; set; }

        [JsonProperty("primaryColor")]
        public string PrimaryColor { get; set; }

        [JsonProperty("secondaryColor")]
        public string SecondaryColor { get; set; }

        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("button")]
        public Button1 Button { get; set; }

        [JsonProperty("typography")]
        public Typography1 Typography { get; set; }

        [JsonProperty("spacing")]
        public Spacing1 Spacing { get; set; }
    }
    public class Button1
    {
        [JsonProperty("bgColor")]
        public string BgColor { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("hoverBgColor")]
        public string HoverBgColor { get; set; }
    }



    public class Spacing1
    {
        [JsonProperty("padding")]
        public string Padding { get; set; }

        [JsonProperty("margin")]
        public string Margin { get; set; }
    }

    public class Typography1
    {
        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        [JsonProperty("headingFontSize")]
        public string HeadingFontSize { get; set; }

        [JsonProperty("bodyFontSize")]
        public string BodyFontSize { get; set; }
    }
}




// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
