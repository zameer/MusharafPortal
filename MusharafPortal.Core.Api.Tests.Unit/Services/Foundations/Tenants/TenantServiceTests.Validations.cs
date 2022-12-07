using Moq;
using Musharaf.Portal.Core.Api.Models.Tenants;
using Musharaf.Portal.Core.Api.Models.Tenants.Exceptions;

namespace Musharaf.Portal.Core.Api.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateWhenTenantIsNullAndLogItAsync()
        {
            // given
            Tenant randomTenant = null;
            Tenant nullTenant = randomTenant;

            var nullTenantException = new NullTenantException();

            var expectedNullTenantValidationException =
                new TenantValidationException(nullTenantException);

            // when
            ValueTask<Tenant> createTenantTask =
                this.tenantService.CreateTenantAsync(nullTenant);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() =>
                createTenantTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameValidationExceptionAs(expectedNullTenantValidationException))), 
                Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
