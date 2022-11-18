using FluentAssertions;
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

    }
}
