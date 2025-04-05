namespace SemanticKernalApplication.WebAPI.Models
{
    public class ItemModel
    {
    }

    public class ItemPublishModel
    {
        public string ActionID { get; set; }
        public string ActionName { get; set; }
        public Comment[] Comments { get; set; }
        public Dataitem DataItem { get; set; }
        public string Message { get; set; }
        public object NextState { get; set; }
        public Previousstate PreviousState { get; set; }
        public string UserName { get; set; }
        public string WorkflowName { get; set; }
        public string WebhookItemId { get; set; }
        public string WebhookItemName { get; set; }
    }

    public class Dataitem
    {
        public string Language { get; set; }
        public int Version { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string TemplateId { get; set; }
        public string MasterId { get; set; }
        public Sharedfield[] SharedFields { get; set; }
        public object[] UnversionedFields { get; set; }
        public ItemFields[] VersionedFields { get; set; }
    }


    public class ItemFields
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class Sharedfield
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class Previousstate
    {
        public string DisplayName { get; set; }
        public bool FinalState { get; set; }
        public string Icon { get; set; }
        public string StateID { get; set; }
        public object[] PreviewPublishingTargets { get; set; }
    }

    public class Comment
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

}
