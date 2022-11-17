using MusharafPortal.Core.Api.Models.Tenants;

namespace MusharafPortal.Core.Api.Services.Foundatons.Tenants
{
    public interface ITenantService
    {
        ValueTask<Tenant> CreateTenantAsync(Tenant tenant);
    }
}
