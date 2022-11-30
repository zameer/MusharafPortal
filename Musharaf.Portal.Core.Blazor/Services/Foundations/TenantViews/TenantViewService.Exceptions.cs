using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public partial class TenantViewService
    {
        private delegate ValueTask<TenantView> ReturningTenantViewFunction();

        private async ValueTask<TenantView> TryCatch(ReturningTenantViewFunction returningTenantViewFunction)
        {
            try
            {
                return await returningTenantViewFunction();
            }
            catch (NullTenantViewException nullTenantViewException)
            {
                throw CreateAndLogValidationException(nullTenantViewException);
            }
            catch (InvalidTenantViewException invalidTenantViewException)
            {
                throw CreateAndLogValidationException(invalidTenantViewException);
            }
            catch (TenantValidationException studentValidationException)
            {
                throw CreateAndLogValidationException(studentValidationException);
            }
        }

        private TenantViewValidationException CreateAndLogValidationException(Exception exception)
        {
            var tenantViewValidationException = new TenantViewValidationException(exception.InnerException);
            this.loggingBroker.LogError(tenantViewValidationException);

            return tenantViewValidationException;
        }
    }
}
