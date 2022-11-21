using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews;
using Musharaf.Portal.Core.Blazor.Views.Components;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Views.TenantCreateComponents
{
    public partial class TenantCreateComponentTests : TestContext
    {
        private readonly Mock<ITenantViewService> tenantViewServiceMock;
        private IRenderedComponent<TenantCreateComponent> renderedTenantCreateComponent;

        public TenantCreateComponentTests()
        {
            this.tenantViewServiceMock = new Mock<ITenantViewService>();
            this.Services.AddScoped(services => tenantViewServiceMock.Object);

            //this.Services.AddOptions();
            //this.JSInterop.Mode = JSRuntimeMode.Loose;
        }
    }
}
