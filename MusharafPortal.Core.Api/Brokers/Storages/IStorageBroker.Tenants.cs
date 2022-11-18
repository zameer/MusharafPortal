using Musharaf.Portal.Core.Api.Models.Tenants;

namespace Musharaf.Portal.Core.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Tenant> InsertTenantAsync(Tenant tenant);
        IQueryable<Tenant> SelectAllTenants();
        ValueTask<Tenant> SelectTenantByIdAsync(Guid tenantId);
        ValueTask<Tenant> UpdateTenantAsync(Tenant tenant);
        ValueTask<Tenant> DeleteTenantAsync(Tenant tenant);
    }
}
