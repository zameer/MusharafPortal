using Musharaf.Portal.Core.Blazor.Models.Tenants;

namespace Musharaf.Portal.Core.Blazor.Brokers.Apis
{
    public partial class ApiBroker
    {
        private const string RelativeUrl = "api/tenants";
        public async ValueTask<Tenant> PostTenantAsync(Tenant tenant) =>
            await this.PostAsync(RelativeUrl, tenant);
    }
}
