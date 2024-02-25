using AzureAppConfigDemo;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AppConfig");
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options
        .Connect(connectionString)
        .Select("TestApp:*", LabelFilter.Null)
        .Select("TestApp:*", builder.Environment.EnvironmentName)
        .ConfigureRefresh(refreshOptions =>
        {
            // Default cache expiration is 30 seconds, lowering it for demo purposes.
            refreshOptions
                .Register("TestApp:Settings:Sentinel", refreshAll: true)
                .SetCacheExpiration(TimeSpan.FromSeconds(15));
        })
        .UseFeatureFlags();
});

builder.Services.AddRazorPages();
// Add App Configuration middleware.
builder.Services.AddAzureAppConfiguration();

// Add feature management services.
builder.Services.AddFeatureManagement();


builder.Services.Configure<Settings>(builder.Configuration.GetSection("TestApp:Settings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Enable middleware to trigger request driven refresh.
app.UseAzureAppConfiguration();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();