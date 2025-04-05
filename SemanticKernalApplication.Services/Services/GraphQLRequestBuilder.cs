using SemanticKernalApplication.Core;
using SemanticKernalApplication.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.Design;

namespace SemanticKernalApplication.Services
{
    public class GraphQLRequestBuilder : IGraphQLRequestBuilder
    {
        string SitecoreApIKey { get; set; }
        string SC_ApiKeyName { get; set; }
        private readonly string _environment;
        private readonly IOptions<SemanticKernalApplicationSettings> _options;
        private readonly IConfiguration _configuration;
        public GraphQLRequestBuilder(IOptions<SemanticKernalApplicationSettings> options, IConfiguration configuration)
        {
            _options = options;
            _environment = Environment.GetEnvironmentVariable(Constants.APP_Environment);          
            SC_ApiKeyName = options.Value.SitecoreGraphQLSettings.SC_ApiKeyName;
            _configuration = configuration;
        }       
        public GraphQLHttpRequestWithHeaders BuildRequest(string query, object headerVariables)
        {
            if (String.IsNullOrEmpty(_options?.Value?.SitecoreGraphQLSettings.SitecoreApIKey_Override))
            {
                if (_environment == Constants.DevelopmentEnvironment)
                {
                    SitecoreApIKey = (bool)_options?.Value?.EnableKeyVault ? _configuration[_options.Value.SitecoreGraphQLSettings.SitecoreApIKey_Development] : _options.Value.SitecoreGraphQLSettings.SitecoreApIKey;
                }
                else if (_environment == Constants.UATEnvironment)
                    SitecoreApIKey = (bool)_options?.Value?.EnableKeyVault ? _configuration[_options.Value.SitecoreGraphQLSettings.SitecoreApIKey_UAT] : _options.Value.SitecoreGraphQLSettings.SitecoreApIKey_UAT;
                else
                    SitecoreApIKey = (bool)_options?.Value?.EnableKeyVault ? _configuration[_options.Value.SitecoreGraphQLSettings.SitecoreApIKey] : _options.Value.SitecoreGraphQLSettings.SitecoreApIKey;
            }
            else
                SitecoreApIKey = _options.Value.SitecoreGraphQLSettings.SitecoreApIKey;
            return new GraphQLHttpRequestWithHeaders
            {
                Query = query,
                Variables = headerVariables,
                Headers = new Dictionary<string, string>
                {
                    { SC_ApiKeyName, SitecoreApIKey }
                }
            };
        }
        public GraphQLHttpRequestWithHeaders MobileBuildRequest(string query, object headerVariables)
        {
            
            return new GraphQLHttpRequestWithHeaders
            {
                Query = query,
                Variables = headerVariables,
                Headers = new Dictionary<string, string>
                {
                    { SC_ApiKeyName, "R2ZzZUdxOHMvUDNZei9YSHRBZXpWNmc1UHpWbUJlV2pOQlV1NkNSTEdldz18ZHViYWlpbnRlcm44ZDBkLWRpZmNleHBlcmllYTZmNy1wcmVwcm9kLWY2MDc=" }
                }
            };
        }
    }
}
