using Newtonsoft.Json;

namespace SemanticKernalApplication.WebAPI.Models
{

    public class BaseAppResponse
    {
        public List<object> SectionComponents { get; set; }
    }
    public class BaseAPIResponse
    {
        public object Results { get; set; }
    }
    public class Values
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
    }
    public class URLField
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class MultiJsonValues
    {
        [JsonProperty("jsonValue")]
        public ValuesDetails JsonValue { get; set; }
    }
    public class ValuesDetails
    {
        [JsonProperty("value")]
        public Values Value { get; set; }
    }

    public class GeneralLink
    {
        [JsonProperty("value")]
        public Fields Value { get; set; }
    }
    public class BoolValues
    {
        [JsonProperty("value")]
        public bool Value { get; set; }
    }

    public class GeneralFields
    {
        [JsonProperty("fields")]
        public Fields Fields { get; set; }


    }

    public class CardTypeFields
    {
        public string id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }


    public class Value
    {
        public string value { get; set; }
    }

    public class TagFields
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("fields")]
        public Fields Fields { get; set; }


    }
    public class TagsJsonValueFieldsList
    {
        [JsonProperty("jsonValue")]
        public TagFields[] JsonValue { get; set; }
    }

    public class AuthorJsonValue
    {
        [JsonProperty("jsonValue")]
        public AuthorJsonValueFields JsonValue { get; set; }
    }
    public class AuthorListJsonValue
    {
        [JsonProperty("jsonValue")]
        public AuthorJsonValueFields[] JsonValue { get; set; }
    }
    public class AuthorJsonValueFields
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("fields")]
        public AuthorFields Fields { get; set; }
    }
    public class AuthorFields
    {
       
        public Values Name { get; set; }
        public ImageValues Image { get; set; }
        public Values Description { get; set; }
    }
    public class TypeJsonValueFields
    {
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("fields")]
        public Fields Fields { get; set; }

    }
    public class RTEChild
    {
        public List<RTEChildResults> ContextItemChildrenResults { get; set; }
    }
    public class RTEChildResults
    {
        public RTEInnerChildResults ChildrenRTE { get; set; }
    }
    public class RTEInnerChildResults
    {
        public List<Fields> ChildrenRTEResults { get; set; }
    }

    public class QuoteChild
    {
        public List<QuoteChildResults> ContextQuoteChildrenResults { get; set; }
    }
    public class QuoteChildResults
    {
        public QuoteInnerChildResults ChildrenQuote { get; set; }
    }
    public class QuoteInnerChildResults
    {
        public List<Fields> ChildrenQuoteResults { get; set; }
    }


    public class OpenCloseTiming
    {      
        [JsonProperty("jsonValue")]
        public List<OpenCloseTimingJsonValue> JsonValue { get; set; }
    }
    public class OpenCloseTimingJsonValue
    {
        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }
    public class CardTypeJsonValueFields
    {
        [JsonProperty("jsonValue")]
        public TypeJsonValueFields JsonValue { get; set; }
    }

    public class Fields
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public Values Title { get; set; }
        public Values Name { get; set; }
        public Values Label { get; set; }
        public Values Value { get; set; }
        public Values Code { get; set; }
        public Values Description { get; set; }
        public ImageValues Image { get; set; }

        public CardTypeFields Type { get; set; }
        public CardTypeFields CardType { get; set; }
        [JsonProperty("src")]
        public string Src { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        public ImageJsonDetails ScreenItem { get; set; }
        public Values ScreenName { get; set; }  
        public Values Designation { get; set; }
        public MobileScreen CTAAction { get; set; }
        //public Names CTAAction { get; set; }
        public LinkValues CTALink { get; set; }
        public Values DayStartTimeFormat { get; set; }
        public Values DayStartMinuteTime { get; set; }
        public Values DayEndMinuteTime { get; set; }
        public Values DayType { get; set; }
        public Values DayEndHourTime { get; set; }
        //public Names CTAAction { get; set; }
        public Values DayEndTimeFormat { get; set; }
        public Values DayStartHourTime { get; set; }
        public Values DayTitle { get; set; }
        public Values RTE { get; set; }
        public Values Quote { get; set; }
        public Values LocationTitle { get; set; }
        public Values LocationLatitude { get; set; }
        public Values LocationLongitude { get; set; }
        public GeneralFields WayFinderNodeCode { get; set; }
    }

    public class Names
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class LinkValues
    {
        [JsonProperty("value")]
        public Link Value { get; set; }
    }
    public class GraphQLQueryVariable
    {
        public string path { get; set; }
        public string templates { get; set; }
        public string sitename { get; set; }
        public string language { get; set; }
        public string cursor { get; set; }
        public int pagesize { get; set; }
        
    }

    public class BaseComponentMappingModel
    {
        public MobileScreen CTAAction { get; set; }
        //public Names CTAAction { get; set; }
        public LinkValues CTALink { get; set; }
    }
    public class BaseComponentModel
    {
        [JsonProperty("ctaAction")]
        public string CTAAction { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public class BaseComponentDetailsMappingModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public class Link
    {
        [JsonProperty("linktype")]
        public string Linktype { get; set; }
        [JsonProperty("target")]
        public string Target { get; set; }
        [JsonProperty("id")]    
        public string Id { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class ImageValues
    {
        [JsonProperty("value")]
        public ImageDetails Value { get; set; }
    }
    public class ImageJsonValues
    {
        [JsonProperty("jsonValue")]
        public ImageJsonDetails JsonValue { get; set; }
    }

    public class DateJsonValues
    {
        [JsonProperty("jsonValue")]
        public DateTimeJsonvalue JsonValue { get; set; }
    }


    public class DateTimeJsonvalue
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class LinkJsonValues
    {
        [JsonProperty("jsonValue")]
        public LinkDetailsJsonValues JsonValue { get; set; }
    }

    public class GeneralLinkJsonValues
    {
        [JsonProperty("jsonValue")]
        public GeneralLinkDetailsJsonValues JsonValue { get; set; }
    }
    public class GeneralLinkDetailsJsonValues
    {
        [JsonProperty("value")]
        public Link Value { get; set; }
    }
    public class DropLinkJsonValues
    {
        [JsonProperty("jsonValue")]
        public DropLinkDetailsJsonValues JsonValue { get; set; }
    }
    public class DropLinkDetailsJsonValues
    {
        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }
    public class LinkDetailsJsonValues
    {
        [JsonProperty("value")]
        public Fields Value { get; set; }
    }
    public class CTAActionJsonValues
    {
        [JsonProperty("jsonValue")]
        public CTAActionFields JsonValue { get; set; }
    }
    public class CTAActionFields
    {
        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }
    public class ImageDetails
    {
        [JsonProperty("src")]
        public string Src { get; set; }

    }
    public class ImageJsonDetails
    {
        [JsonProperty("value")]
        public Fields Value { get; set; }

    }
    public class LatLng
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }

    public class TokenRequestModel
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }  
    }
    public class RequestSuccess
    {
        public bool Success { get; set; }
       
    }
}
