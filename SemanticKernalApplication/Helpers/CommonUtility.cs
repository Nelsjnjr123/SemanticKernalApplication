using SemanticKernalApplication.Core;
using SemanticKernalApplication.Core.Models;
using SemanticKernalApplication.WebAPI.Models;
using SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Dynamic;
using System.Net;
using System.Runtime.Serialization.Json;

namespace SemanticKernalApplication.WebAPI.Helpers
{
    public static class CommonUtility
    {
    

        public static ApiResponseModel<T> GenerateResponse<T>(ApiResponseModel<T> result, bool isFailure = false)
        {
            ApiResponseModel<T> response = null;
            if (!isFailure)
            {
                response = new ApiResponseModel<T>()
                {
                    Data = (T)(object)result.Data ?? Activator.CreateInstance<T>(),
                    Errors = result.Errors,
                    IsSuccess = result.IsSuccess,
                    StatusCode = result.StatusCode,
                    Message = result.Message
                };
            }
            else if ((HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                response = new ApiResponseModel<T>()
                {
                    Errors = new List<ApiResponseErrorModel>(),
                    IsSuccess = false,
                    Data = (T)(object)result.Data ?? Activator.CreateInstance<T>(),
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = result.Message ?? Core.Constants.HttpStatusCode204
                };
            }
            else if ((HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                response = new ApiResponseModel<T>()
                {
                    Errors = new List<ApiResponseErrorModel>(),
                    IsSuccess = false,
                    Data = (T)(object)result.Data ?? Activator.CreateInstance<T>(),
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                    Message = result.Message ?? Core.Constants.HttpStatusCode204
                };
            }
            else if ((HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.PartialContent)
            {
                response = new ApiResponseModel<T>()
                {
                    Errors = new List<ApiResponseErrorModel>(),
                    IsSuccess = false,
                    Data = (T)(object)result.Data ?? Activator.CreateInstance<T>(),
                    StatusCode = System.Net.HttpStatusCode.PartialContent,
                    Message = result.Message ?? Core.Constants.HttpStatusCode204
                };
            }
            else if ((HttpStatusCode)result.StatusCode == System.Net.HttpStatusCode.NotAcceptable)
            {
                response = new ApiResponseModel<T>()
                {
                    Errors = new List<ApiResponseErrorModel>(),
                    IsSuccess = false,
                    Data = (T)(object)result.Data ?? Activator.CreateInstance<T>(),
                    StatusCode = System.Net.HttpStatusCode.NotAcceptable,
                    Message = result.Message ?? Core.Constants.HttpStatusCode204
                };
            }
            else
            {
                response = new ApiResponseModel<T>()
                {
                    Data = (T)(object)result.Data ?? Activator.CreateInstance<T>(),
                    Errors = new List<ApiResponseErrorModel>(),
                    IsSuccess = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = result.Message ?? String.Empty
                };
            }
            return response;

        }
        public static bool CheckUserWithInPeriperyBasedOnGeoPosition(LatLng userCoordinates, LatLng SemanticKernalApplicationCoordinates, double periperyDistance)
        {
            //  var googleMapsService = new GoogleMapService("YOUR_API_KEY");

            // Define the SemanticKernalApplication location
            // var SemanticKernalApplicationLocation = "Dubai International Financial Centre, Dubai, UAE";

            // Define the desired periphery distance in meters
            var peripheryDistance = periperyDistance; // Example: 1000 meters (adjust as needed)

            // Get your current latitude and longitude
            //var yourLocation = "Your Location"; // Replace with your actual location
            //var yourCoordinates = googleMapsService.GetCoordinates(yourLocation);

            // Get the SemanticKernalApplication coordinates

            //  var SemanticKernalApplicationCoordinates = googleMapsService.GetCoordinates(SemanticKernalApplicationLocation);
            //   var SemanticKernalApplicationCoordinates = new LatLng(25.2085, 55.2755);

            if (userCoordinates != null && SemanticKernalApplicationCoordinates != null)
            {
                // Calculate the distance between your coordinates and the SemanticKernalApplication coordinates
                var distance = Distance(userCoordinates, SemanticKernalApplicationCoordinates);
                var convertedDistance = KilometerToMeter(distance);

                // Check if your location is within the periphery of the SemanticKernalApplication
                if (convertedDistance <= peripheryDistance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
        public static double KilometerToMeter(double km)
        {
            double METER = 0;

            METER = km * 1000;

            return METER;
        }
        public static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
        public static (string locationUrl, string googleMapLocationUrl, string wayFinderLocationUrl) GenerateMapLink(double latitude, double longitude, bool isGoogleMap, string wayFinderURl = "", string googleMapDomain = "")
        {
            string locationUrl = String.Empty;
            string googleMapLocationUrl = String.Format(googleMapDomain, latitude, longitude);
            string wayFinderLocationUrl = wayFinderURl;
            if (isGoogleMap)
                locationUrl = googleMapLocationUrl;
            else
                locationUrl = wayFinderLocationUrl;
            return (locationUrl, googleMapLocationUrl, wayFinderLocationUrl);
        }

        public static double Distance(LatLng point1, LatLng point2)
        {
            const double earthRadiusKm = 6371.0;

            double lat1Rad = ToRadians(point1.Latitude);
            double lon1Rad = ToRadians(point1.Longitude);
            double lat2Rad = ToRadians(point2.Latitude);
            double lon2Rad = ToRadians(point2.Longitude);

            double dLat = lat2Rad - lat1Rad;
            double dLon = lon2Rad - lon1Rad;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = earthRadiusKm * c;

            return distance;
        }
        public static List<PlaceholderComponents> CheckDuplicateComponentAndAppendIndex(JArray placeholderComponents)
        {
            List<PlaceholderComponents> sitecoreComponents = placeholderComponents?.ToObject<List<PlaceholderComponents>>();
            var duplicates = sitecoreComponents?.GroupBy(p => p.ComponentName).Where(g => g.Count() > 1)?.ToList();

            foreach (var duplicateGroup in duplicates)
            {
                int index = 1;
                foreach (var person in duplicateGroup)
                {
                    person.ComponentName += $"{index}"; // Update the value with the index number
                    index++;
                }
            }

            return sitecoreComponents;
        }

        public static void AddComponentSection(ExpandoObject componentObject, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = componentObject as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }

        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null)
                throw new NullReferenceException("Unable to convert anonymous object to a dictionary. The source anonymous object is null."); ;

            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                if (IsOfType<T>(value))
                {
                    dictionary.Add(property.Name, (T)value);
                }
            }
            return dictionary;
        }

        private static bool IsOfType<T>(object value)
        {
            return value is T;
        }

        public static bool IsValidUrl(string url)
        {
            Uri? uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public static bool ValidateAttachment(int fileSize, List<DocumentAttachment> attachments, string fileTypes = $"{Constants.Form.FileExtensions.PNG},{Constants.Form.FileExtensions.JPG},{Constants.Form.FileExtensions.PDF}", string fileAttachment = "", bool isByteConversionRequired = true)
        {
            bool isValid = true;
            string errorMessages = "";

            try
            {
                if (fileSize > 0 && attachments?.Count() > 0)
                {
                    foreach (var attachment in attachments)
                    {
                        double bytes = attachment?.FileContent?.Length ?? 0;

                        if (bytes > 0 && fileSize < (bytes / 1024))
                        {
                            errorMessages = $"{errorMessages}, " + ($"{attachment.FileName} size is more than {fileSize} KB");
                            isValid = false;
                        }

                        if (!string.IsNullOrWhiteSpace(fileTypes))
                        {
                            string fileExtension = String.Empty;
                            if (isByteConversionRequired)
                                fileExtension = GetFileExtension(Convert.ToBase64String(attachment?.FileContent));
                            else
                                fileExtension = GetFileExtension(fileAttachment);

                            if (string.IsNullOrWhiteSpace(fileExtension) || !fileTypes.Contains(fileExtension))
                            {
                                errorMessages = $"{errorMessages}, " + ($"{attachment.FileName} file having invalid file extension");
                                isValid = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log the errorMessages
            }

            return isValid;
        }

        /// <summary>
        /// Method is used to get file type from base64 string
        /// </summary>
        /// <param name="base64String">string</param>
        /// <returns>string</returns>
        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return Constants.Form.FileExtensions.PNG;
                case "/9J/4":
                    return Constants.Form.FileExtensions.JPG;
                case "/9J/2":
                    return Constants.Form.FileExtensions.JPG;
                case "AAAAF":
                case "AAAAI":
                    return Constants.Form.FileExtensions.MP4;
                case "JVBER":
                    return Constants.Form.FileExtensions.PDF;
                case "AAABA":
                    return Constants.Form.FileExtensions.ICO;
                case "UMFYI":
                    return Constants.Form.FileExtensions.RAR;
                case "E1XYD":
                    return Constants.Form.FileExtensions.RTF;
                case "U1PKC":
                    return Constants.Form.FileExtensions.TXT;
                case "MQOWM":
                case "77U/M":
                    return Constants.Form.FileExtensions.SRT;
                case "AAAAG": // Also for M4A
                    return Constants.Form.FileExtensions.HEIC;
                case String ext when ext.StartsWith("UKLG"):
                    return Constants.Form.FileExtensions.AVI;
                case String ext when ext.StartsWith("QK04"):
                    return Constants.Form.FileExtensions.BMP;
                case String ext when ext.StartsWith("SUKQ"):
                    return Constants.Form.FileExtensions.TIFF;
                case String ext when ext.StartsWith("AAA"):
                    return Constants.Form.FileExtensions.M4A;
                default:
                    return string.Empty;
            }
        }

        public static string GetFileExtensionFromFileName(string fileName)
        {
            // Find the last index of the dot (.)
            int lastDotIndex = fileName.LastIndexOf('.');

            // If the dot is found and it is not the last character, return the substring after the dot
            if (lastDotIndex >= 0 && lastDotIndex < fileName.Length - 1)
            {
                return fileName.Substring(lastDotIndex + 1);
            }

            // If no dot is found or it's the last character, return an empty string
            return string.Empty;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            // Find the last index of the dot (.)
            int lastDotIndex = fileName.LastIndexOf('.');

            // If the dot is found and it is not the last character, return the substring before the dot
            if (lastDotIndex >= 0 && lastDotIndex < fileName.Length - 1)
            {
                return fileName.Substring(0, lastDotIndex);
            }

            // If no dot is found or it's the last character, return an empty string
            return string.Empty;
        }
        /// <summary>
        /// Getting the messages and the status code for app to get data from sitecore
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static (string subStatusCode, string message) GetMessage(string message)
        {
            if (!String.IsNullOrEmpty(message))
            {
                ReadOnlySpan<char> span = message.AsSpan();
                int index = span.IndexOf('-');
                if (index >= 0)
                {
                    return (span.Slice(0, index).ToString(), span.Slice(index + 1).ToString());
                }
                else
                    return (null, message);
            }
            else
                return (null, null);
        }
    }
}
