var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SemanticKernalApplication>("semantickernalapplication");

builder.Build().Run();
