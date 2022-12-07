using Musharaf.Portal.Core.Blazor.Brokers.Apis;
using Musharaf.Portal.Core.Blazor.Brokers.Loggings;
using Musharaf.Portal.Core.Blazor.Models.Tenants;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants
{
    public partial class TenantService : ITenantService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public TenantService(
            IApiBroker apiBroker,
            ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Tenant> CreateTenantAsync(Tenant tenant) =>
        TryCatch(async () =>
        {
            ValidateTenantOnCreate(tenant);
            return await this.apiBroker.PostTenantAsync(tenant);
        });

        public ValueTask<Tenant> RemoveTenantByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<Tenant>> RetrieveAllTenantAsync() =>
        TryCatch(async () =>
        {
            return await this.apiBroker.GetAllTenantsAsync();
        });

        public ValueTask<List<Tenant>> RetrieveAllTenantAsync(string query) =>
        TryCatch(async () =>
        {
            return await this.apiBroker.GetAllTenantsAsync(query);
        });

        public ValueTask<int> RetrieveAllTenantCountAsync() =>
        TryCatch(async () =>
        {
            return await this.apiBroker.GetAllTenantsCountAsync();
        });
    }
}
