using Musharaf.Portal.Core.Blazor.Models.TenantViews;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public interface ITenantViewService
    {
        ValueTask<TenantView> AddTenantViewAsync(TenantView tenantView);
        ValueTask<TenantView> EditTenantViewAsync(TenantView tenantView);
        ValueTask<List<TenantView>> RetrieveAllTenantViewsAsync();
        ValueTask<List<TenantView>> RetrieveAllTenantViewsAsync(string query);
        ValueTask<int> RetrieveAllTenantViewsCountAsync();
        ValueTask<TenantView> RemoveTenantByIdAsync(Guid Id);
        ValueTask<TenantView> RetrieveTenantByIdAsync(Guid Id);
    }
}
