using HPlusSportsWeb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddMvcOptions(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore);

builder.Services
    .AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
    })
    .AddMemoryCache();

ConfigServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


void ConfigServices(IServiceCollection services, IConfiguration config)
{
    var apiAddress = config[Constants.KEY_API_BASE_URI];
    var apiBaseUri = new Uri(apiAddress);
    HttpClient httpClient = new HttpClient
    {
        BaseAddress = apiBaseUri,
        Timeout = new TimeSpan(0,0,60)
    };
    services.AddSingleton(httpClient);
}