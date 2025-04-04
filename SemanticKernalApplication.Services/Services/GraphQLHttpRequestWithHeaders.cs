using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;

namespace SemanticKernalApplication.Services
{
    public class GraphQLHttpRequestWithHeaders : GraphQLHttpRequest
    {
        public IDictionary<string, string> Headers { get; set; }

        public override HttpRequestMessage ToHttpRequestMessage(GraphQLHttpClientOptions options, IGraphQLJsonSerializer serializer)
        {
            var request = base.ToHttpRequestMessage(options, serializer);

            if (Headers.Any())
            {
                foreach (var keyVal in Headers)
                {
                    request.Headers.Add(keyVal.Key, keyVal.Value);
                }
            }

            return request;
        }
    }
}
