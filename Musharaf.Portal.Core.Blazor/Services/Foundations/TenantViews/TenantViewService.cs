using Musharaf.Portal.Core.Blazor.Brokers.DateTimes;
using Musharaf.Portal.Core.Blazor.Brokers.Loggings;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants;
using Musharaf.Portal.Core.Blazor.Services.Foundations.Users;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public class TenantViewService : ITenantViewService
    {
        private readonly ITenantService tenantService;
        private readonly IUserService userService;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public TenantViewService(
            ITenantService tenantService, 
            IUserService userService, 
            IDateTimeBroker dateTimeBroker, 
            ILoggingBroker loggingBroker)
        {
            this.tenantService = tenantService;
            this.userService = userService;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<TenantView> AddTenantViewAsync(TenantView tenantView)
        {
            throw new NotImplementedException();
        }
    }
}
