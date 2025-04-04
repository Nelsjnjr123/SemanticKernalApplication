using Newtonsoft.Json;

namespace SemanticKernalApplication.WebAPI.Models
{

    #region JToken Mapping Model
    public class AppCardsModelList
    {
        public AppCardsModelFields[] Cards { get; set; }
        public Values Title { get; set; }
        public Values Position { get; set; }
    }
   
    public class AppCardsModelFields
    {
        [JsonProperty("fields")]
        public AppCardsModel ComponentsFields { get; set; }
    }

    public class AppCardsModel: BaseComponentMappingModel
    {
        public Values CardName { get; set; }     

        public ImageValues Image { get; set; }
        public ImageValues OverlayImage { get; set; }
        public GeneralFields CardType { get; set; }
        public Values FilterValue { get; set; }
        public Values FilterKey { get; set; }

    }
    #endregion

    #region ResponseModel

    public class AppCardsResponseModelList
    {
        public string Title { get; set; }       
        public List<AppCardsResponseModel> ComponentData { get; set; }
        public string Position { get; set; }
        public string VariantType { get; set; }

    }
    public class AppCardsResponseModel: BaseComponentModel
    {       
        public string CardName { get; set; }   
    
        public string Image { get; set; }       
        public string OverlayImage { get; set; }
        public string Type { get; set; }

    }
    #endregion

}
