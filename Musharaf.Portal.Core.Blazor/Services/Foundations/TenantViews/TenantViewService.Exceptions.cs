using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;
using OtripleS.Portal.Web.Models.StudentViews.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public partial class TenantViewService
    {
        private delegate ValueTask<TenantView> ReturningTenantViewFunction();
        private delegate ValueTask<List<TenantView>> ReturningTenantViewsFunction();
        private delegate ValueTask<int> ReturningTenantViewsCountFunction();

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

        private async ValueTask<List<TenantView>> TryCatch(ReturningTenantViewsFunction returningTenantViewsFunction)
        {
            try
            {
                return await returningTenantViewsFunction();
            }
            catch (TenantDependencyException tenantDependencyException)
            {
                throw CreateAndLogDependencyException(tenantDependencyException);
            }
            catch (TenantServiceException tenantServiceException)
            {
                throw CreateAndLogDependencyException(tenantServiceException);
            }
            catch (Exception serviceException)
            {
                var failedTenantViewServiceException = new FailedTenantViewServiceException(serviceException);

                throw CreateAndLogServiceException(failedTenantViewServiceException);
            }
        }

        private async ValueTask<int> TryCatch(ReturningTenantViewsCountFunction returningTenantViewsCountFunction)
        {
            try
            {
                return await returningTenantViewsCountFunction();
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
        private TenantViewDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var tenantViewDependencyException = new TenantViewDependencyException(exception);
            this.loggingBroker.LogError(tenantViewDependencyException);

            return tenantViewDependencyException;
        }

        private TenantViewValidationException CreateAndLogValidationException(Exception exception)
        {
            var tenantViewValidationException = new TenantViewValidationException(exception.InnerException);
            this.loggingBroker.LogError(tenantViewValidationException);

            return tenantViewValidationException;
        }

        private TenantViewServiceException CreateAndLogServiceException(Exception exception)
        {
            var tenantViewServiceException = new TenantViewServiceException(exception);
            this.loggingBroker.LogError(tenantViewServiceException);

            return tenantViewServiceException;
        }
    }
}
