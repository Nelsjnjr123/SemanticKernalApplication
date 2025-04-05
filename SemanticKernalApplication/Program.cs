using Microsoft.Extensions.Caching.Memory;
using SemanticKernalApplication.Core;
using SemanticKernalApplication.WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();
builder.Services.AddHybridCache();
builder.Services.Configure<SemanticKernalApplicationSettings>(builder.Configuration.GetSection(SemanticKernalApplicationSettings.Key));
ServiceRegistration.ConfigureServices(builder.Services);

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
