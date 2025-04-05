namespace SemanticKernalApplication.Core
{
    public static class Constants
    {
        public static string AcademyToken;
        public static string SalesforceToken;
        public static DateTime SalesforceTokenExpiry;
        public static string SFMCToken;
        public static DateTime SFMCTokenExpiry;
        public static string SharepointToken;
        public static DateTime SharepointTokenExpiry;
        public static string IHSharepointToken;
        public static DateTime IHSharepointTokenExpiry;

        public static class Form
        {
            public const string FormSubmittedSuccessfullyMessage = "Form submitted successfully";
            public const string GoogleReCaptchaValidationFailedMessage = "Google reCaptcha validation failed";
            public const string FormErrorMessage = "Something went wrong while processing your request. Please try again.";
            public const string NewsletterAlreadySubscribedErrorMessage = "You are already subscribed.";
            public const string SFMCEmailFailedError = "SemanticKernalApplicationErr98-Something went wrong while sending email.";
            public const string ServiceRequestNumberError = "Please enter Service Request Number (SRNumber).";
            public const string InvalidSessionId = "INVALID_SESSION_ID";
            public const string SFMCInvalidSessionId = "Not Authorized";
            public const string SharepointInvalidSessionId = "API Authentication Failed.";
            public const string FileUploadedSuccessfullyMessage = "File(s) uploaded successfully";
            public const string IHDocuments = "IHDocuments";
            public const string FolderName = "folderName";
            public const string GoogleRecaptchaToken = "googleRecaptchaToken";
            public const string ChannelName = "channelName";
            public const string MakeAnEnquiry_MediaEnquiry = "MediaEnquiry";
            public const string MakeAnEnquiry_Other = "Other";
            public const string MakeAnEnquiry_Other_InnovationHub = "SemanticKernalApplicationInnovationHub";
            public const string MakeAnEnquiry_Other_Academy = "SemanticKernalApplicationAcademy";

            public static class LeadSource
            {
                public const string SemanticKernalApplicationWebsite = "SemanticKernalApplication Website";
                public const string SemanticKernalApplicationApp = "MOBILE_APP";
            }

            public static class CaseSource
            {
                public const string Client_Type = "Non-SemanticKernalApplication";
                public const string GN_Department = "Call Centre";  // Default
                public const string GN_MarketingDepartment = "Marketing";
                public const string GN_SemanticKernalApplicationAcademyDepartment = "SemanticKernalApplication Academy";
                public const string GN_InnovationHubDepartment = "FinTech Hive";
                public const string Origin = "Web";
            }

            public const string FormDateFormate = "dd/MM/yyyy";
            public const string EventDateFormate = "yyyy-MM-dd";
            public const string YYYYMMddDateFormate = "yyyy-MM-dd";
            public const string FormTimeFormate = "hh:mm tt";
            public const string HHMMSSTimeFormate = "hh:mm:ss";
            public const string HHMMSSTime24Formate = "HH:mm:ss";
            public const string FormDTFCCommercial = "Commercial";
            public const string HostAnEventEnquiry = "hostanevent";
            public const string ReportDataBreachEnquiry = "Report Data Breach";

            public static class FileExtensions
            {
                public const string PNG = "png";
                public const string JPG = "jpg";
                public const string MP4 = "mp4";
                public const string PDF = "pdf";
                public const string ICO = "ico";
                public const string RAR = "rar";
                public const string RTF = "rtf";
                public const string TXT = "txt";
                public const string SRT = "srt";
                public const string HEIC = "heic";
                public const string BMP = "bmp";
                public const string AVI = "avi";
                public const string MOV = "mov";
                public const string TIFF = "tiff";
                public const string M4A = "m4a";
            }

        }
        public static class Designa
        {
            public const string CardSearchSuccessfullyMessage = "Search request executed successfully";
        }
        public const string ApiSubscriptionKeyHeader = "Ocp-Apim-Subscription-Key";
        public const string TokenHeader = "Azure-AD-Token";
        public const string Sc_apikey = "sc_apikey";
        public const string HeaderName = "Authorization";
        public const string UserName = "Username";
        public const string Password = "Password";
        public const string Bearer = "Bearer";
        public const string Basic = "Basic";
        public const string Exception = "Exception Occured";
        public const string Key = "58d26614-5277-49fc-bd7e-fcfaff2acb19";
        public const string Messages = "625c1d45-b950-429f-8053-485509d7105f";
        public const string BY = "By";
        public const string ValidUntil = "Valid until";
        public const string News = "News";
        public const string Default = "Default";
        public const string Offers = "Offer";
        public const string Variant = "Variant";
        public const string Podcast = "Podcast";
        public const string Blogs = "Blog";
        public const string Dine = "Dine";
        public const string Art = "Art";
        public const string Hotels = "Hotel";
        public const string Entertainment = "Entertainment";
        public const string Shop = "Shop";
        public const string Wellness = "Wellness";
        public const string Service = "Services";
        public const string Listing = "Listing";
        public const string Details = "Details";
        public const string Events = "Event";
        public const string Author = "Author";
        public const string Date = "Date";
        public const string PublishDate = "PublishDate";
        public const string ExpiryDate = "MobileValidityExpiryDate";
        public const string MobileSubText = "MobileSubText";
        public const string Ecosystem = "Ecosystem";
        public const string Article = "Article";
        public const string Plain = "Plain";
        public const string ImageTitle = "ImageTitle";
        public const string ProfileSupport = "ProfileSupport";
        public const string Name = "Name";
        public const string Ascending = "ASC";
        public const string Descending = "DESC";
        public const string FacetFilterCategories = "Categories";
        public const string Heading = "Heading";
        public const string ProfileAbout = "ProfileAbout";
        public const string ProfilePolicy = "ProfilePolicy";
        public const string NoResults = "No Results found";
        public const string LikedItems = "LikedItems";
        public const string Experience = "Experience";
        public const string WhatsOn = "WhatsOn";
        public const string Create = "create";
        public const string ArticleVariantDefault = "Default";
        public const string ArticleVariantEvents = "Events";
        public const string ArticleVariantPodcasts = "Podcasts";
        public const string Required = "required";
        public const string ExtensionNotValid = "Only .jpg and .png allowed";
        public const string ExtensionSemanticKernalApplicationeyeNotValid = "Only .jpg,.png,.bmp,.mov,.heic,.m4a,.pdf,mp4 and .tiff allowed";
        public const string ExtensionVehicleNotValid = "Only .jpg,.pdf and .png allowed";
        public const string RequiredLength = "required length";
        public const int FiveLength = 5;
        public const string Continue = "Continue";
        public const string ShowBlockPage = "ShowBlockPage";
        public const int ListingPageCount = 25;
        public const string LikedItem = "LikedItem";
        public const string UAE = "AE";
        public const string Personna = "Personna";
        public const string Customer = "Customer";
        public const string SwaggerTitle = "Swagger:SwaggerTitle";
        public const string SwaggerDescription = "SemanticKernalApplication API Services";
        public const string EnableKeyvalutSettingName = "SemanticKernalApplicationSettings:EnableKeyVault";
        public const string EnableCustomAppCodeSettingName = "SemanticKernalApplicationSettings:EnableCustomAppCode";
        public const string AzureValutUrlSettingName = "SemanticKernalApplicationSettings:AzureKeyVaultUrl";
        public const string ApplicationInsightsConnectionString = "ApplicationInsights:ConnectionString";
        public const string WebsiteFormTempContainerName = "SemanticKernalApplication-website-form-temp";
        public const string WebsiteFormBlobTagKey = "SemanticKernalApplication-website-form-temp-blobKey";
        public const string WebsiteFormBlobTagValue = "SemanticKernalApplication-website-form-temp-blobValue";
        public const string EnableCompression = "SemanticKernalApplicationSettings:EnableCompression";
        public const string EnableCompressionGZipType = "SemanticKernalApplicationSettings:EnableCompressionGZipType";
        public const string Fastest = "Fastest";
        public const string Optimal = "Optimal";

        public const string AcademyCourses = "Courses";
        public const string AcademyProgrammes = "Programmes";
        public const string Mybookings = "My bookings";
        public const string Success = "Success";
        public const string Carwash = "Car Wash";
        public const string ParkingSubscription = "Parking Subscription";
        public const string PaymentHistory = "PaymentHistory";
        public const string SearchPayParking = "SearchPayParking";
        public const string FindMyCar = "FindMyCar";
        public const string Subscription = "Subscription";
        public const string OneTimePayment = "one time payment";
        public const int AppCustomErrorCode = 1002;
        public const string SemanticKernalApplication = "SemanticKernalApplication";

        public const string Case = "Case";
        public const string Lead = "Lead";
        public const string StrikeOffCompanyName = "nameofcompany";
        public const string StrikeOffCompanyLicenseNumber = "companylicenseno";
        #region DataExtension
        public const string SFID = "CRM_ID";
        public const string Guest_Type = "Guest_Type";
        public const string MobileDeviceId = "Mobile_Device_ID";
        public const string EmployeeId = "Employee_ID";
        public const string BpNumber = "BP_Number";
        public const string AzureId = "Azure_ID";
        public const string FeedbackCategory = "Feedback_Category";
        public const string Feedback = "Feedback_Comment";
        public const string Enquiry = "Enquiry";
        #endregion

        #region Mobile App Related Constants                
        public const string SemanticKernalApplication_WEBSITE_ROOT_ITEM_SHORT_ID = "534B1A78E28B4F2B94E449ACA57AF0C1";
        public const string SemanticKernalApplication_WEBSITE_SETTINGS_ITEM_SHORT_ID = "32378F0C6B0147D6989412200C72AC2E";
        public const string MOBILE_APP_CONFIGURATIONS_TEMPLATE_SHORT_ID = "E80639DACB9E4C3EAE94FA177169EEEF";

        public const string ConfigurationsFieldName = "Configurations";
        public const string DictionaryDetailsFieldName = "DictionaryDetails";
        public const string HeadlessMobilePlacholderXPath = "item.rendered.sitecore.route.placeholders.headless-mobile";
        public const string HeadlessMobilePlacholderMobileXPath = "item.rendered.sitecore.route.placeholders.headless-mobile";
        public const string HeadlessLayoutMobilePlacholderXPath1 = $"layout.{HeadlessMobilePlacholderMobileXPath}";
        public const string HeadlessLayoutMobilePlacholderXPath = $"layout.{HeadlessMobilePlacholderMobileXPath}";
        public const string HeadlessItemFieldXPath = "item.rendered.sitecore.route.fields";
        public const string HeadlessSettingItemFieldXPath = "item.fields";
        public const string HeadlessSeasonFieldXPath = "item.children.results[0].fields";
        public const string HeadlessLayoutFieldXPath = $"layout.{HeadlessItemFieldXPath}";
        public const string TemplateIdFieldXPath = $"item.rendered.sitecore.route.templateId";
        public const string ItemPageUrlXPath = "item.rendered.sitecore.context.MetaDataInfo.canonicalUrl";

        public const string IHSiteName = "InnovationHub";
        public const string SiteName = "mav-site-a";

        public static class ScreenName
        {
            // Note: This isn't used by mobile team directly but it's used to specify all the mobile app related settings at settings item's presentation details
            public const string SettingsPageScreen = "settings";
            public const string SeasonsPageScreen = "seasons";
            public const string HomePageScreen = "home";
            public const string OnboardingPageScreen = "onboarding";
            public const string WhatsOnPageScreen = "whatson";
            public const string GalleryScreen = "screengallery";
            public const string RaffleScreen = "raffledraw";
            public const string AcademyDetailScreen = "screenacademydetail";
            public const string AcademyListingScreen = "screenacademylisting";
            public const string AcademyFilterScreen = "screenacademyfilter";
            public const string ServiceLandingScreen = "services";
            public const string AppUpdatePageScreen = "appupdate";
            public const string CarWashLandingPageScreen = "washmycarlanding";
            public const string ParkingSubscriptionLandindPageScreen = "parkingsubscriptionlanding";
            public const string VehicalDetailsLandingPage = "vehicaldetailslandingpage";
            public const string ProfileSupportPageScreen = "profilesupportpage";
            public const string HidSupportPage = "hidsupportpage";
            public const string ProfileAboutPageScreen = "profileaboutpage";
            public const string ProfilepolicydetailsPageScreen = "profilepolicydetails";
            public const string PaymentHistoryPageScreen = "paymenthistory";

        }

        public static class AcademyContent
        {
            public const string RelatedProducts = "Related Products";
            public const string Academy = "Academy";
            public const string CourseType = "course_type";
        }

        // Cache Keys
        public static class CacheKeys
        {
            public const string MobileAppConfigurationsCacheKey = "MobileAppConfigurationsData";
            public const string MobileAppDictionaryDetailsCacheKey = "MobileAppDictionaryData";
            public const string MobileAppScreenNameDetailsCacheKey = "MobileAppScreenNameData";

            public const string AuditorCacheKeyPrefix = "Auditor_";
            public const string Auditor_AuditorAPIServicesCacheKey = $"{AuditorCacheKeyPrefix}AuditorAPIServices";
            public const string Auditor_LiquidatorAPIServicesDetailsCacheKey = $"{AuditorCacheKeyPrefix}LiquidatorAPIServices";
        }

        #endregion

        #region Components Name
        public const string MOBILE_SCREEN_DETAILS = "mobilescreendetails";
        public const string APP_CARDS = "appcards";
        public const string GRID_TEXT_CARD = "gridtextcard";
        public const string GRID_TEXT_CARD_WITH_DESCRIPTION = "gridtextcardwithdescription";
        public const string GRID_TEXT_CARD_WITH_DATE = "gridtextcardwithdate";
        public const string PARKING_SUBSCRIPTION_LIST = "parkingsubscriptionlist";
        public const string HEADING = "heading";
        public const string GENERAL_SERVICES_LINKS = "generalserviceslinks";
        public const string INAPP_SERVICES_LINKS = "inappserviceslinks";
        public const string QUICKLINKS = "quicklinks";
        public const string CTA_FULL_PAGE = "ctafullpage";
        public const string CTA_Button = "ctabutton";
        public const string CAROUSEL_SLIDES = "carouselslides";
        public const string CAROUSEL_FUll_PAGES = "carouselfullpages";
        public const string GRID_SLIDES = "gridslides";
        public const string ARTICLE = "article";
        public const string EXPERIENCE_DETAIL = "experiencedetail";
        public const string EXPERIENCE_OFFERS = "experienceoffers";
        public const string GRID_VERTICAL_DETAIL = "gridverticaldetail";
        public const string FILTERS = "listingfilters";
        public const string ACADEMY_FILTERS = "academylistingfilters";
        public const string ACCORDION = "accordion";
        public const string IMAGE_TITLE = "imagetitle";
        public const string IMAGE_WITH_CONTENT = "imagewithcontent";
        public const string CAROUSAL_ENROLLMENTS = "carousalenrollments";
        public const string CAROUSAL_ACADEMY_SLIDES = "carousalacademyslides";
        public const string ACADEMY_GRID_LIST = "academygridlist";
        public const string ACADEMY_APP_CARDS = "academyappcards";
        public const string ACADEMY_DETAIL = "academydetail";
        public const string BODY_TEXT_WITH_LINK = "bodytextwithlink";
        public const string GRID_EXTERNAL = "gridexternal";
        public const string GRID_VERTICAL_ACADEMY_DETAIL = "gridverticalacademydetail";
        public const string GENERAL_SERVICES_LIST = "generalserviceslist";
        public const string INAPP_SERVICES_LIST = "inappserviceslist";
        public const string VEHICLE_SUBSCRIPTION_LANDING_PAGE = "vehiclegrid";
        #endregion

        #region Heading Variant
        public const string WithNotificationAndLikeCTAs = "WithNotificationAndLikeCTAs";
        public const string WithNotificationLikeAndShareCTAs = "WithNotificationLikeAndShareCTAs";
        public const string WithShareAndLikeCTAs = "WithShareAndLikeCTAs";
        public const string WithShareCTA = "WithShareCTA";
        public const string WithShareLikeAndCalendarCTAs = "WithShareLikeAndCalendarCTAs";

        #endregion

        #region
        public const string DevelopmentEnvironment = "Development";
        public const string UATEnvironment = "UAT";
        public const string ProductionEnvironment = "Production";
        public const string APP_Environment = "ASPNETCORE_ENVIRONMENT";
        #endregion

        public const double SemanticKernalApplication_LATITUDE = 25.210348;
        public const double SemanticKernalApplication_LONGITUDE = 55.276905;
        #region CDP Allowed EXT
        public enum CDP_DataExtensionNames
        {
            Personna,
            LeadDetails,
            CookieDetails,
            NewsletterDetails,
            Type,
            ServiceTypes,
            RaffleDraw,
            Mindpark
        }
        #endregion

        #region Vehicle Profile Request Types
        public const string CreateVehicle = "create";
        public const string DeleteVehicle = "delete";
        #endregion

        #region Sitecore Lauout Item Path 
        //public const string SETTINGS_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/MobileHome/Settings";
        public const string SETTINGS_PATH = "/sitecore/content/mobile-mavericks/{0}/Settings";
        public const string SEASON_PATH = "/sitecore/content/mobile-mavericks/mav-shared/Seasons";
        public const string VISITOR_HOME_PATH = "/MobileHome";
        public const string GUEST_HOME_PATH = "/MobileHome/guesthome";
        public const string EMPLOYEE_HOME_PATH = "/MobileHome/employeehome";
        public const string ACADAMY_HOME_PATH = "/MobileHome/StudentHome";
        public const string ONBOARDING_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/Onboarding";
        public const string APPUPDATE_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/AppUpdate";
        public const string PARKINGSUBSCRIPTION_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/ParkingSubscriptionLanding";
        public const string PAYMENTHISTORY_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/Paymenthistory";
        public const string WHATSON_PATH = "{90EFE8DB-CB97-4639-A99E-8C62A2E74EDC}";
        public const string GALLERY_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/Galllery";
        public const string RAFFLE_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/Raffledraw";
        public const string GUEST_SERVICE_LANDING_PATH = "/MobileHome/GuestServiceLanding";
        public const string VISITOR_SERVICE_LANDING_PATH = "/MobileHome/VisitorServiceLanding";
        public const string EMPLOYEE_SERVICE_LANDING_PATH = "/MobileHome/EmployeeServiceLanding";
        public const string STUDENT_SERVICE_LANDING_PATH = "/MobileHome/StudentServiceLanding";
        public const string GUEST_WASHMYCAR_LANDING_PATH = "/MobileHome/GuestWashMyCar";
        public const string VISITOR_WASHMYCAR_LANDING_PATH = "/MobileHome/VisitorWashMyCar";
        public const string EMPLOYEE_WASHMYCAR_LANDING_PATH = "/MobileHome/EmployeeWashMyCar";
        public const string STUDENT_WASHMYCAR_LANDING_PATH = "/MobileHome/StudentWashMyCar";
        public const string VISITOR_VEHICLE_LANDING_PATH = "/MobileHome/VisitorVehicleLandingPage";
        public const string GUEST_VEHICLE_LANDING_PATH = "/MobileHome/GuestVehicleLandingPage";
        public const string EMPLOYEE_VEHICLE_LANDING_PATH = "/MobileHome/EmployeeVehicleLandingPage";
        public const string STUDENT_VEHICLE_LANDING_PATH = "/MobileHome/StudentVehicleLandingPage";
        public const string PROFILE_SUPPORT_PATH = "{EE3FD66D-A0B3-4C30-8ACD-6E22432A4FD5}";
        public const string HID_PROFILE_SUPPORT_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/Hid Profile Support";
        public const string PROFILE_ABOUT_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/Profile About";
        public const string PROFILE_POLICY_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Home/MobileHome/Profile Policy";
        public const string PARKING_LOCATION_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Data/Maps/Map Sources/Our Locations";
        public const string SemanticKernalApplicationEYE_CATEGORY_LOCATION_PATH = "/sitecore/content/SemanticKernalApplicationExperiences/SemanticKernalApplication/SemanticKernalApplicationWebsite/Settings/MobileApp Settings/SemanticKernalApplicationEye Categories";
        #endregion
        #region Sitecore Item Guid
        public const string WHATSON_LISTING_TEMPLATEID = "{32F6CFA9-A6FF-499E-ADC8-387B3BD4E3D3}";
        public const string WHATSON_NEWS_BLOG_DETAIL_TEMPLATEID = "{63252DE3-1B17-4B29-B8E3-70BAED7EEF65}";

        #endregion
        #region Template Id
        public const string EXPERIENCE_DETAILS_TEMPLATE_ID = "{19885DFD-B59A-442A-A9C6-68D8587D78E1}";
        public const string OFFERS_DETAILS_TEMPLATE_ID = "{CBADDF29-7C89-4145-A55F-DA918901C0AB}";
        public const string BLOGS_DETAILS_TEMPLATE_ID = "{63252DE3-1B17-4B29-B8E3-70BAED7EEF65}";
        public const string NEWS_DETAILS_TEMPLATE_ID = "{63252DE3-1B17-4B29-B8E3-70BAED7EEF65}";
        public const string PODCASTS_DETAILS_TEMPLATE_ID = "{C426C70A-2B63-4FC7-A884-C378BE626973}";
        public const string EVENTS_DETAILS_TEMPLATE_ID = "{C9BCAF8B-8112-4641-85E4-3934F02CB93D}";
        public const string ECOSYSTEM_DETAILS_TEMPLATE_ID = "33416e16-5e18-4c5b-9bc6-7a75f5613605";
        #endregion
        #region Personna 
        public const string VISITOR = "visitor";
        public const string EMPLOYEE = "employee";
        public const string GUEST = "guest";
        public const string ACADEMY = "academy";
        public const string STUDENT = "student";

        #endregion
        #region Heading Variant
        public const string HeadingDefault = "Default";
        public const string HeadingHome = "Home";
        public const string HeadingWhatsOn = "WhatsOn";
        public const string HeadingWithNotificationAndLikeCTAs = "WithNotificationAndLikeCTAs";
        public const string HeadingWithNotificationLikeAndShareCTAs = "WithNotificationLikeAndShareCTAs";
        public const string HeadingWithShareAndLikeCTAs = "WithShareAndLikeCTAs";
        public const string HeadingWithShareCTA = "WithShareCTA";
        public const string HeadingWithShareLikeAndCalendarCTAs = "WithShareLikeAndCalendarCTAs";

        #endregion
        #region SSO
        public const string EmailAddress = "emailAddress";
        public const string AzureB2cUserPwd = "xWwvJ]6NMw+bWH-d!1";
        public const string SalesforceId = "SFID";
        public const string Employee_ID = "Employee_Id";
        public const string BP_Number = "BP_Number";
        public const string DeviceId = "DeviceId";
        public const string FirebaseId = "FirebaseId";
        public const string Email = "UserEmail";
        public const string Category = "Category";
        public const string Upsert = "upsert";
        public const string Get = "get";
        public const string Guest = "Guest";
        public const string User_Type = "Individual";
        public const string UEmail = "uEmail";
        public const string Register_role = "register_role";
        public const string Billing_first_name = "billing_first_name";
        public const string Billing_last_name = "billing_last_name";
        public const string User_type = "user_type";
        public const string Billing_phone = "billing_phone";
        public const string Tax_registration_no = "tax_registration_no";
        public const string Billing_address_address1 = "billing_address[address1]";
        public const string Billing_address_address2 = "billing_address[address2]";
        public const string Billing_address_city = "billing_address[city]";
        public const string Billing_address_country = "billing_address[country]";
        public const string StudentId = "student_id";

        #endregion
        #region Messages
        public const string HttpStatusCode200 = "SemanticKernalApplicationErr1-Success";
        public const string HttpStatusCode500 = "SemanticKernalApplicationErr2-Something went wrong while processing the request!!!";
        public const string HttpStatusCode204 = "SemanticKernalApplicationErr3-No results found !!!";
        public const string HttpStatusCode400 = "SemanticKernalApplicationErr4-Bad request !!!";
        public const string UserCreated = "SemanticKernalApplicationErr5-User Created successfully !!!";
        public const string UserDeleted = "SemanticKernalApplicationErr6-User Deleted successfully !!!";
        public const string UserUpdated = "SemanticKernalApplicationErr7-User Updated successfully !!!";
        public const string UserCreationFailed = "SemanticKernalApplicationErr8-User Creation failed !!!";
        public const string UserCreationFailedInAcademy = "SemanticKernalApplicationErr9-User Creation failed due to either empty bpnumber in academy system for this user!!!";
        public const string UserAlreadyExists = "SemanticKernalApplicationErr10-User already exits proceed to sign in !!!";
        public const string UserUpdationFailed = "SemanticKernalApplicationErr11-User Updation failed !!!";
        public const string UserFound = "SemanticKernalApplicationErr12-User data fetched successfully.";
        public const string UserFetchFailed = "SemanticKernalApplicationErr13-User fetching failed.";
        public const string UserNotFound = "SemanticKernalApplicationErr14-User not exist, Please proceed to sign up first.";
        public const string UserIsNotCustomer = "SemanticKernalApplicationErr15-User not a customer !!!";
        public const string UserNotFoundInSF = "SemanticKernalApplicationErr16-User not found in Salesforce!!!";
        public const string UserUpsert = "SemanticKernalApplicationErr17-User Created or Updated !!!";
        public const string UserUpsertImageFormat = "SemanticKernalApplicationErr18-User Created or Updated, but image not updated as it should be in .jpg or .png !!!";
        public const string EmailSent = "SemanticKernalApplicationErr19-Email Sent successfully !!!";
        public const string ParameterMissing = "SemanticKernalApplicationErr20-Parameter missing or invalid !!!";
        public const string UserNotFoundInAzure = "SemanticKernalApplicationErr21-User not found in Azure !!!";
        public const string UserDeactivated = "SemanticKernalApplicationErr22-User already deactivated !!!";
        public const string UserFired = "SemanticKernalApplicationErr23-User already fired !!!";
        public const string CountryNotFound = "SemanticKernalApplicationErr24-Country Not Found !!!";
        public const string InvalidEmailTemplate = "SemanticKernalApplicationErr25-Invalid email template !!!";
        public const string UserSwitchToEmployeeFailed = "SemanticKernalApplicationErr26-User cannot be switched to Employee , as no employee id found in SF !!!";
        public const string UserSwitchToVisitorFailed = "SemanticKernalApplicationErr27-User switching to Visitor failed  !!!";
        public const string UserSwitchToStudentFailed = "SemanticKernalApplicationErr28-User switching to Student failed !!!";
        public const string TriggeredSMFCEmail = "SemanticKernalApplicationErr29-Triggered Email notification !!!";
        public const string TriggeredSMFCEmailFailed = "SemanticKernalApplicationErr30-Triggered Email notification failed !!!";
        public const string AzureSignUpUserAlreadyExists = "SemanticKernalApplicationErr31-User already exists, Please proceed to sign in.";
        public const string CreateBrowserIdFailed = "SemanticKernalApplicationErr32-Browser Id creation failed!!!";
        public const string BrowserIdCreated = "SemanticKernalApplicationErr33-Browser Id created successfully!!!";
        public const string EventsCreated = "SemanticKernalApplicationErr34-CDP Events created successfully!!!";
        public const string EventsCreationFailed = "SemanticKernalApplicationErr35-CDP Events creation failed!!!";
        public const string SessionExpired = "SemanticKernalApplicationErr36-Session expired, please sign in again!!!";
        public const string Unauthorized = "SemanticKernalApplicationErr37-Unauthorized user!!!";
        public const string DuplicateEntriesMessage = "SemanticKernalApplicationErr38-Invalid data. It contains duplicate entries!!!";
        public const string DataExtensionsCreated = "SemanticKernalApplicationErr39-CDP Data Extensions created or Updated successfully!!!";
        public const string DataExtensionsCreationFailed = "SemanticKernalApplicationErr40-CDP Data Extensions creation failed!!!";
        public const string RegisterEventSuccess = "SemanticKernalApplicationErr41-Event registered successfully.";
        public const string RegisterEventFailed = "SemanticKernalApplicationErr42-Event registeration failed.";
        public const string RemoveFavouriteSuccess = "SemanticKernalApplicationErr43-Remove favourite successfully.";
        public const string RemoveFavouriteFailed = "SemanticKernalApplicationErr44-Remove favourite failed.";
        public const string CreateFavouriteSuccess = "SemanticKernalApplicationErr45-Create favourite successfully.";
        public const string CreateFavouriteFailed = "SemanticKernalApplicationErr46-Create favourite failed.";
        public const string GetFavouriteSuccess = "SemanticKernalApplicationErr47-Getting favourite successfully.";
        public const string GetFavouriteFailed = "SemanticKernalApplicationErr48-Getting favourite failed.";
        public const string GetEventsuccess = "SemanticKernalApplicationErr49-Getting Events successfully.";
        public const string GetEventFailed = "SemanticKernalApplicationErr50-Getting Events failed.";
        public const string RaffleDrawSuccess = "SemanticKernalApplicationErr51-Raffle draw submission is successful.";
        public const string RaffleDrawFailed = "SemanticKernalApplicationErr52-Raffle draw submission is failed.";
        public const string MindparkListSuccess = "SemanticKernalApplicationErr53-Getting Mindpark list is successful.";
        public const string MindparkListFailed = "SemanticKernalApplicationErr54-Getting Mindpark list is failed.";
        public const string MindparkSubmitSuccess = "SemanticKernalApplicationErr55-Submitting Mindpark idea is successful.";
        public const string MindparkSubmitFailed = "SemanticKernalApplicationErr56-Submitting Mindpark idea is failed.";
        public const string MindparkVoteSuccess = "SemanticKernalApplicationErr57-Submitting Mindpark vote is successful.";
        public const string MindparkVoteFailed = "SemanticKernalApplicationErr58-Submitting Mindpark vote is failed.";
        public const string SemanticKernalApplicationEyeSuccess = "SemanticKernalApplicationErr59-SemanticKernalApplication Eye submission is successful.";
        public const string SemanticKernalApplicationEyeFailed = "SemanticKernalApplicationErr60-SemanticKernalApplication Eye submission is failed.";
        public const string TrackServicesListSuccess = "SemanticKernalApplicationErr61-Service requests retrieved successfully";
        public const string TrackServicesListFailed = "SemanticKernalApplicationErr62-Failed to retrieve service request";
        public const string VehicleProfileListSuccess = "SemanticKernalApplicationErr63-Vehicles Profile retrieved successfully";
        public const string VehicleProfileListFailed = "SemanticKernalApplicationErr64-Failed to retrieve vehilces profile";
        public const string VehicleProfileCreateSuccess = "SemanticKernalApplicationErr65-Vehicles Profile created successfully";
        public const string VehicleProfileCreateFailed = "SemanticKernalApplicationErr66-Failed to create vehilces profile, might be plate number will be already registered";
        public const string VehicleProfileDeleteSuccess = "SemanticKernalApplicationErr67-Vehicles Profile deleted successfully";
        public const string VehicleProfileDeleteFailed = "SemanticKernalApplicationErr68-Failed to delete vehilces profile";
        public const string ServiceRatingSuccess = "SemanticKernalApplicationErr69-Rating submitted successfully";
        public const string ServiceRatingFailed = "SemanticKernalApplicationErr70-Failed to submit rating";
        public const string CarWashSubmitSuccess = "SemanticKernalApplicationErr71-Car Wash submitted succesfully";
        public const string CarWashSubmitFailed = "SemanticKernalApplicationErr72-Failed to submit Car Wash details";
        public const string ReceiptSubmitSuccess = "SemanticKernalApplicationErr73-Receipt submitted successfully";
        public const string ReceiptSubmitFailed = "SemanticKernalApplicationErr74-Failed to submit receipt";
        public const string ReceiptUpdateSuccess = "SemanticKernalApplicationErr75-Receipt updated successfully";
        public const string ReceiptUpdateFailed = "SemanticKernalApplicationErr76-Failed to update receipt";
        public const string ParkingSubscriptionSubmitSuccess = "SemanticKernalApplicationErr77-Parking subscription submitted successfully";
        public const string ParkingSubscriptionSubmitFailed = "SemanticKernalApplicationErr78-Failed to submit Parking subscription details";
        public const string VehicleAttachmentRequired = "SemanticKernalApplicationErr79-2 documents needed to be uploaded (Vehicle registration copy front and Vehicle registration copy Back)";
        public const string GetParkingSubscriptionPlanSuccess = "SemanticKernalApplicationErr80-Getting parking subscription plan successful";
        public const string GetParkingSubscriptionPlanFailed = "SemanticKernalApplicationErr81-Getting parking subscription plan failed";
        public const string PaymentHistorySuccess = "SemanticKernalApplicationErr82-Getting Payment history successfully";
        public const string PaymentHistoryFailed = "SemanticKernalApplicationErr83-Failed to get Payment history";
        public const string GetPayParkingSuccess = "SemanticKernalApplicationErr84-Getting Pay Parking successfully";
        public const string GetPayParkingFailed = "SemanticKernalApplicationErr85-Failed to get Pay Parking or Vehicle not parked in SemanticKernalApplication";
        public const string ParkingSettlementSuccess = "SemanticKernalApplicationErr86-Parking settlement done successfully";
        public const string ParkingSettlementFailed = "SemanticKernalApplicationErr87-Parking settlement failed";
        public const string FindMyCarSuccess = "SemanticKernalApplicationErr88-Find my car location successful";
        public const string FindMyCarFailed = "SemanticKernalApplicationErr89-Failed to find my car location";
        public const string GetPushNotificationSuccess = "SemanticKernalApplicationErr90-Getting Push notification successful";
        public const string GetPushNotificationFailed = "SemanticKernalApplicationErr91-Failed to get Push notification";
        public const string AddOderSuccess = "SemanticKernalApplicationErr92-Add order successful";
        public const string AddOrderFailed = "SemanticKernalApplicationErr93-Add order failed";
        public const string FormSubmittedSuccessfullyMessage = "SemanticKernalApplicationErr94-Form submitted successfully";
        public const string FormErrorMessage = "SemanticKernalApplicationErr96-Something went wrong while processing your request. Please try again.";
        public const string CompleteOrderSuccess = "SemanticKernalApplicationErr104-Complete order successful";
        public const string CompleteOrderFailed = "SemanticKernalApplicationErr105-Complete order failed";
        public const string PaymentTokenSuccess = "SemanticKernalApplicationErr106-Getting Payment token successful";
        public const string PaymentTokenFailed = "SemanticKernalApplicationErr107-Failed getting payment token";
        public const string CountrySuccess = "SemanticKernalApplicationErr108-Getting country list successful";
        public const string CountryFailed = "SemanticKernalApplicationErr109-Failed getting country list";
        public const string GetDiscountSuccess = "SemanticKernalApplicationErr110-Getting discount successful";
        public const string GetDiscountFailed = "SemanticKernalApplicationErr111-Failed getting discount";
        public const string SemanticKernalApplicationEyeCategorySuccess = "SemanticKernalApplicationErr112-Getting SemanticKernalApplicationEye Category successful";
        public const string SemanticKernalApplicationEyeCategoryFailed = "SemanticKernalApplicationErr113-Failed getting SemanticKernalApplicationEye Category";
        #endregion
        #region website message
        public const string VoluntaryStrikeOffSuccess = "Getting Voluntary Strike Off successful";
        public const string VoluntaryStrikeOffFailed = "Getting Voluntary Strike Off failed";
        #endregion
        #region CDP Peronalization
        public const string PageViewEvent = "VIEW";
        public const string IdentityEvent = "IDENTITY";
        public const string LogoutEvent = "LOGOUT";
        public const string SignInEvent = "SIGNIN";
        public const string ADDEvent = "ADD";
        public const string ADD_ContactEvent = "ADD_CONTACTS";
        public const string ConfirmEvent = "CONFIRM";
        public const string CheckoutEvent = "CHECKOUT";
        public const string ViewFavouriteEvent = "VIEW_FAVOURITES";
        public const string CreateFavouriteEvent = "CREATE_FAVOURITES";
        public const string RemoveFavouriteEvent = "REMOVE_FAVOURITES";
        public const string RaffleDrawEvent = "RAFFLEDRAW";
        public const string GetMindparkEvent = "GET_MINDPARK";
        public const string SubmitMindparkEvent = "SUBMIT_MINDPARK";
        public const string SubmitMindparkVoteEvent = "SUBMIT_MINDPARK_VOTE";
        public const string MindparkEvent = "MINDPARK";
        public const string SemanticKernalApplicationEyeEvent = "SemanticKernalApplicationEYE";
        public const string VehcleProfileCreateEvent = "CREATE_VEHICLEPROFILE";
        public const string ServiceRatingEvent = "SERVICERATING";
        public const string CarWashSubmitEvent = "CARWASHSUBMIT";
        public const string CreateEvent = "CREATE_EVENTS";
        public const string ViewEvent = "VIEW_EVENTS";
        public const string SubmitFeedbackEvent = "SUBMIT_FEEDBACK";
        public const string SubmitEnquiryEvent = "SUBMIT_ENQUIRY";
        public const string FeedbackPage = "FEEDBACK PAGE";
        public const string RaffledrawPage = "RAFFLE DRAW PAGE";
        public const string MindparkPage = "GET MIND PARK PAGE";
        public const string MindparkSubmitPage = "SUBMIT MIND PARK PAGE";
        public const string MindparkVotePage = "SUBMIT MIND PARK VOTE PAGE";
        public const string SemanticKernalApplicationEyePage = "SemanticKernalApplication EYE PAGE";
        public const string VehicleProfilePage = "VEHICLE PROFILE PAGE";
        public const string ServiceRatingPage = "SERVICE RATING PAGE";
        public const string CarWashSubmitPage = "CAR WASH SUBMIT PAGE";
        public const string SignIn = "SIGNIN";
        public const string SignOut = "SIGINOUT";
        public const string IdentityCRMID = "CRM_ID";
        public const string IdentityDeviceId = "Device_ID";
        public const string IdentityEmail = "email";
        public const string ExtensionName = "ext";
        public const string ExtensionKey = "default";
        public const string Courses = "COURSES";
        public const string ParkingPaymentEvent = "PARKINGPAYMENT";
        public const string OfflineCourses = "OFFFLINE_COURSES";
        public const string OfflinePayment = "OFFFLINE";
        public const string OnlinePayment = "ONLINE";
        public const string Purchased = "PURCHASED";
        public const string Pending = "OFFLINE PAYMENT PENDING";
        public const string Invoice = "invoice";
        public const string Receipt_Parking_Subscription = "RECEIPT_PARKING_SUBSCRIPTION";
        public const string Parking_Subscription = "PARKING_SUBSCRIPTION";
        public const string Parking_Subscription_List = "PARKING_SUBSCRIPTION_LIST";
        public const string BrowserId = "browser_id";
        public const string Page = "page";
        public const string Type = "type";
        public const string Channel = "channel";
        public const string Language = "language";
        public const string Pos = "pos";
        public const string FirstName = "firstName";
        public const string LastName = "lastName";
        public const string Currency = "currency";

        public const string Extensions = "extensions";
        public const string Identifiers = "identifiers";
        public const string Emails = "emails";
        public const string CDPEmail = "email";
        public const string Gender = "gender";
        public const string PhoneNumber = "phoneNumbers";

        public const string Street = "street";
        public const string Dob = "dateOfBirth";
        public const string City = "city";
        public const string Country = "country";
        public const string Nationality = "nationality";
        public const string ZipCode = "postCode";

        //Call Flows
        public const string FriendlyId_GetGuestId = "get_guest_id";
        public const string FriendlyId_LocationBased = "location_card";
        public const string FriendlyId_VisitBased = "test_types";
        public const string FriendlyId_XMCloudPagesBased = "embedded_ee3fd66da0b34c308acd6e22432a4fd5_en";//"embedded_7a29656b176e40c4a460f20f46aa3c96_en";

        #endregion

        #region SFMC Emailtemplates       
        public const string UserDeletedEmailTemplate = "5582";
        public const string UserDeactivatedEmailTemplate = "5581";
        public const string UserSignUpEmailTemplate = "5443";
        public const string UserOTPEmailTemplate = "5580";
        public const string UserCredentialEmailTemplate = "4783";
        public const string SubmitEnquiryEmailTemplate = "6213";
        public const string SubmitPhotshootEmailTemplate = "5682";
        public const string SendDocumentsEmailTemplate = "5467";
        public const string NewsletterSubscriptionEmailTemplate = "5803";
        public const string HostanEventEmailTemplate = "5571";
        public const string RegisterInterestEmailTemplate = "5579";
        public const string RaffleDrawEmailTemplate = "4783";
        public const string MakeEnquiryTemplate = "4783";
        public const string AcademyOnlineCourseRegisteredEmailTemplate = "5575";
        public const string AcademyOfflineCourseRegisteredEmailTemplate = "5574";
        public const string FeedbackEmailTemplate = "5374";
        public const string SubmitEventNocEmailTemplate = "5713";
        public const string SubmitExternalNocWorkEmailTemplate = "6174";



        #endregion
        public enum EmailTemplates
        {
            UserCreated = 4783, UserDeleted = 4783, UserDeactivated = 4783,
            UserOTP = 4783, UserCredentail = 4783, SubmitEnquiry = 1111, RegisterInterest = 1111,
            FeedbackEmailTemplate = 5374, UserOTPEmailTemplate = 5580, UserDeletedEmailTemplate = 5582,
            SubmitEnquiryEmailTemplate = 6213, CreateEventEmailTemplate = 5579, AcademyOnlineCourseRegisteredEmailTemplate = 5575,
            AcademyOfflineCourseRegisteredEmailTemplate = 5574, UserDeactivatedEmailTemplate = 5581,
            UserSignUpEmailTemplate = 5443, UserCredentialEmailTemplate = 4783, UserCredentialTempEmailTemplate = 5802,
            RaffleDrawTemplate = 5573, MindParkTemplate = 5572, SubmitEventNocEmailTemplate = 5713, SemanticKernalApplicationEyeTemplate = 5570, SubmitExternalNocWorkEmailTemplate = 6174,
            SubmitParkingSubscriptionEmailTemplate = 5444, CarWashSubscribedEmailTemplate = 5577
        };
        public enum AuditorServiceTypes
        {
            AuditorAPIServices,
            LiquidatorAPIServices
        };
        public static class GraphQlQueries
        {
            // Query to get the mobile app configurations and dictionary details
            public const string GetMobileAppConfigurations = @"
                fragment mobileAppConfigurationFields on Item {
                    fields {
                        name
                        value
                    }              
                }

                query(
                  $pageSize: Int!
                  $endCursor: String!
                  $websiteRootId: String!
                  $mobileAppConfigurationsTemplateId: String!
                )
                {
                  search(
                    where: {
                     AND: [
                      {
                        name: ""_path"", 
                        value: $websiteRootId
                        operator: CONTAINS
                      },
                      {
                        name: ""_templates"", 
                        value: $mobileAppConfigurationsTemplateId
                        operator: CONTAINS
                      }
                    ] 
                    }   
                    first: $pageSize
                    after: $endCursor
	                )
                  {
                    total,
                    pageInfo {
                      endCursor,
                      hasNext
                    },
                    results {
                      ... mobileAppConfigurationFields
                    }
                  }
                }
            ";

            //Allows querying presentation details/layout data for the item.
            public const string GetItemLayout = @"
                query($language:String!,$sitename:String!,$path:String!)
                {
                    layout(site:$sitename,language:$language,routePath:$path)
                    {
                        item{
                            rendered
                          }
                    }
                 }
            ";

            //Allows querying for information about an item in the content tree.
            public const string GetItem = @"
                query($language:String!,$path:String!)
                {
                    item(language:$language,path:$path)
                    {
                        rendered
                    }
                 }
            ";
            public const string GetSettingItem = @"
                query($language:String!,$path:String!)
                {
                    item(language:$language,path:$path)
                    {                        
                        id
						name     
              	        fields 
                        {
                            name
                            jsonValue
                        }                        
                    }
                 }
            ";
            public const string GetSeasonItem = @"
                query($language:String!,$path:String!)
                {
                    item(path: $path, language: $language) 
  		            {
                        children {
                        results {
                        fields {
                            name
                            jsonValue             
                        }           
                        }
                        }
                    }
                 }
            ";
            public const string GetAuthorPublications = @"query ($path: String!,$pagesize: Int!) {
                      details: search(
                        where: {
                             
                           name:""Author"" 
                           value:$path        
                          AND: [                            
                            {
                              OR: [
                                {
                                  name: ""_templates""
                                  value: ""63252DE3-1B17-4B29-B8E3-70BAED7EEF65""
                                  operator: CONTAINS
                                }
                                {
                                  name: ""_templates""
                                  value: ""C426C70A-2B63-4FC7-A884-C378BE626973""
                                  operator: CONTAINS
                                }
                              ]
                            }
                          ]
                        }
                        # defaults to 10
                        first:$pagesize
 		                    orderBy: { name: ""PublishDate"", direction: DESC }    
                      ) {
                        total
                        pageInfo {
                          endCursor
                          hasNext
                        }
                        results {
                                        Id: id
                                        PublishDate: field(name: ""PublishDate"") {
                                          jsonValue
                                        }
                        
                                        ThumbnailImage: field(name: ""MobileThumbnailImage"") {
                                          jsonValue
                                        }
                                        Title: field(name: ""Heading"") {
                                          value
                                        }
                   
                                        Type: field(name: ""Type"") {
                                          jsonValue
                                        }
                                        Tags: field(name: ""SemanticKernalApplicationTags"") {
                                          jsonValue
                                        }

                                        CTALink: field(name: ""CTALink"") {
                                          jsonValue
                                        }
                                        CTAAction: field(name: ""CTAAction"") {
                                          jsonValue
                                        }
                                        CardType: field(name: ""CardType"") {
                                          jsonValue
                                        }
                                        SubText: field(name: ""MobileSubText"") {
                                          value
                                        }
                                        SubHeading: field(name: ""MobileSubHeading"") {
                                          value
                                        }
                                        LocationTitle: field(name: ""LocationTitle"") {
                                          value
                                        }
                                        LocationLatitude: field(name: ""LocationLatitude"") {
                                          value
                                        }
                                        LocationLongitude: field(name: ""LocationLongitude"") {
                                          value
                                        }
                                        ReadLabel: field(name: ""ReadLabel"") {
                                            value
                                        }
                      
                        }
                      }
                    }
            ";
            public const string GetListing = @"query ($cursor: String!,$pagesize: Int!) {
              details: search(
                where
                # defaults to 10
                first: $pagesize
                after:$cursor
                ORDERBY) {
                total
                pageInfo {
                  endCursor
                  hasNext
                }
                results {
                  Id: id
                  Pageurl:url{
                    url
                  }
                  Date: field(name: ""Date"") {
                    jsonValue
                  }
                  PublishDate: field(name: ""PublishDate"") {
                    jsonValue
                  }
                  ExpiryDate: field(name: ""MobileValidityExpiryDate"") {
                    jsonValue
                  }
                  ThumbnailImage: field(name: ""MobileThumbnailImage"") {
                    jsonValue
                  }
                  Title: field(name: ""Heading"") {
                    value
                  }
                  Type: field(name: ""Type"") {
                    jsonValue
                  }
                  Tags: field(name: ""SemanticKernalApplicationTags"") {
                    jsonValue
                  }               
                  CTAAction: field(name: ""CTAAction"") {
                    jsonValue
                  }
                  CardType: field(name: ""CardType"") {
                    jsonValue
                  }
        
                  LocationTitle: field(name: ""LocationTitle"") {
                    value
                  }
                  LocationLatitude: field(name: ""LocationLatitude"") {
                    value
                  }
                  LocationLongitude: field(name: ""LocationLongitude"") {
                    value
                  }            
                  WayFinderNodeCode: field(name: ""WayFinderNodeCode"") {
                      jsonValue
                    }
                 Author: field(name: ""Author"") {
                     jsonValue
                 }
                ReadLabel: field(name: ""ReadLabel"") {
                     value
                 }               
                  
                }
              }
            }

            ";
            public const string GetServiceListing = @"query ($cursor: String!,$pagesize: Int!) {
              details: search(
                where
                # defaults to 10
                first: $pagesize
                after:$cursor
                ORDERBY) {
                total
                pageInfo {
                  endCursor
                  hasNext
                }
                results {
                  Id: id
                  Pageurl:url{
                    url
                  }
                  Date: field(name: ""Date"") {
                    jsonValue
                  }
                  PublishDate: field(name: ""PublishDate"") {
                    jsonValue
                  }
                  ExpiryDate: field(name: ""MobileValidityExpiryDate"") {
                    jsonValue
                  }
                  ThumbnailImage: field(name: ""MobileThumbnailImage"") {
                    jsonValue
                  }
                  Title: field(name: ""Heading"") {
                    value
                  }
                  Type: field(name: ""Type"") {
                    jsonValue
                  }
                  Tags: field(name: ""SemanticKernalApplicationTags"") {
                    jsonValue
                  }               
                  CTAAction: field(name: ""CTAAction"") {
                    jsonValue
                  }
                  CardType: field(name: ""CardType"") {
                    jsonValue
                  }
        
                  LocationTitle: field(name: ""LocationTitle"") {
                    value
                  }
                  LocationLatitude: field(name: ""LocationLatitude"") {
                    value
                  }
                  LocationLongitude: field(name: ""LocationLongitude"") {
                    value
                  }            
                  WayFinderNodeCode: field(name: ""WayFinderNodeCode"") {
                      jsonValue
                    }
                  Author: field(name: ""Author"") {
                     jsonValue
                 }
                ReadLabel: field(name: ""ReadLabel"") {
                     value
                 }               
                  
                }
              }
            }

            ";
            public const string GetItemDetails = @"query ($language: String!, $path: String!) {
                      details:item(language: $language, path: $path) {
                        Id: id
                        Pageurl: url {
                          url
                        }
                        OpenCloseTimes: field(name: ""OpenCloseTimes"") {
                          jsonValue
                        }
                        Date: field(name: ""Date"") {
                          jsonValue
                        }
                        PublishDate: field(name: ""PublishDate"") {
                          jsonValue
                        }
                        ExpiryDate: field(name: ""MobileValidityExpiryDate"") {
                          jsonValue
                        }
                        ThumbnailImage: field(name: ""MobileThumbnailImage"") {
                          jsonValue
                        }
                        Title: field(name: ""Heading"") {
                          value
                        }
                        Type: field(name: ""Type"") {
                          jsonValue
                        }
                        Tags: field(name: ""SemanticKernalApplicationTags"") {
                          jsonValue
                        }
                        CTAAction: field(name: ""CTAAction"") {
                          jsonValue
                        }
                        CardType: field(name: ""CardType"") {
                          jsonValue
                        }
                        PodcastAudioFile: field(name: ""PodcastAudio"") {
                          jsonValue
                        }
                        RegisterUrl: field(name: ""RegisterUrl"") {
                          jsonValue
                        }
                        LocationTitle: field(name: ""LocationTitle"") {
                          value
                        }
                        LocationLatitude: field(name: ""LocationLatitude"") {
                          value
                        }
                        LocationLongitude: field(name: ""LocationLongitude"") {
                          value
                        }
                        WayFinderNodeCode: field(name: ""WayFinderNodeCode"") {
                          jsonValue
                        }
                        Author: field(name: ""Author"") {
                          jsonValue
                        }
                        ReadLabel: field(name: ""ReadLabel"") {
                          value
                        }
                        Content: field(name: ""Content"") {
                          value
                        }
                        LeftSideText: field(name: ""LeftSideText"") {
                          value
                        }
                        ContextItemChildren: children {
                          ContextItemChildrenResults: results {
                            ChildrenRTE: children(
                              includeTemplateIDs: ""{EA50C9EF-9843-4320-8465-B9159028F50E}""
                            ) {
                              ChildrenRTEResults: results {
                                RTE: field(name: ""Text"") {
                                  value
                                }
                              }
                            }
                          }
                        }
                        ContextQuoteChildren: children {
                          ContextQuoteChildrenResults: results {
                            ChildrenQuote: children(
                              includeTemplateIDs: ""{3788C1DE-2828-47F3-8D4C-8176D8863FB8}""
                            ) {
                              ChildrenQuoteResults: results {
                                Quote: field(name: ""Quote"") {
                                  value
                                }
                              }
                            }
                          }
                        }

                      }
                    }";
            public const string GetGalleryQuery = @"query GalleryQuery($path: String!, $language: String!) {
              ModelData : item(path: $path, language: $language) {    
                Position: field(name: ""Position"") {
                  value
                }
                Slides: field(name: ""Slides"") {
                  jsonValue
                }
		            Variant: field(name: ""Variant"") {
                  value
                }
		            IsCloseCtaAndTitle: field(name: ""IsCloseCtaAndTitle"") {
                  jsonValue
                }
              }
            }";

            public const string GetFilterIds = @"query ($path: String!, $language: String!) {
                      item(path: $path, language: $language) {
                           filterList: field(name: ""filterList"") {
                              ... on MultilistField {
                                filters: targetItems {
                                  categoryId: id
                                  categoryName:name
                                }
                              }
                            }  
                          }
                        }
    ";
            public const string GetFilters = @"query ($path: String!, $cursor: String!) {
                          details:search(
                            where: {
                              name: ""_path""
                              value: $path
                              AND: [
                                {
                                  OR: [
                                    {
                                      name: ""_templates""
                                      value: ""{F10C2123-8A9C-4769-93EE-DFD0267B03F9}""
                                      operator: NCONTAINS
                                    }
                                    {
                                      name: ""_templates""
                                      value: ""{B731B2C5-29E0-4D34-86A9-693418B88C05}""
                                      operator: NCONTAINS
                                    }
                                    
                                  ]
                                }
                              ]
                            }
                            # defaults to 10
                            first: 10
                            after: $cursor
                          ) {
                            total
                            pageInfo {
                              endCursor
                              hasNext
                            }
                            results {
                              authorname: field(name: ""name"") {
                                value
                              }
                              id
                              name: field(name: ""value"") {
                                value
                              }
                            }
                          }
                        }";
            //Allows querying to get publish item detail.
            public const string PublishItemDetail = @"
                query ($path: String!, $language: String!){
                   item(path: $path, language: $language) {   
                    id
                    url{
                      scheme
                      hostName
                      path
                      url
                    }
                  }
                }
            ";
            //Allows querying to get publish item detail.
            public const string GetCarParkingLocationDetails = @"
                query ($path: String!, $language: String!){
                   item(path: $path, language: $language) {   
                    LocationItems:children {
                          Locations: results {
                            Title: field(name: ""Title"")
                                   {
          				              value
        				           }                   
                            MobileLocationMap: field(name: ""MobileLocationMap"")
                                   {
          				              jsonValue
        				           }
                            DesignaLocationName: field(name: ""DesignaLocationName"")
                                   {
          				              value
        				           }
                    }
                  }
                }
              }";
            public const string GetSemanticKernalApplicationCategories = @"query(  $cursor: String!) {
                  details:search(
                    where: {
                      AND: [
                        {
                          name: ""_path""
                          value: ""{CDC51603-926E-4AD0-BE22-1AA7C9EF89DF}""
                          operator: CONTAINS
                        }
                        {
                          name: ""_templates""
                          value: ""{87219A1F-6256-4187-8940-B9C2E5255E8C}""
                          operator: CONTAINS
                        }
                      ]
                    }
                    # defaults to 10
                    first: 10
                    after:$cursor
                    orderBy: { name: ""Title"", direction: ASC }) 
                   {
                    total
                    pageInfo {
                      endCursor
                      hasNext
                    }
                    results {
                      Category:field(name: ""Title"") {
                        value
                      }
                      SubCategoryDetails: field(name: ""SubCategory"") {
                        ...categories
                      }
                    }
                  }
                }

                fragment categories on MultilistField {
                  subCategoryList:targetItems {
                    SubCategory:field(name: ""Title"") {
                      value
                    }
                  }
                }
                ";
        }
    }

    public static class ConstantsKeyValue
    {
        public static Dictionary<string, string> ErrorMessages = new Dictionary<string, string>()
        {
            {"Key","58d26614-5277-49fc-bd7e-fcfaff2acb19"},
            {"Message","625c1d45-b950-429f-8053-485509d7105f"}
        };
        public static Dictionary<string, string> Templates = new Dictionary<string, string>()
        {
            {"c3620bd5-2613-43cf-a57a-acb7eaaaf872","ErrorTemplate"},

        };
    }

    public static class AlgoliaKeyValues
    {
        public enum Operations
        {
            UrlAdd = 1,
            UrlDelete = 2
        }
    }
}
