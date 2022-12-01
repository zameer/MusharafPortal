using Musharaf.Portal.Core.Blazor.Brokers.DateTimes;
using Musharaf.Portal.Core.Blazor.Brokers.Loggings;
using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants;
using Musharaf.Portal.Core.Blazor.Services.Foundations.Users;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public partial class TenantViewService : ITenantViewService
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

        public ValueTask<TenantView> AddTenantViewAsync(TenantView tenantView) =>
            TryCatch(async () =>
            {
                ValidateTenantView(tenantView);
                Tenant tenant = MapToTenant(tenantView);
                await this.tenantService.CreateTenantAsync(tenant);

                return tenantView;
            });

        public ValueTask<List<TenantView>> RetrieveAllTenantViewsAsync() =>
       TryCatch(async () =>
       {
           List<Tenant> students =
               await this.tenantService.RetrieveAllTenantAsync();

           return students.Select(AsTenantView).ToList();
       });

        private Tenant MapToTenant(TenantView tenantView)
        {
            Guid currentLoggedInUserId = this.userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTimeOffset();

            return new Tenant
            {
                Id = Guid.NewGuid(),
                Name = tenantView.Name,
                Description = tenantView.Description,
                CreatedBy = currentLoggedInUserId,
                UpdatedBy = currentLoggedInUserId,
                CreatedDate = currentDateTime,
                UpdatedDate = currentDateTime
            };
        }
        private static Func<Tenant, TenantView> AsTenantView =>
           student => new TenantView
           {
               Name = student.Name,
               Description = student.Description
           };
    }
}
