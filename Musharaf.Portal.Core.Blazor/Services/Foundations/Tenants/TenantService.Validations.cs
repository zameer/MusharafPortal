using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants
{
    public partial class TenantService
    {
        private void ValidateTenant(Tenant tenant)
        {
            if (tenant is null)
            {
                throw new NullTenantException();
            }
        }
    }
}
