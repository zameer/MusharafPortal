using Microsoft.AspNetCore.Components;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;
using Musharaf.Portal.Core.Blazor.Models.TenantCreateComponents.Exceptions;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;
namespace Musharaf.Portal.Core.Blazor.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        bool _drawerOpen = true;

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
    }
}

