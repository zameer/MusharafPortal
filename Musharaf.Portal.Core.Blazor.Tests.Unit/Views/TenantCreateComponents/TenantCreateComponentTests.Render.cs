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
            initializeTenantCreateComponent.SubmitButton.Should().BeNull();
            initializeTenantCreateComponent.Description.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            // given
            ComponentState expectedComponentState =
                ComponentState.Content;

            string expectedTenantNameTextBoxPlaceholder = "Name";
            string expectedTenantDescriptionTextBoxPlaceholder = "Description";
            string expectedTenantSubmitButtonLabel = "Submit Tenant";

            // when
            this.renderedTenantCreateComponent =
                RenderComponent<TenantCreateComponent>();

            // then
            this.renderedTenantCreateComponent.Instance.State
                .Should().Be(expectedComponentState);

            this.renderedTenantCreateComponent.Instance.Name
                .Should().NotBeNull();

            this.renderedTenantCreateComponent.Instance.Name.Placeholder
                .Should().BeEquivalentTo(expectedTenantNameTextBoxPlaceholder);
        }
    }
}
