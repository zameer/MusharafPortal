using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants
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
                throw CreateAndLogValidationException(nullTenantException);
            }
        }

        private TenantValidationException CreateAndLogValidationException(NullTenantException nullTenantException)
        {
            var tenantValidationException = new TenantValidationException(nullTenantException);
            this.loggingBroker.LogError(tenantValidationException);

            return tenantValidationException;
        }
    }
}
