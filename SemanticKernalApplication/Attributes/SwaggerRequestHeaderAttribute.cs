namespace SemanticKernalApplication.WebAPI.Attributes
{
    /// <summary>
    /// Custom header attribute for Swagger
    /// </summary>
    public class SwaggerRequestHeaderAttribute : Attribute
    {
        #region property
        public string HeaderName { get; }
        public string Description { get; }
        public string DefaultValue { get; }
        public bool IsRequired { get; }
        #endregion
        #region constructor

        public SwaggerRequestHeaderAttribute(string headerName, string description = null, string defaultValue = null, bool isRequired = false)
        {
            HeaderName = headerName;
            Description = description;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
        }
        #endregion
    }
}
