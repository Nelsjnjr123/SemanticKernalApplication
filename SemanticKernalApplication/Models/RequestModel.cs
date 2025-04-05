using System.ComponentModel.DataAnnotations;

namespace SemanticKernalApplication.WebAPI.Models
{
    public class RequestModel
    {
        /// <summary>
        /// PageName
        /// </summary>
        /// <example>Home</example>
        [Required]
        public string ScreenName { get; set; }
        /// <summary>
        /// Sitecore item GUID for fetching item by graphql
        /// </summary>
        /// <example>{34EFCBB3-CF94-4752-B14D-08CE210D8A73}</example>
        public string Id { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        /// <example>en</example>
        public string Language { get; set; } = "en";
        /// <summary>
        /// User Current Latitude
        /// </summary>
        /// <example>100.203.044</example>
        public string Latitude { get; set; }
        /// <summary>
        /// User Current Longitude
        /// </summary>
        /// <example>100.203.044</example>
        public string Longitude { get; set; }
        /// <summary>
        /// User type (Visitor / Employee / Academy etc)
        /// </summary>
        /// <example>Visitor</example>
        public string Personna { get; set; }
        /// <summary>
        /// Only use this parameter for Listing / Details
        /// </summary>
        /// <example>Details</example>
        public string PageType { get; set; }

        /// <summary>
        /// Only use this parameter for Dine/Blog/News etc
        /// </summary>
        /// <example>News</example>
        public string Type { get; set; }

        /// <summary>
        /// Pagination string data
        /// </summary>
        /// <example>Nw==</example>
        public string Cursor { get; set; }

        /// <summary>
        /// Pagination with 10 records
        /// </summary>
        /// <example>10</example>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// PageNumber
        /// </summary>
        /// <example>1</example>
        public int PageNumber { get; set; }
        /// <summary>
        /// Filter 
        /// <example>"filters": [
        ///   {
        ///     "FilterField": "Author",
        ///     "FilterDetails": [ 
        ///         {"Id":"{75C247F8-8E5C-4716-999C-DC42A54D89AB}","Name":"Author1"},
        ///         {"Id":"{75C247F8-8E5C-4716-999C-DC42A54D89AB}","Name":"Author2"},
        ///     ]
        ///   },
        ///   {
        ///      "FilterField": "cusine",
        ///      "FilterDetails": [  
        ///         {"Id":"{75C247F8-8E5C-4716-999C-DC42A54D89AB}","Name":"Briyani"},
        ///         {"Id":"{75C247F8-8E5C-4716-999C-DC42A54D89AB}","Name":"Rice"}
        ///       ]
        ///   }
        ///   ]
        ///</example>
        /// </summary>
        public List<FilterOptions> Filters { get; set; }

        /// <summary>
        /// Sort by date or by name
        /// <example>Date / Name </example>
        /// </summary>
        public string SortBy { get; set; }
        /// <summary>
        /// sort order asc / desc
        /// <example>asc</example>
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Student BP Number Used to fetch User/Course Details
        /// </summary>
        public string BPNumber { get; set; }
        public string BrowserId { get; set; }
        public string OriginPage { get; set; }
        public string AzureId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        #region MyRegion
        public string SfId { get; set; }
        public string ItemType { get; set; }
        public string CategoryName { get; set; }
        #endregion
        public string CarType { get; set; }
        public string VehicleId { get; set; }
        public string ServiceNumber { get; set; }
        public string ServiceCategory { get; set; }
        public bool IsFutureCardsRequired { get; set; } = false;
        public string State { get; set; }
        public bool IsLocationBased { get; set; }
        public string sitename { get; set; }

    }
    public class FilterOptions
    {
        public bool IsKeywordFilter { get; set; } = false;
        public string FilterField { get; set; }
        public List<string> FilterOptionId { get; set; }
        public List<FilterDetails> FilterDetails { get; set; }
        public string Category { get; set; }
        public string ServiceNo { get; set; }
        public string ServiceId { get; set; }
    }
    public class FilterDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string SearchKeyword { get; set; }
    }
}
