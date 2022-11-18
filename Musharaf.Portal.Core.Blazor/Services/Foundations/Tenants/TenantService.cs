using Musharaf.Portal.Core.Blazor.Brokers.Apis;
using Musharaf.Portal.Core.Blazor.Brokers.Loggings;
using Musharaf.Portal.Core.Blazor.Models.Tenants;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants
{
    public class TenantService : ITenantService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public TenantService(
            IApiBroker apiBroker, 
            ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Tenant> CreateTenantAsync(Tenant tenant)
        {
            throw new NotImplementedException();
        }
    }
}
