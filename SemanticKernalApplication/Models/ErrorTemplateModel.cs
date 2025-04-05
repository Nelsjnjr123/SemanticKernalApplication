namespace SemanticKernalApplication.WebAPI.Models
{
    public class ItemBaseModel
    {
        public ItemBaseModel(string itemName, string itemId, string templateId, string language, int version, string objectID)
        {
            ItemName = itemName;
            ItemId = itemId;
            TemplateId = templateId;
            Language = language;
            Version = version;
            ObjectID = objectID;
        }
        public ItemBaseModel(ItemBaseModel theBase)
        {
            ItemName = theBase?.ItemName;
            ItemId = theBase?.ItemId;
            TemplateId = theBase?.TemplateId;
            Language = theBase?.Language;
            Version = theBase?.Version;
            ObjectID = theBase?.ObjectID;
        }
        public string ItemName { get; set; }
        public string ItemId { get; set; }
        public string TemplateId { get; set; }
        public string Language { get; set; }
        public int? Version { get; set; }
        public string ObjectID { get; set; }
    }
    public class Item : ItemBaseModel
    {
        public Item(ItemBaseModel itemBaseModel) : base(itemBaseModel)
        {

        }

        public string Key { get; set; }
        public string Message { get; set; }

    }


    public class ItemSearchResult
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public int total { get; set; }
        public Pageinfo pageInfo { get; set; }
        public Results[] results { get; set; }
    }

    public class Pageinfo
    {
        public string endCursor { get; set; }
        public bool hasNext { get; set; }
    }

    public class Results
    {
        public string id { get; set; }
        public Language language { get; set; }
        public Template template { get; set; }
        public Field[] fields { get; set; }
        public string path { get; set; }
        public Url url { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
    }

    public class Template
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Url
    {
        public string path { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }


}
