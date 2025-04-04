namespace SemanticKernalApplication.Services.Interfaces
{
    public interface IGraphQLService
    {
        
        Task<T> GetResultsAsync<T>(string query, object headerVariables, bool isSupportPage = false) where T : class;
    }
}