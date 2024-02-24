using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace AzureAppConfigDemo.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public Settings Settings { get; init; }

    public IndexModel(IOptionsSnapshot<Settings> options, ILogger<IndexModel> logger)
    {
        _logger = logger;
        Settings = options.Value;
    }

    public void OnGet()
    {
    }
}