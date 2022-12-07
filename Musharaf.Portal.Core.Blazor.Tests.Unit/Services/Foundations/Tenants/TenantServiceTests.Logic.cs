using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Musharaf.Portal.Core.Blazor.Models.Tenants;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        [Fact]
        public async Task ShouldCreateTenantAsync()
        {
            // given
            Tenant randomTenant = CreateRandomTenant();
            Tenant inputTenant = randomTenant;
            Tenant retrievedTenant = inputTenant;
            Tenant expectedTenant = retrievedTenant;

            this.apiBrokerMock.Setup(broker =>
                broker.PostTenantAsync(inputTenant))
                .ReturnsAsync(retrievedTenant);

            // when
            Tenant actualTenant =
                await this.tenantService
                .CreateTenantAsync(inputTenant);

            // then
            actualTenant.Should().BeEquivalentTo(expectedTenant);

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(inputTenant),
                Times.Once());

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task ShouldDeleteTenantAsync()
        {
            // given
            Tenant randomTenant = CreateRandomTenant();
            Tenant storageTenant = randomTenant;
            Tenant expectedTenant = storageTenant.DeepClone();

            Guid inputTenantId = randomTenant.Id;

            this.apiBrokerMock.Setup(broker =>
                broker.RemoveTenantByIdAsync(inputTenantId))
                .ReturnsAsync(storageTenant);

            // when
            Tenant deletedTenant =
                await this.tenantService
                .RemoveTenantByIdAsync(inputTenantId);

            // then
            deletedTenant.Should().BeEquivalentTo(expectedTenant);

            this.apiBrokerMock.Verify(broker =>
                broker.RemoveTenantByIdAsync(inputTenantId),
                Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
