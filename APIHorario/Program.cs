using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "APIHorario",
        Description = "APIHorario - Testando Output Cache middleware com Web APIs",
        Version = "v1"
    });
});

// Documentacao - OutputCache com Redis:
// https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?preserve-view=true&view=aspnetcore-8.0#redis-cache
builder.Services.AddStackExchangeRedisOutputCache(
    options =>
    {
        options.Configuration = builder.Configuration.GetConnectionString("Redis");
        options.InstanceName = nameof(APIHorario);
    });
builder.Services.AddOutputCache();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseOutputCache();

app.Run();