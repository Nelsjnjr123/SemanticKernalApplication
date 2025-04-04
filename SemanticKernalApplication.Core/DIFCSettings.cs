namespace SemanticKernalApplication.Core
{
    public class Settings : SemanticKernalApplicationSettings { }

    public class SemanticKernalApplicationSettings
    {
        public static readonly string Key = "SemanticKernalApplicationSettings";
        public string WebsiteFormTempContainerName { get; set; }
        public string AzureKeyVaultUrl { get; set; }
        public bool EnableKeyVault { get; set; }
        public bool EnableAuthentication { get; set; }
        public double SemanticKernalApplicationPeripheryDistance { get; set; }
        public string SubscriptionKey { get; set; }
        public string SemanticKernalApplicationBaseUrl { get; set; }
        public string SemanticKernalApplicationAlgoliaEndPoint { get; set; }
        public string SemanticKernalApplicationIHFormEndPoint { get; set; }
        public string GoogleMapLink { get; set; }
        public SitecoreGraphQLSettings SitecoreGraphQLSettings { get; set; }
        public AlgoliaSettings AlgoliaSettings { get; set; }
        public WayFinderSettings WayFinderSettings { get; set; }
        public GoogleRecaptchaV3Settings GoogleRecaptchaV3Settings { get; set; }
        public AcademyAPISettings AcademyAPISettings { get; set; }
        public AzureAdSettings AzureAdSettings { get; set; }
        public SalesForceAPISettings SalesForceAPISettings { get; set; }
        public AmazonPaymentSDKSettings AmazonPaymentSDKSettings { get; set; }
        public SFMCAPISettings SFMCAPISettings { get; set; }
        public APICacheSetting APICacheSetting { get; set; }
        public CDPSettings CDPSettings { get; set; }
        public Topics Topics { get; set; }
        public DesignaSettings DesignaSettings { get; set; }
        public SharePointSettings SharePointSettings { get; set; }
        public bool IsParallelEnabled { get; set; }
        public bool IsSSOFireEnabled { get; set; }
        public bool EnableCompression { get; set; }
        public string EnableCompressionGZipType { get; set; }

    }

    public class WayFinderSettings
    {
        public string WayFinderURL { get; set; }
        public string WayFinderAPIKey { get; set; }
        public string WayFinderSiteName { get; set; }
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

    public class AlgoliaSettings
    {
        public string AlgoliaAppId { get; set; }
        public string AlogoliaAppSecret { get; set; }
        public string AlgoliaIndexName { get; set; }
        public string AlgoliaCrawlerBaseUrl { get; set; }
        public string AlgoliaCrawlerUserId { get; set; }
        public string AlgoliaCrawlerApiKey { get; set; }
        public string AlgoliaCrawlerReIndex { get; set; }
        public string AlgoliaCrawlerId { get; set; }
        public string AlgoliaCrawlerFilePath { get; set; }
        public string AlgoliaCrawlerUrlsCrawl { get; set; }
        public int AlgoliaCrawlUrlPublishItemSeconds { get; set; }
    }

    public class GoogleRecaptchaV3Settings
    {
        public bool GoogleRecaptchaEnabled { get; set; }
        public string GoogleRecaptchaSecret { get; set; }
        public string GoogleRecaptchaApiUrl { get; set; }
    }
    public class AcademyAPISettings
    {
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthUrl { get; set; }
        public string GrantType { get; set; }
        public string UserRegisteredCourseUrl { get; set; }
        public string GetCourseUrl { get; set; }
        public string GetCourseDetailUrl { get; set; }
        public string GetCourseFilterUrl { get; set; }
        public string GetDiscountDetailsUrl { get; set; }
        public string AddOrderUrl { get; set; }
        public string CompleteOrderUrl { get; set; }
        public string GetUserUrl { get; set; }
        public string RegisterUserUrl { get; set; }
        public string GetCountryUrl { get; set; }
    }

    public class AmazonPaymentSDKSettings
    {
        public string AccessCode { get; set; }
        public string MerchantIdentifier { get; set; }
        public string ServiceCommand { get; set; }
        public string SHARequestPhrase { get; set; }
        public string TokenUrl { get; set; }
    }

    public class AzureAdSettings
    {
        public string Instance { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TenantId { get; set; }
        public string Scope { get; set; }
        public string B2cExtensionAppClientId { get; set; }
        public bool IsSecretBasedAuthentication { get; set; }
        public string CertificateName { get; set; }
        public string AzureTenantId { get; set; }
        public string AzureWebAppId { get; set; }
    }

    public class SalesForceAPISettings
    {
        public string BaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthUrl { get; set; }
        public string GrantType { get; set; }
        public string Favourites { get; set; }
        public string RemoveFavourites { get; set; }
        public string GetOrUpsertContact { get; set; }
        public string GetOrUpsertContactFromWebsite { get; set; }   // Note: For the Website, we have a separate endpoint, in-future we might think of merging it with the single endpoint
        public string EventRegister { get; set; }
        public string PublicRegister { get; set; }
        public string PublicRegisterDetail { get; set; }
        public string AuditorServiceDetail { get; set; }
        public string ServiceEnquiry { get; set; }
        public string HostAnEventServiceEnquiry { get; set; }
        public string FeddbackUrl { get; set; }
        public string ReportDataBreach { get; set; }
        public string GetMindparkListUrl { get; set; }
        public string SubmitMindparkUrl { get; set; }
        public string UpVoteOrDownVoteMindparkUrl { get; set; }
        public string EventNoc { get; set; }
        public string ExternalWorkNoc { get; set; }
        public string FormDocUpload { get; set; }
        public string SubmitSemanticKernalApplicationEyeUrl { get; set; }
        public string GetAllServiceRequests { get; set; }
        public string VehicleProfile { get; set; }
        public string ServiceRating { get; set; }
        public string SubmitCarWash { get; set; }
        public string Receipt { get; set; }
        public string TrackServiceRequest { get; set; }
        public string ParkingSubscriptionUrl { get; set; }
        public string GetParkingSubscriptionPlanUrl { get; set; }
        public string GetPaymentHistoryUrl { get; set; }
        public string GetPushNotificationListUrl { get; set; }
        public string VoluntaryStrikeOff { get; set; }
    }
    public class SFMCAPISettings
    {
        public string TokenUrl { get; set; }
        public string NotificationUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromName { get; set; }
        public string TokenBaseUrl { get; set; }
        public string BaseUrl { get; set; }
        public string AuthUrl { get; set; }
        public string EmailClientId { get; set; }
        public string EmailClientSecret { get; set; }
        public string RequestType { get; set; }
        public bool EnableSFMC { get; set; }
        public string SendEmail { get; set; }
        public string ToEmail { get; set; }
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

    public class Topics
    {
        public string FormTopic { get; set; }
        public string FormTopicIH { get; set; }
    }

    public class SharePointSettings
    {
        public string DocAPIBaseUrl { get; set; }
        public string DocAPIAuthUrl { get; set; }
        public string DocAPISaveDocument { get; set; }
        public string DocAPIUserName { get; set; }
        public string DocAPIPassword { get; set; }
        public string DocAPIGrantType { get; set; }
        public string PhotshootBaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Photoshoot { get; set; }
        public int MaxFileSize { get; set; }
        public string RaffledrawUrl { get; set; }
        public string RaffledrawUserName { get; set; }
        public string RaffledrawPassword { get; set; }
        public int AppDocSize { get; set; }
        public int SemanticKernalApplicationEyeAppDocSize { get; set; }
        public string IHAPIBaseUrl { get; set; }
        public string IHAPIAuthUrl { get; set; }
        public string IHAPISaveForm { get; set; }
        public string IHAPIUserName { get; set; }
        public string IHAPIPassword { get; set; }
        public string IHAPIGrantType { get; set; }
    }

    public class DesignaSettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TccNum { get; set; }

    }
}
