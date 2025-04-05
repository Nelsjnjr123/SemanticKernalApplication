using SemanticKernalApplication.WebAPI.Models;
using Newtonsoft.Json;
public class CDPBase
{
    [JsonProperty("browser_id")]
    public string BrowserId { get; set; }

    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("language")]
    public string Language { get; set; }

    [JsonProperty("page")]
    public string Page { get; set; }

    [JsonProperty("pos")]
    public string Pos { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("sessionData")]
    public CDP_Session SessionData { get; set; }
    [JsonProperty("ext")]
    public CDPBaseExtensions Ext { get; set; }
}
public class CDPBaseExtensions
{

    public string Type { get; set; }

    public string Feedback { get; set; }

    public string FeedbackCategory { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("key")]
    public string Key { get; set; }
    public string CRM_ID { get; set; }
    public string Employee_ID { get; set; }
    public string BP_Number { get; set; }
    public string Mobile_Device_ID { get; set; }
    public string Azure_ID { get; set; }

    public string PageId { get; set; }
    public string PageTitle { get; set; }

    public string ScreenName { get; set; }
    public string CourseName { get; set; }

    public string CourseId { get; set; }

    public string PaymentMethod { get; set; }
    public string PaymentType { get; set; }

    public string OrderId { get; set; }

    public string InvoiceNumber { get; set; }


    public string EventId { get; set; }

    public string EventName { get; set; }
    public string FavouriteId { get; set; }
    public string FavouriteName { get; set; }
    public string PaymentStatus { get; set; }
    public dynamic SubmitEnquiry { get; set; }
    public string Guest_Type { get; set; }
    public string PageType { get; set; }

    public string ReceiptNo { get; set; }
    public string ReceiptAmt { get; set; }
    public string MindparkCatetory { get; set; }
    public string MindparkIdeaDescription { get; set; }
    public string MindparkIdeaId { get; set; }
    public bool MindparkVote { get; set; }
    public string SemanticKernalApplicationEyeCategory { get; set; }
    public string SemanticKernalApplicationEyeSubCategory { get; set; }
    public string SemanticKernalApplicationEyeLocation { get; set; }
    public string SemanticKernalApplicationEyeDetailedLocation { get; set; }
    public string SemanticKernalApplicationEyeIssueDescription { get; set; }
    public string VehiclePlateNo { get; set; }
    public string VehiclePlateSource { get; set; }
    public string VehiclePlateCode { get; set; }
    public string VehicleName { get; set; }
    public string VehicleType { get; set; }
    public string ServiceRatingRequestType { get; set; }
    public string ServiceRatingServiceNumber { get; set; }
    public string ServiceRating { get; set; }
    public string ServiceRatingComment { get; set; }
    public string CarProfileId { get; set; }

    public string MembershipType { get; set; }
    public string VehicleManufacturer { get; set; }
    public string VehicleColor { get; set; }
    public string VehicleFuelType { get; set; }
    public string Tenure { get; set; }
    public string ParkingSubscriptionPlan { get; set; }
    public string ParkingSubscriptionStartDate { get; set; }
    public string ParkingSubscriptionEndDate { get; set; }
    public int SubscriptionDays { get; set; }
    public string Category { get; set; }
    public string ServiceNumber { get; set; }
    public string Country { get; set; }
    public string Place { get; set; }

    #region WashMyCar
    public string CarWashBuilding { get; set; }
    public string CarWashFloor { get; set; }
    public string CarWashPreferredTime { get; set; }
    public string CarWashParkingNumber { get; set; }
    public string CarWashPhoneNumber { get; set; }
    public string CarWashPlateSource { get; set; }
    public string CarWashPlateNumber { get; set; }
    public string CarWashPlateCode { get; set; }
    public string CarWashSubscriptionPackage { get; set; }
    public string CarWashDescription { get; set; }
    public string CarWashRequestType { get; set; }
    #endregion
}
public class CDP_Session
{

    public string Deep_link { get; set; }

    public bool Is_logged_in { get; set; }

    public string PageType { get; set; }
    public string PageId { get; set; }
    public string PageTitle { get; set; }

    public string Type { get; set; }

    public string OriginPage { get; set; }

    public string Guest_Type { get; set; }

   

    public string ScreenName { get; set; }
    public string CourseName { get; set; }
    public string CourseId { get; set; }
    public DateTime LogInDate { get; set; }
    public DateTime LogoutDate { get; set; }
}
public class CDPFilters
{

    public string Category { get; set; }

    public List<CDPFilterCriteria> FilterCriteria { get; set; }
}
public class CDPFilterCriteria
{

    public string Id { get; set; }

    public string Name { get; set; }
}