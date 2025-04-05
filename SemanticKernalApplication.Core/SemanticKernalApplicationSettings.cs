namespace SemanticKernalApplication.Core
{
    public class Settings : SemanticKernalApplicationSettings { }

    public class SemanticKernalApplicationSettings
    {
        public static readonly string Key = "SemanticKernalApplicationSettings";
       
        public bool EnableKeyVault { get; set; }
        public bool EnableAuthentication { get; set; }
       
        public string SubscriptionKey { get; set; }
        public string SemanticKernalApplicationBaseUrl { get; set; }
        public string SemanticKernalApplicationAlgoliaEndPoint { get; set; }
        public string SemanticKernalApplicationIHFormEndPoint { get; set; }
        
        public SitecoreGraphQLSettings SitecoreGraphQLSettings { get; set; }       
      
        public APICacheSetting APICacheSetting { get; set; }
        public CDPSettings CDPSettings { get; set; }
        public AzureOpenAISettings AzureOpenAISettings { get; set; }
        public bool EnableCompression { get; set; }
        public string EnableCompressionGZipType { get; set; }

    } 

    public class SitecoreGraphQLSettings
    {
        public string SitecoreGraphQLEndpoint { get; set; }
        public string SitecoreApIKey { get; set; }
        public string SitecoreApIKey_Development { get; set; }
        public string SitecoreApIKey_UAT { get; set; }
        public string SC_ApiKeyName { get; set; }
        public string SitecoreCMDomainName { get; set; }
        public string SitecoreEdgeDomain { get; set; }
        public string SitecoreApIKey_Override { get; set; }
    }
    public class CDPSettings
    {
        public string BrowserIdBaseUrl { get; set; }
        public string BaseUrl { get; set; }
        public string ClientKey { get; set; }
        public string ApiToken { get; set; }
        public string Pos { get; set; }
        public string Language { get; set; }
        public string Channel { get; set; }
        public string Currency { get; set; }
        public string CallFlowsUrl { get; set; }
        public string GetBrowserIdUrl { get; set; }
        public string CreateUserUrl { get; set; }
        public string UpdateUserUrl { get; set; }
        public string GetUserUrl { get; set; }
        public string CreateDataExtensionsUrl { get; set; }
        public string EventUrl { get; set; }
        public bool EnableCDP { get; set; }
    }

    public class APICacheSetting
    {
        public int SlidingExpirationCacheDurationInDays { get; set; }
        public int AbsoluteExpirationCacheDurationInDays { get; set; }
        public bool EnableAPICache { get; set; }
    }

    public class AzureOpenAISettings
    {
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
        public string OpenAIModel { get; set; }
        public string Dalle3Model { get; set; }
    }

}
