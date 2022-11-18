using FluentAssertions;
using Musharaf.Portal.Core.Blazor.Models.Basics;
using Musharaf.Portal.Core.Blazor.Views.Components;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Components
{
    public partial class TenantFormComponentTests
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            // given , when
            var initialTenantFormComponent = new TenantFormComponent();

            // then
            initialTenantFormComponent.TenantNameTextBox.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            // given
            ComponentState expectedState = ComponentState.Content;

            // when
            this.renderedTenantFormComponent =
                RenderComponent<TenantFormComponent>();

            // then
            this.renderedTenantFormComponent.Instance.State
                .Should().Be(expectedState);

            this.renderedTenantFormComponent.Instance.TenantNameTextBox
                .Should().NotBeNull();

            this.renderedTenantFormComponent.Instance.TenantNameTextBox
                .Placeholder.Should().BeEquivalentTo("Tenant Name");
        }
    }
}
