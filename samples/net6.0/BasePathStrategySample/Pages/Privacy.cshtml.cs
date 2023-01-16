using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasePathStrategySample.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public TenantInfo? TenantInfo { get; private set; }
    public string HtmlContent { get; set; }

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        TenantInfo = HttpContext.GetMultiTenantContext<TenantInfo>()?.TenantInfo;
        HtmlContent = GetHtmlContentFromDatabase(TenantInfo?.Identifier);
    }

    // Simulate loading contents from database
    private string GetHtmlContentFromDatabase(string tenantName)
    {
        switch (tenantName)
        {
            case "acme":
                return $"<h1>Tenant {tenantName}</h1><br><p>This is the privacy description of tenant {tenantName}</p>";
            case "megacorp":
                return $"<h1>Tenant {tenantName}</h1><br><p>This is the privacy description of tenant {tenantName}</p>";
            case "initech":
                return $"<h1>Tenant {tenantName}</h1><br><p>This is the privacy description of tenant {tenantName}</p>";
            default:
                return string.Empty;
        }
    }
}