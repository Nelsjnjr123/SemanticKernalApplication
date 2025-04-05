namespace SemanticKernalApplication.Models
{

    public class Data
    {
        public List<List<SettingsModel>> sectionComponents { get; set; }
    }

    public class SettingsResponseModels
    {
        public Data data { get; set; }
        public bool isSuccess { get; set; }
        public List<object> errors { get; set; }
        public object message { get; set; }
        public int statusCode { get; set; }
        public object subStatusCode { get; set; }
    }
}
