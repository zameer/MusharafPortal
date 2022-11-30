using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public partial class TenantViewService
    {
        private void ValidateTenantView(TenantView tenantView)
        {
            if (tenantView is null)
            {
                throw new NullTenantViewException();
            }
        }
    }
}
