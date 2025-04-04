namespace SemanticKernalApplication.WebAPI.Models.CDP
{
    // References:
    // - https://doc.sitecore.com/personalize/en/developers/api/bx-callflows.html
    // - https://doc.sitecore.com/personalize/en/developers/api/flow-object.html
    public class CDP_CallFlowsModel
    {
        public string channel { get; set; }
        public string clientKey { get; set; }
        /// <summary>
        /// The ID of a live Interactive Full Stack Experience or live Interactive Full Stack Experiment that you want to run        
        /// </summary>
        public string friendlyId { get; set; }
        public string pointOfSale { get; set; }
        public string browserId { get; set; }
    }
}
