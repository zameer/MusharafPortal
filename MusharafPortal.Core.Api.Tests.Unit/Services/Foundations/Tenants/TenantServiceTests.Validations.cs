using Moq;
using MusharafPortal.Core.Api.Models.Tenants;
using MusharafPortal.Core.Api.Models.Tenants.Exceptions;

namespace MusharafPortal.Core.Api.Tests.Unit.Services.Foundations.Tenants
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

            this.storageBrokerMock.Verify(broker =>
                broker.InsertTenantAsync(It.IsAny<Tenant>()),
                Times.Never
            );

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
