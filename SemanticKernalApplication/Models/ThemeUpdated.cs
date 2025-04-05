using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SemanticKernalApplication.Models
{
  
    public class ThemesList
    {
        public ThemeUpdated mainTheme { get; set; }
        public List<ThemeUpdated> templates { get; set; }
    }
    public class ThemesListData
    {
     
        public List<ThemeAIResponseTemplate> templates { get; set; }
    }
    public struct ThemeUpdated
    {
        public string TemplateId { get; set; }
        [JsonPropertyName("brand_name")]
        public string brand_name { get; set; }

        [JsonPropertyName("brand_logo_light")]
        public string brand_logo_light { get; set; }

        [JsonPropertyName("brand_logo_dark")]
        public string brand_logo_dark { get; set; }

        [JsonPropertyName("brand_typography_fontFamily")]
        public string brand_typography_fontFamily { get; set; }

        [JsonPropertyName("brand_typography_h1_fontFamily")]
        public string brand_typography_h1_fontFamily { get; set; }

        [JsonPropertyName("brand_typography_h1_fontSize")]
        public int brand_typography_h1_fontSize { get; set; }

        [JsonPropertyName("brand_typography_h1_fontWeight")]
        public string brand_typography_h1_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_h1_lineHeight")]
        public double brand_typography_h1_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_h2_fontFamily")]
        public string brand_typography_h2_fontFamily { get; set; }

        [JsonPropertyName("brand_typography_h2_fontSize")]
        public int brand_typography_h2_fontSize { get; set; }

        [JsonPropertyName("brand_typography_h2_fontWeight")]
        public string brand_typography_h2_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_h2_lineHeight")]
        public double brand_typography_h2_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_h3_fontFamily")]
        public string brand_typography_h3_fontFamily { get; set; }

        [JsonPropertyName("brand_typography_h3_fontSize")]
        public int brand_typography_h3_fontSize { get; set; }

        [JsonPropertyName("brand_typography_h3_fontWeight")]
        public string brand_typography_h3_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_h3_lineHeight")]
        public double brand_typography_h3_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_h4_fontFamily")]
        public string brand_typography_h4_fontFamily { get; set; }

        [JsonPropertyName("brand_typography_h4_fontSize")]
        public int brand_typography_h4_fontSize { get; set; }

        [JsonPropertyName("brand_typography_h4_fontWeight")]
        public string brand_typography_h4_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_h4_lineHeight")]
        public double brand_typography_h4_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_h5_fontFamily")]
        public string brand_typography_h5_fontFamily { get; set; }

        [JsonPropertyName("brand_typography_h5_fontSize")]
        public int brand_typography_h5_fontSize { get; set; }

        [JsonPropertyName("brand_typography_h5_fontWeight")]
        public string brand_typography_h5_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_h5_lineHeight")]
        public double brand_typography_h5_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_h6_fontFamily")]
        public string brand_typography_h6_fontFamily { get; set; }

        [JsonPropertyName("brand_typography_h6_fontSize")]
        public int brand_typography_h6_fontSize { get; set; }

        [JsonPropertyName("brand_typography_h6_fontWeight")]
        public string brand_typography_h6_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_h6_lineHeight")]
        public double brand_typography_h6_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_body_fontSize")]
        public int brand_typography_body_fontSize { get; set; }

        [JsonPropertyName("brand_typography_body_fontWeight")]
        public string brand_typography_body_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_body_lineHeight")]
        public double brand_typography_body_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_caption_fontSize")]
        public int brand_typography_caption_fontSize { get; set; }

        [JsonPropertyName("brand_typography_caption_fontWeight")]
        public string brand_typography_caption_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_caption_lineHeight")]
        public double brand_typography_caption_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_button_fontSize")]
        public int brand_typography_button_fontSize { get; set; }

        [JsonPropertyName("brand_typography_button_fontWeight")]
        public string brand_typography_button_fontWeight { get; set; }

        [JsonPropertyName("brand_typography_button_lineHeight")]
        public double brand_typography_button_lineHeight { get; set; }

        [JsonPropertyName("brand_typography_button_fontFamily")]
        public string brand_typography_button_fontFamily { get; set; }

        [JsonPropertyName("brand_borderRadius_small")]
        public int brand_borderRadius_small { get; set; }

        [JsonPropertyName("brand_borderRadius_medium")]
        public int brand_borderRadius_medium { get; set; }

        [JsonPropertyName("brand_borderRadius_large")]
        public int brand_borderRadius_large { get; set; }

        [JsonPropertyName("themes_light_primary")]
        public string themes_light_primary { get; set; }

        [JsonPropertyName("themes_light_onPrimary")]
        public string themes_light_onPrimary { get; set; }

        [JsonPropertyName("themes_light_secondary")]
        public string themes_light_secondary { get; set; }

        [JsonPropertyName("themes_light_onSecondary")]
        public string themes_light_onSecondary { get; set; }

        [JsonPropertyName("themes_light_error")]
        public string themes_light_error { get; set; }

        [JsonPropertyName("themes_light_onError")]
        public string themes_light_onError { get; set; }

        [JsonPropertyName("themes_light_surface")]
        public string themes_light_surface { get; set; }

        [JsonPropertyName("themes_light_onSurface")]
        public string themes_light_onSurface { get; set; }

        [JsonPropertyName("themes_dark_primary")]
        public string themes_dark_primary { get; set; }

        [JsonPropertyName("themes_dark_onPrimary")]
        public string themes_dark_onPrimary { get; set; }

        [JsonPropertyName("themes_dark_secondary")]
        public string themes_dark_secondary { get; set; }

        [JsonPropertyName("themes_dark_onSecondary")]
        public string themes_dark_onSecondary { get; set; }

        [JsonPropertyName("themes_dark_error")]
        public string themes_dark_error { get; set; }

        [JsonPropertyName("themes_dark_onError")]
        public string themes_dark_onError { get; set; }

        [JsonPropertyName("themes_dark_surface")]
        public string themes_dark_surface { get; set; }

        [JsonPropertyName("themes_dark_onSurface")]
        public string themes_dark_onSurface { get; set; }
    }

    public class ThemeAIResponseTemplate
    {
        [JsonPropertyName("themes_dark_primary")]
        public string themes_dark_primary { get; set; }

        [JsonPropertyName("themes_dark_onPrimary")]
        public string themes_dark_onPrimary { get; set; }

        [JsonPropertyName("themes_dark_secondary")]
        public string themes_dark_secondary { get; set; }

        [JsonPropertyName("themes_dark_onSecondary")]
        public string themes_dark_onSecondary { get; set; }

        [JsonPropertyName("themes_light_primary")]
        public string themes_light_primary { get; set; }

        [JsonPropertyName("themes_light_onPrimary")]
        public string themes_light_onPrimary { get; set; }

        [JsonPropertyName("themes_light_onSecondary")]
        public string themes_light_onSecondary { get; set; }
    }
}
