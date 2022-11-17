using MusharafPortal.Core.Api.Models.Tenants;
using MusharafPortal.Core.Api.Models.Tenants.Exceptions;

namespace MusharafPortal.Core.Api.Services.Foundatons.Tenants
{
    public partial class TenantService
    {
        private delegate ValueTask<Tenant> ReturningTenantFunction();

        private async ValueTask<Tenant> TryCatch(ReturningTenantFunction returningTenantFunction)
        {
            try
            {
                return await returningTenantFunction();
            }
            catch (NullTenantException nullTenantException)
            {
                throw CreateAndLogValidationException(exception: nullTenantException);
            }
            catch (NotFoundTenantException notFoundTenantException)
            {
                throw CreateAndLogValidationException(exception: notFoundTenantException);
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
