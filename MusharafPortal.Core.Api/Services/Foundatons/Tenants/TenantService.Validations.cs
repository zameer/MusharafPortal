using MusharafPortal.Core.Api.Models.Tenants;
using MusharafPortal.Core.Api.Models.Tenants.Exceptions;

namespace MusharafPortal.Core.Api.Services.Foundatons.Tenants
{
    public partial class TenantService
    {
        private static void ValidateTenant(Tenant tenant)
        {
            if(tenant is null)
            {
                throw new NullTenantException();
            }
        }
    }
}