namespace SemanticKernalApplication.WebAPI.Models.GraphQLResponseModels
{
    public class ItemSearchResult
    {
        public Result Search { get; set; }
    }

    public class Result
    {
        public int Total { get; set; }
        public PageInfo PageInfo { get; set; }
        public Results[] Results { get; set; }
    }

    public class PageInfo
    {
        public string EndCursor { get; set; }
        public bool HasNext { get; set; }
    }

    public class Results
    {
        public Field[] Fields { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
