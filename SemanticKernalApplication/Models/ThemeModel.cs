using Newtonsoft.Json;

namespace SemanticKernalApplication.Models
{
    public class ThemeModelData
    {
        [JsonProperty("data")]
        public List<ThemeModel> data { get; set; }

    }
    public class ThemeModel
    {
        [JsonProperty("brand")]
        public Brand Brand { get; set; }
        [JsonProperty("themeid")]
        public string ThemeId { get; set; }

        [JsonProperty("themes")]
        public Themes Themes { get; set; }
    }
    public class Body
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }
    }

    public class BorderRadius
    {
        [JsonProperty("small")]
        public int Small { get; set; }

        [JsonProperty("medium")]
        public int Medium { get; set; }

        [JsonProperty("large")]
        public int Large { get; set; }
    }

    public class Brand
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public Logo Logo { get; set; }

        [JsonProperty("colors")]
        public Colors Colors { get; set; }

        [JsonProperty("typography")]
        public Typography Typography { get; set; }

        [JsonProperty("spacing")]
        public Spacing Spacing { get; set; }

        [JsonProperty("borderRadius")]
        public BorderRadius BorderRadius { get; set; }

        [JsonProperty("shadows")]
        public Shadows Shadows { get; set; }

        [JsonProperty("icons")]
        public Icons Icons { get; set; }

        [JsonProperty("components")]
        public Components Components { get; set; }
    }

    public class Button
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }

        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        [JsonProperty("default")]
        public Default Default { get; set; }

        [JsonProperty("secondary")]
        public Secondary Secondary { get; set; }
    }

    public class Caption
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }
    }

    public class Card
    {
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("borderRadius")]
        public int BorderRadius { get; set; }

        [JsonProperty("elevation")]
        public int Elevation { get; set; }
    }

    public class Colors
    {
        [JsonProperty("primary")]
        public string Primary { get; set; }

        [JsonProperty("secondary")]
        public string Secondary { get; set; }

        [JsonProperty("accent")]
        public string Accent { get; set; }

        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("warning")]
        public string Warning { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }
    }

    public class Components
    {
        [JsonProperty("button")]
        public Button Button { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }
    }

    public class Custom
    {
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("cardBackgroundColor")]
        public string CardBackgroundColor { get; set; }

        [JsonProperty("accentColor")]
        public string AccentColor { get; set; }
    }

    public class Dark
    {
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("cardBackgroundColor")]
        public string CardBackgroundColor { get; set; }

        [JsonProperty("accentColor")]
        public string AccentColor { get; set; }
    }

    public class Default
    {
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("borderRadius")]
        public int BorderRadius { get; set; }

        [JsonProperty("padding")]
        public Padding Padding { get; set; }
    }

    public class H1
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }
    }

    public class H2
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }
    }

    public class H3
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }
    }

    public class H4
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }
    }

    public class H5
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }
    }

    public class H6
    {
        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("lineHeight")]
        public double LineHeight { get; set; }
    }

    public class Headings
    {
        [JsonProperty("h1")]
        public H1 H1 { get; set; }

        [JsonProperty("h2")]
        public H2 H2 { get; set; }

        [JsonProperty("h3")]
        public H3 H3 { get; set; }

        [JsonProperty("h4")]
        public H4 H4 { get; set; }

        [JsonProperty("h5")]
        public H5 H5 { get; set; }

        [JsonProperty("h6")]
        public H6 H6 { get; set; }
    }

    public class Icons
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("settings")]
        public string Settings { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }
    }

    public class Light
    {
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("cardBackgroundColor")]
        public string CardBackgroundColor { get; set; }

        [JsonProperty("accentColor")]
        public string AccentColor { get; set; }
    }

    public class Logo
    {
        [JsonProperty("light")]
        public string Light { get; set; }

        [JsonProperty("dark")]
        public string Dark { get; set; }
    }

    public class Padding
    {
        [JsonProperty("horizontal")]
        public int Horizontal { get; set; }

        [JsonProperty("vertical")]
        public int Vertical { get; set; }
    }



    public class Secondary
    {
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("borderRadius")]
        public int BorderRadius { get; set; }

        [JsonProperty("padding")]
        public Padding Padding { get; set; }
    }

    public class Shadows
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }

    public class Spacing
    {
        [JsonProperty("small")]
        public int Small { get; set; }

        [JsonProperty("medium")]
        public int Medium { get; set; }

        [JsonProperty("large")]
        public int Large { get; set; }

        [JsonProperty("xlarge")]
        public int Xlarge { get; set; }
    }

    public class Themes
    {
        [JsonProperty("light")]
        public Light Light { get; set; }

        [JsonProperty("dark")]
        public Dark Dark { get; set; }

        [JsonProperty("custom")]
        public Custom Custom { get; set; }
    }

    public class Typography
    {
        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        [JsonProperty("headings")]
        public Headings Headings { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("caption")]
        public Caption Caption { get; set; }

        [JsonProperty("button")]
        public Button Button { get; set; }
    }


}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
