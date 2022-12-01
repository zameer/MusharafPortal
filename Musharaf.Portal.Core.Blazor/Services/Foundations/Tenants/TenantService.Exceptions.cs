using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using RESTFulSense.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants
{
    public partial class TenantService
    {
        private delegate ValueTask<Tenant> ReturningTenantFunction();
        private delegate ValueTask<List<Tenant>> ReturningTenantsFunction();

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
            catch (InvalidTenantException invalidTenantException)
            {
                throw CreateAndLogValidationException(invalidTenantException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                throw CreateAndLogCriticalDependencyException(httpResponseUrlNotFoundException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                throw CreateAndLogCriticalDependencyException(httpResponseUnauthorizedException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                throw CreateAndLogDependencyValidationException(httpResponseBadRequestException);
            }
            catch (HttpResponseConflictException httpResponseConflictException)
            {
                throw CreateAndLogDependencyValidationException(httpResponseConflictException);
            }
            catch (HttpResponseInternalServerErrorException httpResponseInternalServerErrorException)
            {
                throw CreateAndLogDependencyException(httpResponseInternalServerErrorException);
            }
            catch (HttpResponseException httpResponseException)
            {
                throw CreateAndLogDependencyException(httpResponseException);
            }
            catch(Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }


        private async ValueTask<List<Tenant>> TryCatch(ReturningTenantsFunction returningTenantsFunction)
        {
            try
            {
                return await returningTenantsFunction();
            }
            catch (HttpRequestException httpRequestException)
            {
                var failedTenantDependencyException =
                    new FailedTenantDependencyException(httpRequestException);

                throw CreateAndLogCriticalDependencyException(failedTenantDependencyException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedTenantDependencyException =
                    new FailedTenantDependencyException(httpResponseUrlNotFoundException);

                throw CreateAndLogCriticalDependencyException(failedTenantDependencyException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var failedTenantDependencyException =
                    new FailedTenantDependencyException(httpResponseUnauthorizedException);

                throw CreateAndLogCriticalDependencyException(failedTenantDependencyException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedTenantDependencyException =
                    new FailedTenantDependencyException(httpResponseException);

                throw CreateAndLogDependencyException(failedTenantDependencyException);
            }
        }

        private TenantValidationException CreateAndLogValidationException(Exception exception)
        {
            var tenantValidationException = new TenantValidationException(exception);
            this.loggingBroker.LogError(tenantValidationException);

            return tenantValidationException;
        }

        private TenantDependencyValidationException CreateAndLogDependencyValidationException(Exception exception)
        {
            var tenantDependencyValidationException = new TenantDependencyValidationException(exception);
            this.loggingBroker.LogError(tenantDependencyValidationException);

            return tenantDependencyValidationException;
        }
        private TenantDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var tenantDependencyException = new TenantDependencyException(exception);
            this.loggingBroker.LogCritical(tenantDependencyException);

            return tenantDependencyException;
        }

        private TenantDependencyValidationException CreateAndLogDependencyException(Exception exception)
        {
            var tenantDependencyException = new TenantDependencyValidationException(exception);
            this.loggingBroker.LogError(tenantDependencyException);

            return tenantDependencyException;
        }
        private TenantServiceException CreateAndLogServiceException(Exception exception)
        {
            var tenantServiceException = new TenantServiceException(exception);
            this.loggingBroker.LogError(tenantServiceException);

            return tenantServiceException;
        }
    }
}
