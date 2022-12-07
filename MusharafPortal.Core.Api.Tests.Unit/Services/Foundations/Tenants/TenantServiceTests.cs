using Moq;
using Musharaf.Portal.Core.Api.Brokers.Loggings;
using Musharaf.Portal.Core.Api.Brokers.Storages;
using Musharaf.Portal.Core.Api.Models.Tenants;
using Musharaf.Portal.Core.Api.Services.Foundations.Tenants;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Musharaf.Portal.Core.Api.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ITenantService tenantService;

        public TenantServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.tenantService = new TenantService(
                loggingBroker: this.loggingBrokerMock.Object,
                storageBroker: this.storageBrokerMock.Object);
        }

        private static Tenant CreateRandomTenant(DateTimeOffset dateTime) =>
            CreateRandomTenantFiller(dateTime).Create();


        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Tenant> CreateRandomTenantFiller(DateTimeOffset dateTime)
        {
            var filler = new Filler<Tenant>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dateTime);

            return filler;
        }

        private static Expression<Func<Exception, bool>> SameValidationExceptionAs(Exception expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message
                && (actualException.InnerException as Xeption).DataEquals(expectedException.InnerException.Data);
        }
    }
}