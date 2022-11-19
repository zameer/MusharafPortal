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

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateIfTenantIdIsInvalidAndLogItAsync()
        {
            // given
            Guid invalidId = Guid.Empty;
            Tenant randomTenant = CreateRandomTenant();
            Tenant invalidTenant = randomTenant;
            invalidTenant.Id = invalidId;

            var invalidTenantException = 
                new InvalidTenantException(
                    parameterName: nameof(Tenant.Id),
                    parameterValue: invalidTenant.Id);

            var expectedTenantValidationException = new TenantValidationException(invalidTenantException);

            // when
            ValueTask<Tenant> createTenantTask =
                this.tenantService.CreateTenantAsync(invalidTenant);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() =>
                createTenantTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.IsAny<TenantValidationException>()),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.apiBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnCreateIfTenantNameIsInvalidAndLogItAsync(
            string tenantName)
        {
            // given
            string invalidName = tenantName;
            Tenant randomTenant = CreateRandomTenant();
            Tenant invalidTenant = randomTenant;
            invalidTenant.Name = invalidName;

            var invalidTenantException =
                new InvalidTenantException(
                    parameterName: nameof(Tenant.Name),
                    parameterValue: invalidTenant.Name);

            var expectedTenantValidationException = new TenantValidationException(invalidTenantException);

            // when
            ValueTask<Tenant> createTenantTask =
                this.tenantService.CreateTenantAsync(invalidTenant);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() =>
                createTenantTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.IsAny<TenantValidationException>()),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.apiBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateIfCreatedByIsInvalidAndLogItAsync()
        {
            // given
            Guid invalidId = Guid.Empty;
            Tenant randomTenant = CreateRandomTenant();
            Tenant invalidTenant = randomTenant;
            invalidTenant.CreatedBy = invalidId;

            var invalidTenantException =
                new InvalidTenantException(
                    parameterName: nameof(Tenant.CreatedBy),
                    parameterValue: invalidTenant.CreatedBy);

            var expectedTenantValidationException = new TenantValidationException(invalidTenantException);

            // when
            ValueTask<Tenant> createTenantTask =
                this.tenantService.CreateTenantAsync(invalidTenant);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() =>
                createTenantTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.IsAny<TenantValidationException>()),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.apiBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateIfCreatedDateIsInvalidAndLogItAsync()
        {
            // given
            DateTimeOffset invalidDate = default;
            Tenant randomTenant = CreateRandomTenant();
            Tenant invalidTenant = randomTenant;
            invalidTenant.CreatedDate = invalidDate;

            var invalidTenantException =
                new InvalidTenantException(
                    parameterName: nameof(Tenant.CreatedDate),
                    parameterValue: invalidTenant.CreatedDate);

            var expectedTenantValidationException = new TenantValidationException(invalidTenantException);

            // when
            ValueTask<Tenant> createTenantTask =
                this.tenantService.CreateTenantAsync(invalidTenant);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() =>
                createTenantTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.IsAny<TenantValidationException>()),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.apiBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateIfUpdatedByIsInvalidAndLogItAsync()
        {
            // given
            Guid invalidId = Guid.Empty;
            Tenant randomTenant = CreateRandomTenant();
            Tenant invalidTenant = randomTenant;
            invalidTenant.UpdatedBy = invalidId;

            var invalidTenantException =
                new InvalidTenantException(
                    parameterName: nameof(Tenant.UpdatedBy),
                    parameterValue: invalidTenant.UpdatedBy);

            var expectedTenantValidationException = new TenantValidationException(invalidTenantException);

            // when
            ValueTask<Tenant> createTenantTask =
                this.tenantService.CreateTenantAsync(invalidTenant);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() =>
                createTenantTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.IsAny<TenantValidationException>()),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.apiBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateIfUpdatedDateIsInvalidAndLogItAsync()
        {
            // given
            DateTimeOffset invalidDate = default;
            Tenant randomTenant = CreateRandomTenant();
            Tenant invalidTenant = randomTenant;
            invalidTenant.UpdatedDate = invalidDate;

            var invalidTenantException =
                new InvalidTenantException(
                    parameterName: nameof(Tenant.UpdatedDate),
                    parameterValue: invalidTenant.UpdatedDate);

            var expectedTenantValidationException = new TenantValidationException(invalidTenantException);

            // when
            ValueTask<Tenant> createTenantTask =
                this.tenantService.CreateTenantAsync(invalidTenant);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() =>
                createTenantTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.IsAny<TenantValidationException>()),
                    Times.Once);

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.apiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
