using KellermanSoftware.CompareNetObjects;
using Moq;
using Musharaf.Portal.Core.Blazor.Brokers.DateTimes;
using Musharaf.Portal.Core.Blazor.Brokers.Loggings;
using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants;
using Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews;
using Musharaf.Portal.Core.Blazor.Services.Foundations.Users;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.TenantViews
{
    public partial class TenantViewServiceTests
    {
        private readonly Mock<ITenantService> tenantServiceMock;
        private readonly Mock<IUserService> userServiceMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ITenantViewService tenantViewService;

        public TenantViewServiceTests()
        {
            this.tenantServiceMock = new Mock<ITenantService>();
            this.userServiceMock = new Mock<IUserService>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            var compareConfig = new ComparisonConfig();
            compareConfig.IgnoreProperty<Tenant>(tenant => tenant.Id);
            this.compareLogic = new CompareLogic(compareConfig);

            this.tenantViewService = new TenantViewService(
                tenantService: this.tenantServiceMock.Object,
                userService: this.userServiceMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private Expression<Func<Tenant, bool>> SameTenantAs(Tenant expectedTenant)
        {
            return actualTenant => this.compareLogic.Compare(expectedTenant, actualTenant)
                .AreEqual;
        }

        private static dynamic CreateRandomTenantViewProperties(
            DateTimeOffset auditDates,
            Guid auditIds)
        {
            return new
            {
                Id = Guid.NewGuid(),
                Name = GetRandomName(),
                Description = GetRandomName(),
                CreatedDate = auditDates,
                UpdatedDate = auditDates,
                CreatedBy = auditIds,
                UpdatedBy = auditIds
            };
        }

        private static TenantView CreateRandomTenantView() =>
            CreateTenantViewFiller().Create();

        private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        private static string GetRandomName() =>
            new RealNames(NameStyle.FirstName).GetValue();

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<TenantView> CreateTenantViewFiller()
        {
            var filler = new Filler<TenantView>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(DateTimeOffset.UtcNow);

            return filler;
        }
    }
}