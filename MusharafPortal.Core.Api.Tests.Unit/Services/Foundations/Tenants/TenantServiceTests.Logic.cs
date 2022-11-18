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
            insertedTenant = await tenantService.CreateTenantAsync(inputTenant);

            // then
            insertedTenant.Should().BeEquivalentTo(insertedTenant);

            storageBrokerMock.Verify(broker =>
                broker.InsertTenantAsync(inputTenant), Times.Once());

            storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
