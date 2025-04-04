using SemanticKernalApplication.Services;
using SemanticKernalApplication.Services.Interfaces;
using SemanticKernalApplication.Services.Services;

using SemanticKernalApplication.WebAPI.Helpers;

using SemanticKernalApplication.WebAPI.Interfaces;
using SemanticKernalApplication.WebAPI.ModelMapping;
using SemanticKernalApplication.WebAPI.Respositories;
using SemanticKernalApplication.WebAPI.Wrapper;


namespace SemanticKernalApplication.WebAPI.Service
{
  /// <summary>
  /// Service registration class
  /// </summary>
  public static class ServiceRegistration
  {
    /// <summary>
    /// Configuring service registrartion for DI
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServices(IServiceCollection services)
    {
    
      services.AddTransient<ILayoutRepository, LayoutRepository>();
      services.AddTransient<IModelMapperService, ModelMapperService>();
      services.AddTransient<IBaseScreenMappingService, ScreenMappingService>();
     
      services.AddTransient<IGraphQLRepository, GraphQLRepository>();
     
      services.AddTransient<IGraphQLService, GraphQLService>();
     
      services.AddTransient<ICacheService, CacheService>();
      services.AddScoped<ICommonHelper, CommonHelper>();
     
      services.AddTransient<IPersonalizationRepository, PersonalizationRepository>();

      services.AddTransient<IGraphQLRequestBuilder, GraphQLRequestBuilder>();
      services.AddScoped<IAPIWrapper, APIWrapper>();
    
    
    }
  }
}

