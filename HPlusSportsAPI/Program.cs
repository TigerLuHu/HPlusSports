using HPlusSports.Shared.Cosmos;
using HPlusSports.Shared.Cosmos.Extensions;
using HPlusSports.Shared.Models;

using HPlusSportsAPI;
using HPlusSportsAPI.Services.Domain;
using HPlusSportsAPI.Services.Ropository;

using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HPlusSports API",
        Version = "1.0",
        Description = "Product API for HPlusSports"
    });
});

ConfigServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "HPlus Sports");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigServices(IServiceCollection services, IConfiguration configuration)
{
    ConfigCosmosDBService(services, configuration);
    ConfigDomainService(services, configuration);
}

void ConfigCosmosDBService(IServiceCollection services, IConfiguration configuration)
{
    var cosmosDBConfig = configuration.GetSection(Constants.KEY_DB_CONFIG);
    services.Configure<CosmosDBOptions>(cosmosDBConfig);
    services.AddCosmosService();

    services.TryAddScoped<IProductRepository<ProductBase>, ProductRepository<ProductBase>>();
}

void ConfigDomainService(IServiceCollection services, IConfiguration configuration)
{
    services.AddScoped<IProductService<ProductBase>, ProductService<ProductBase>>();
}
