using Musharaf.Portal.Core.Blazor.Models.Tenants;

namespace Musharaf.Portal.Core.Blazor.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<Tenant> PostTenantAsync(Tenant tenant);
        ValueTask<List<Tenant>> GetAllTenantsAsync();
        ValueTask<List<Tenant>> GetAllTenantsAsync(string query);
        ValueTask<Tenant> GetTenantByIdAsync(Guid Id);
        ValueTask<int> GetAllTenantsCountAsync();
        ValueTask<Tenant> RemoveTenantByIdAsync(Guid Id);
    }
}
