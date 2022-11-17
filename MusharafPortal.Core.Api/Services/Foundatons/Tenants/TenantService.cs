using MusharafPortal.Core.Api.Brokers.Loggings;
using MusharafPortal.Core.Api.Brokers.Storages;
using MusharafPortal.Core.Api.Models.Tenants;
using MusharafPortal.Core.Api.Models.Tenants.Exceptions;

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

        public async ValueTask<Tenant> CreateTenantAsync(Tenant tenant)
        {
            try
            {
                ValidateTenant(tenant);
                return await storageBroker.InsertTenantAsync(tenant);
            }
            catch (NullTenantException nullTenantException)
            {
                throw CreateAndLogValidationException(exception: nullTenantException);
            }
        }

        private TenantValidationException CreateAndLogValidationException(Exception exception)
        {
            var tenantValidationException = new TenantValidationException(exception);
            this.loggingBroker.LogError(tenantValidationException);
         
            return tenantValidationException;
        }
    }
}
