using FluentAssertions;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;
using Musharaf.Portal.Core.Blazor.Views.Components;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Views.TenantCreateComponents
{
    public partial class TenantCreateComponentTests
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            // given
            ComponentState expectedComponentState =
                ComponentState.Loading;

            // when
            var initializeTenantCreateComponent =
                new TenantCreateComponent();

            // then
            initializeTenantCreateComponent.State.Should().Be(expectedComponentState);
            initializeTenantCreateComponent.Exception.Should().BeNull();
            initializeTenantCreateComponent.Name.Should().BeNull();
            initializeTenantCreateComponent.Description.Should().BeNull();
        }
    }
}
