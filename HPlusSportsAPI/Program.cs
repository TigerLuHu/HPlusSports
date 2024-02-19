using HPlusSports.Shared.Blob;
using HPlusSports.Shared.Blob.Extensions;
using HPlusSports.Shared.Cosmos;
using HPlusSports.Shared.Cosmos.Extensions;
using HPlusSports.Shared.Models;
using HPlusSports.Shared.Queue;
using HPlusSports.Shared.Queue.Extensions;
using HPlusSports.Shared.Table;
using HPlusSports.Shared.Table.Extensions;

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
    ConfigBlobService(services, configuration);
    ConfigAzureQueueService(services, configuration);
    ConfigAzureTableService(services, configuration);
    ConfigDomainService(services, configuration);
}

void ConfigCosmosDBService(IServiceCollection services, IConfiguration configuration)
{
    var cosmosDBConfig = configuration.GetSection(Constants.KEY_COSMOSDB);
    services
        .Configure<CosmosDBOptions>(cosmosDBConfig)
        .AddCosmosService();
}

void ConfigBlobService(IServiceCollection services, IConfiguration configuration)
{
    var azureStorageConfig = configuration.GetSection(Constants.KEY_AZURE_STORAGE);
    services
        .Configure<BlobOptions>(azureStorageConfig)
        .AddBlobServices();
}

void ConfigAzureQueueService(IServiceCollection services, IConfiguration configuration)
{
    var azureStorageConfig = configuration.GetSection(Constants.KEY_AZURE_STORAGE);
    services
        .Configure<AzureQueueOptions>(azureStorageConfig)
        .AddAzureQueueServices();
}

void ConfigAzureTableService(IServiceCollection services, IConfiguration configuration)
{
    var azureStorageConfig = configuration.GetSection(Constants.KEY_AZURE_STORAGE);
    services
        .Configure<AzureTableOptions>(azureStorageConfig)
        .AddAzureTableServices();
}

void ConfigDomainService(IServiceCollection services, IConfiguration configuration)
{
    services.AddScoped<IProductService<ProductBase>, ProductService<ProductBase>>();
    services.TryAddScoped<IProductRepository<ProductBase>, ProductRepository<ProductBase>>();
    var imageConfig = configuration.GetSection(Constants.KEY_Image);
    services.Configure<ImageOptions>(imageConfig);
    services.AddScoped<IImageService, ImageService>();
    services.AddScoped<IOrderService, OrderService>();
}
