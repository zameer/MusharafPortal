using Moq;
using MusharafPortal.Core.Api.Brokers.Storages;
using MusharafPortal.Core.Api.Models.Tenants;
using MusharafPortal.Core.Api.Services.Foundatons.Tenants;
using Tynamix.ObjectFiller;

namespace MusharafPortal.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class TenantServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly ITenantService tenantService;

        public TenantServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.tenantService = new TenantService(
                storageBroker: this.storageBrokerMock.Object);
        }

        private static Tenant CreateRandomTenant() =>
            CreateRandomTenantFiller().Create();

        private static Filler<Tenant> CreateRandomTenantFiller() =>
            new Filler<Tenant>();
    }
}