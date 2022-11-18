using Musharaf.Portal.Core.Api.Models.Tenants;

namespace Musharaf.Portal.Core.Api.Services.Foundatons.Tenants
{
    public interface ITenantService
    {
        ValueTask<Tenant> CreateTenantAsync(Tenant tenant);
        ValueTask<Tenant> RetreiveTenantByIdAsync(Guid Id);
        IQueryable<Tenant> RetrieveAllTenants();
        ValueTask<Tenant> ModifyTenantAsync(Tenant tenant);
        ValueTask<Tenant> RemoveTenantByIdAsync(Guid Id);
    }
}
