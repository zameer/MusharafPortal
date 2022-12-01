using Musharaf.Portal.Core.Blazor.Models.Tenants;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants
{
    public interface ITenantService
    {
        ValueTask<Tenant> CreateTenantAsync(Tenant tenant);
        ValueTask<List<Tenant>> RetrieveAllTenantAsync();
        ValueTask<List<Tenant>> RetrieveAllTenantAsync(string query);
        ValueTask<int> RetrieveAllTenantCountAsync();
    }
}
