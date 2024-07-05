using Azure.Identity;
using AzureAppConfigDemo;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var endpoint = builder.Configuration["AppConfig:Endpoint"];
var connectionString = builder.Configuration.GetConnectionString("AppConfig");
var snapshot = builder.Configuration["AppConfig:Snapshot"];
builder.Configuration.AddAzureAppConfiguration(options =>
{
    var credential = new DefaultAzureCredential();
    if (endpoint is { Length: > 0 })
    {
        options.Connect(new Uri(endpoint), credential);
    }
    else
    {
        options.Connect(connectionString);
    }
    if (snapshot is { Length: > 0 })
    {
        options.SelectSnapshot(snapshot);
    }
    options
        .ConfigureKeyVault(keyVaultOptions =>
        {
            keyVaultOptions.SetCredential(credential);
        });
});

builder.Services.AddRazorPages();

// Add App Configuration middleware.
builder.Services.AddAzureAppConfiguration();

builder.Services.Configure<Settings>(builder.Configuration.GetSection("TestApp:Settings"));
builder.Services.Configure<Secrets>(builder.Configuration.GetSection("TestApp:Secrets"));

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