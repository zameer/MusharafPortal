using Moq;
using Musharaf.Portal.Core.Api.Models.Tenants;
using Musharaf.Portal.Core.Api.Models.Tenants.Exceptions;

namespace Musharaf.Portal.Core.Api.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRetrieveWhenIdIsInvalidAndLogItAsync()
        {
            // given
            Guid randomTenantId = default;
            Guid inputTenantId = randomTenantId;

            var invalidTenantException = new InvalidTenantException(
                parameterName: nameof(Tenant.Id),
                parameterValue: inputTenantId
                );

            var expectedTenantValidationException = new TenantValidationException(invalidTenantException);

            // when
            ValueTask<Tenant> retrieveTenantByIdTask =
                this.tenantService.RetreiveTenantByIdAsync(inputTenantId);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() => retrieveTenantByIdTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectTenantByIdAsync(It.IsAny<Guid>()),
                Times.Never
            );

            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnRetrieveWhenStorageTenantIsNullAndLogAsync()
        {
            // given
            Guid randonTenantId = Guid.NewGuid();
            Guid inputTenantId = randonTenantId;
            Tenant nullStorageTenant = null;

            var notFoundTenantException = new NotFoundTenantException(inputTenantId);

            var expectedTenantValidationException = new TenantValidationException(notFoundTenantException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectTenantByIdAsync(inputTenantId))
                    .ReturnsAsync(nullStorageTenant);

            // when
            ValueTask<Tenant> retrieveTenantByIdTask =
                this.tenantService.RetreiveTenantByIdAsync(inputTenantId);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() => retrieveTenantByIdTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectTenantByIdAsync(It.IsAny<Guid>()),
                Times.Once
            );

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
