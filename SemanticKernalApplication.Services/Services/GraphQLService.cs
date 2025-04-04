using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SemanticKernalApplication.Services
{
    public class GraphQLService : IGraphQLService
    {
        string SitecoreGraphQLEndpoint { get; set; }
        private readonly IGraphQLRequestBuilder _graphQLRequestBuilder;
        private readonly HttpClient _httpClient;
        readonly ILogger<GraphQLService> _logger;

        public GraphQLService(IOptions<SemanticKernalApplicationSettings> options, IGraphQLRequestBuilder graphQLRequestBuilder, HttpClient httpClient, ILogger<GraphQLService> logger)
        {
            SitecoreGraphQLEndpoint = options.Value.SitecoreGraphQLSettings.SitecoreGraphQLEndpoint;
            _graphQLRequestBuilder = graphQLRequestBuilder;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<T> GetResultsAsync<T>(string query, object headerVariables,bool isSupportPage=false) where T : class
        {
            if(isSupportPage)
            {
                return await FetchDataMobileAsync<T>(query, headerVariables);
            }
            else
            return await FetchDataAsync<T>(query, headerVariables);
        }

        async Task<T> FetchDataAsync<T>(string query, object headerVariables)
        {
            GraphQLResponse<T> response = new();

            try
            {
                var client = CreateGraphQlClient();
                var request = _graphQLRequestBuilder.BuildRequest(query, headerVariables);
                response = await client.SendQueryAsync<T>(request);
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GraphQLService.FetchDataAsync. Message: {ex.Message}", ex);
            }

            return (T)(object)response.Data;
        }
        async Task<T> FetchDataMobileAsync<T>(string query, object headerVariables)
        {
            GraphQLResponse<T> response = new();
            try
            {
                var client = CreateGraphQlClient();
                var request = _graphQLRequestBuilder.MobileBuildRequest(query, headerVariables);
                response = await client.SendQueryAsync<T>(request);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GraphQLService.FetchDataAsync. Message: {ex.Message}", ex);
            }

            return (T)(object)response.Data;
        }

        private IGraphQLClient CreateGraphQlClient()
        {
            var graphQLHttpClientOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(SitecoreGraphQLEndpoint)
            };

            return new GraphQLHttpClient(graphQLHttpClientOptions, new NewtonsoftJsonSerializer(), _httpClient);
        }
    }
}
