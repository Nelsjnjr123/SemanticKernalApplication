namespace SemanticKernalApplication.WebAPI.Interfaces
{
    public interface IHooksRepository
    {
        //Task<bool> ProcessHooksEventsAsync(string data);
        Task<bool> ProcessClearCacheHookAsync(string data);
    }
}