using MusharafPortal.Core.Api.Models.Tenants;

namespace MusharafPortal.Core.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Tenant> InsertTenantAsync(Tenant tenant);
        ValueTask<Tenant> SelectTenantByIdAsync(Guid tenantId);
    }
}
