using FluentAssertions;
using Moq;
using Musharaf.Portal.Core.Api.Models.Tenants;

namespace Musharaf.Portal.Core.Api.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        [Fact]
        public async Task ShouldAddTenantAsync()
        {
            // given
            DateTimeOffset randomDateTime = GetRandomDateTime();
            DateTimeOffset dateTime = randomDateTime;
            Tenant randomTenant = CreateRandomTenant(dateTime);
            Tenant inputTenant = randomTenant;
            Tenant insertedTenant = inputTenant;
            Tenant expectedTenant = insertedTenant;

            storageBrokerMock.Setup(broker =>
                broker.InsertTenantAsync(inputTenant))
                    .ReturnsAsync(insertedTenant);

            // when
            Tenant actualTenant = await this.tenantService.CreateTenantAsync(inputTenant);

            // then
            actualTenant.Should().BeEquivalentTo(expectedTenant);

            storageBrokerMock.Verify(broker =>
                broker.InsertTenantAsync(inputTenant), Times.Once());

            storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
