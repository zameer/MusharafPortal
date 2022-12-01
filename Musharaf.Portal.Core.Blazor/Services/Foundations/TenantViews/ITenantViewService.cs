using Musharaf.Portal.Core.Blazor.Models.TenantViews;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public interface ITenantViewService
    {
        ValueTask<TenantView> AddTenantViewAsync(TenantView tenantView);
        ValueTask<List<TenantView>> RetrieveAllTenantViewsAsync();
        ValueTask<List<TenantView>> RetrieveAllTenantViewsAsync(string query);
        ValueTask<int> RetrieveAllTenantViewsCountAsync();
    }
}
