using MusharafPortal.Core.Api.Brokers.Storages;
using MusharafPortal.Core.Api.Models.Tenants;

namespace MusharafPortal.Core.Api.Services.Foundatons.Tenants
{
    public class TenantService : ITenantService
    {
        private readonly IStorageBroker storageBroker;

        public TenantService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public ValueTask<Tenant> CreateTenantAsync(Tenant tenant)
        {
            throw new NotImplementedException();
        }
    }
}
