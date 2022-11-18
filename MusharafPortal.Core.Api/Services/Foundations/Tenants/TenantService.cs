using Musharaf.Portal.Core.Api.Brokers.Loggings;
using Musharaf.Portal.Core.Api.Brokers.Storages;
using Musharaf.Portal.Core.Api.Models.Tenants;

namespace Musharaf.Portal.Core.Api.Services.Foundations.Tenants
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
            ValidateTenantOnCreate(tenant);

            return await storageBroker.InsertTenantAsync(tenant);
        });

        public ValueTask<Tenant> RetreiveTenantByIdAsync(Guid Id) =>
        TryCatch(async () =>
        {
            ValidateTenantId(Id);

            Tenant maybeTenant =
                await this.storageBroker.SelectTenantByIdAsync(Id);
            ValidateStorageTenant(maybeTenant, Id);

            return maybeTenant;
        });

        public IQueryable<Tenant> RetrieveAllTenants() =>
        TryCatch(() => this.storageBroker.SelectAllTenants());

        public ValueTask<Tenant> ModifyTenantAsync(Tenant tenant) =>
        TryCatch(async () =>
        {
            ValidateTenantOnModify(tenant);

            Tenant maybeTenant =
                await this.storageBroker.SelectTenantByIdAsync(tenant.Id);

            ValidateStorageTenant(maybeTenant, tenant.Id);
            ValidateAgainstStorageTenantOnModify(tenant, maybeTenant);

            return await this.storageBroker.UpdateTenantAsync(tenant);
        });

        public ValueTask<Tenant> RemoveTenantByIdAsync(Guid Id) =>
        TryCatch(async () =>
        {

            ValidateTenantId(Id);
            Tenant maybeTenant = await storageBroker.SelectTenantByIdAsync(Id);
            ValidateStorageTenant(maybeTenant, Id);

            return await this.storageBroker.DeleteTenantAsync(maybeTenant);
        });
    }
}