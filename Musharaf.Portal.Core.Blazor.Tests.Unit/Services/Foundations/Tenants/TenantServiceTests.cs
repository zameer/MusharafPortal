using Moq;
using Musharaf.Portal.Core.Blazor.Brokers.Apis;
using Musharaf.Portal.Core.Blazor.Brokers.Loggings;
using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        private readonly Mock<IApiBroker> apiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ITenantService tenantService;

        public TenantServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.tenantService = new TenantService(
                    apiBroker: this.apiBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object
                );
        }

        private static Tenant CreateRandomTenant() =>
            CreateTenantFiller().Create();

        private Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        private static Filler<Tenant> CreateTenantFiller()
        {
            var filler = new Filler<Tenant>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(DateTimeOffset.UtcNow);

            return filler;
        }
    }
}
