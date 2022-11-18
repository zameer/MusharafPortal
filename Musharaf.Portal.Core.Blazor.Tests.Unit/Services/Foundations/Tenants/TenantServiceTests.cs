using Moq;
using Musharaf.Portal.Core.Blazor.Brokers.Apis;
using Musharaf.Portal.Core.Blazor.Brokers.Loggings;
using Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.Tenants
{
    public class TenantServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ITenantService tenantService;

        public TenantServiceTests()
        {
            this.apiBrokerMock= new Mock<IApiBroker>();
            this.loggingBrokerMock= new Mock<ILoggingBroker>();
            this.tenantService = new TenantService(
                    apiBroker: this.apiBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object
                );
        }
    }
}
