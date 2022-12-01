using Musharaf.Portal.Core.Blazor.Models.Tenants;

namespace Musharaf.Portal.Core.Blazor.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<Tenant> PostTenantAsync(Tenant tenant);
        ValueTask<List<Tenant>> GetAllTenantsAsync();
        ValueTask<List<Tenant>> GetAllTenantsAsync(string query);
        ValueTask<int> GetAllTenantsCountAsync();
    }
}
