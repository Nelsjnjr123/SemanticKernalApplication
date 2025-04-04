namespace SemanticKernalApplication.WebAPI.Models
{
    public class NotificationRequestModel
    {
        /// <summary>
        /// Email Template name
        /// </summary>
        /// <example>UserCreated</example>
        public string Template { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Otp for the validation
        /// </summary>
        /// <example>01882</example>
        public string OTP { get; set; }
        public bool IsOTP { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EnquiryType { get; set; }
        public string CourseName { get; set; }
        public double CourseFee { get; set; }
        public string CourseDate { get; set; }
        public string CourseLocation { get; set; }
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventLocation { get; set; }
    }
    public class NotificationEmailRequestModel
    {
        public From From { get; set; }
        public To To { get; set; }
        public OPTIONS OPTIONS { get; set; }
    }
    public class From
    {
        public string Address { get; set; }
        public string Name { get; set; }
    }

    public class To
    {
        public string Address { get; set; }
        public string SubscriberKey { get; set; }
        public Contactattributes ContactAttributes { get; set; }
    }

    public class Contactattributes
    {
        public Subscriberattributes SubscriberAttributes { get; set; }
    }

    public class Subscriberattributes
    {
        public string Region { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class OPTIONS
    {
        public string RequestType { get; set; }
    }

    public class NotificationResponseModel
    {
        public string requestId { get; set; }
        public NotificationResponse[] responses { get; set; }
    }

    public class NotificationResponse
    {
        public string recipientSendId { get; set; }
        public bool hasErrors { get; set; }
        public string[] messages { get; set; }
    }

}
