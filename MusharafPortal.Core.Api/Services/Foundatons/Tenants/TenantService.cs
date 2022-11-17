using MusharafPortal.Core.Api.Brokers.Loggings;
using MusharafPortal.Core.Api.Brokers.Storages;
using MusharafPortal.Core.Api.Models.Tenants;

namespace MusharafPortal.Core.Api.Services.Foundatons.Tenants
{
    public partial class TenantService : ITenantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public TenantService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Tenant> CreateTenantAsync(Tenant tenant) =>
        TryCatch(async () =>
        {
            ValidateTenant(tenant);

            return await storageBroker.InsertTenantAsync(tenant);
        });

        public ValueTask<Tenant> RetreiveTenantByIdAsync(Guid Id) => 
        TryCatch(async () =>
        {
            ValidateTenantId(Id);
            Tenant maybeTenant = await storageBroker.SelectTenantByIdAsync(Id);
            ValidateStorageTenant(maybeTenant, Id);

            return maybeTenant;
        });
    }
}