using Moq;
using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateTenantIfTenantIsNullAndLogItAsync()
        {
            // given
            Tenant invalidTenant = null;
            var nullTenantException = new NullTenantException();

            var expectedTenantValidationException =
                new TenantValidationException(nullTenantException);

            // when
            ValueTask<Tenant> submitTenantTask =
                this.tenantService.CreateTenantAsync(invalidTenant);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() =>
                submitTenantTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(
                    It.Is(SameExceptionAs(expectedTenantValidationException))), 
                        Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()), 
                    Times.Never);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
