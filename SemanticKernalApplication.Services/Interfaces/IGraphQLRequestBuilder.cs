namespace SemanticKernalApplication.Services.Interfaces
{
    public interface IGraphQLRequestBuilder
    {
        public GraphQLHttpRequestWithHeaders BuildRequest(string query, object headerVariables);
        public GraphQLHttpRequestWithHeaders MobileBuildRequest(string query, object headerVariables);
    }
}
