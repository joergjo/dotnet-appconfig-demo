using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement.Mvc;

namespace AzureAppConfigDemo.Pages;

[FeatureGate("Beta")]
public class Beta : PageModel
{
    public void OnGet()
    {
    }
}