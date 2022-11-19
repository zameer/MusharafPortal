using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using RESTFulSense.Exceptions;

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
    }
}
