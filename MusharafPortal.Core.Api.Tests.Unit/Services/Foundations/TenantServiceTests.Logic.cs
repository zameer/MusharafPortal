using FluentAssertions;
using Moq;
using MusharafPortal.Core.Api.Models.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusharafPortal.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class TenantServiceTests
    {
        [Fact]
        public async Task ShouldAddTenantAsync()
        {
            // given
            Tenant randomTenant = CreateRandomTenant();
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
