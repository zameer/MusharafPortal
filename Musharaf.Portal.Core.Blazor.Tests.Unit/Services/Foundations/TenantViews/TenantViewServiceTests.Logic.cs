using FluentAssertions;
using Moq;
using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.TenantViews
{
    public partial class TenantViewServiceTests
    {

        [Fact]
        public async Task ShouldAddTenantViewAsync()
        {
            // given
            Guid randomUserId = Guid.NewGuid();
            DateTimeOffset randomDateTime = GetRandomDate();

            dynamic randomTenantViewProperties =
                CreateRandomTenantViewProperties(
                    auditDates: randomDateTime,
                    auditIds: randomUserId);

            var randomTenantView = new TenantView
            {
                Name = randomTenantViewProperties.Name,
                Description = randomTenantViewProperties.Description
            };

            TenantView inputTenantView = randomTenantView;
            TenantView expectedTenantView = inputTenantView;

            var randomTenant = new Tenant
            {
                Id = randomTenantViewProperties.Id,
                Name = randomTenantViewProperties.Name,
                Description = randomTenantViewProperties.Description,
                CreatedBy = randomUserId,
                UpdatedBy = randomUserId,
                CreatedDate = randomDateTime,
                UpdatedDate = randomDateTime
            };

            Tenant expectedInputTenant = randomTenant;
            Tenant returnedTenant = expectedInputTenant;

            this.userServiceMock.Setup(service =>
                service.GetCurrentlyLoggedInUser())
                    .Returns(randomUserId);

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTimeOffset())
                    .Returns(randomDateTime);

            this.tenantServiceMock.Setup(broker =>
                broker.CreateTenantAsync(It.Is(SameTenantAs(expectedInputTenant))))
                    .ReturnsAsync(returnedTenant);

            // when
            TenantView actualTenantView =
                await this.tenantViewService
                    .AddTenantViewAsync(inputTenantView);

            // then
            actualTenantView.Should().BeEquivalentTo(expectedTenantView);

            this.userServiceMock.Verify(service =>
                service.GetCurrentlyLoggedInUser(),
                    Times.Once);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTimeOffset(),
                    Times.Once);

            this.tenantServiceMock.Verify(broker =>
                broker.CreateTenantAsync(It.Is(SameTenantAs(expectedInputTenant))),
                    Times.Once);

            this.userServiceMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.tenantServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}