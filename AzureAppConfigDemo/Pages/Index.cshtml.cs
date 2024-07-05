using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace AzureAppConfigDemo.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public Settings Settings { get; init; }
    public Secrets Secrets { get; init; }

    public IndexModel(IOptionsSnapshot<Settings> options, IOptionsSnapshot<Secrets> secrets, ILogger<IndexModel> logger)
    {
        _logger = logger;
        Settings = options.Value;
        Secrets = secrets.Value;
    }

    public void OnGet()
    {
    }
}