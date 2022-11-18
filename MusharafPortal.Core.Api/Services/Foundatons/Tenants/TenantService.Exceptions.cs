using Musharaf.Portal.Core.Api.Models.Tenants;
using Musharaf.Portal.Core.Api.Models.Tenants.Exceptions;
using System.Data.SqlClient;

namespace Musharaf.Portal.Core.Api.Services.Foundatons.Tenants
{
    public partial class TenantService
    {
        private delegate ValueTask<Tenant> ReturningTenantFunction();

        private delegate IQueryable<Tenant> ReturningTenantsFunction();

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
            catch (InvalidTenantException invalidTenantException)
            {
                throw CreateAndLogValidationException(exception: invalidTenantException);
            }
        }

        private IQueryable<Tenant> TryCatch(ReturningTenantsFunction returningTenantsFunction)
        {
            try
            {
                return returningTenantsFunction();
            }
            catch (SqlException sqlException)
            {
                throw CreateAndLogCriticalDependencyException(sqlException);
            }
            catch (Exception exception)
            {
                var failedTenantServiceException =
                    new FailedTenantServiceException(exception);

                throw CreateAndLogServiceException(failedTenantServiceException);
            }
        }

        private TenantServiceException CreateAndLogServiceException(Exception exception)
        {
            var tenantServiceException = new TenantServiceException(exception);
            this.loggingBroker.LogError(tenantServiceException);

            return tenantServiceException;
        }

        private TenantValidationException CreateAndLogValidationException(Exception exception)
        {
            var tenantValidationException = new TenantValidationException(exception);
            this.loggingBroker.LogError(tenantValidationException);

            return tenantValidationException;
        }

        private TenantDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var tenantDependencyException = new TenantDependencyException(exception);
            this.loggingBroker.LogCritical(tenantDependencyException);

            return tenantDependencyException;
        }
    }
}
