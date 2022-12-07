using Musharaf.Portal.Core.Blazor.Models.Tenants;

namespace Musharaf.Portal.Core.Blazor.Brokers.Apis
{
    public partial class ApiBroker
    {
        private const string RelativeUrl = "api/tenants";
        public async ValueTask<Tenant> PostTenantAsync(Tenant tenant) =>
            await this.PostAsync(RelativeUrl, tenant);

        public async ValueTask<List<Tenant>> GetAllTenantsAsync() =>
            await this.GetAsync<List<Tenant>>(RelativeUrl);

        public async ValueTask<List<Tenant>> GetAllTenantsAsync(string query) =>
            await this.GetAsync<List<Tenant>>($"{RelativeUrl}{query}");

        public async ValueTask<int> GetAllTenantsCountAsync() =>
            await this.GetAsync<int>($"{RelativeUrl}/count");

        public async ValueTask<Tenant> RemoveTenantByIdAsync(Guid Id) =>
            await this.DeleteAsync<Tenant>($"{RelativeUrl}/{Id}");

        public async ValueTask<Tenant> GetTenantByIdAsync(Guid Id) =>
            await this.GetAsync<Tenant>($"{RelativeUrl}/{Id}");
    }
}
