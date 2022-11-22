using FluentAssertions;
using Moq;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;
using Musharaf.Portal.Core.Blazor.Views.Components;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Views.TenantCreateComponents
{
    public partial class TenantCreateComponentTests
    {
        [Fact]
        public void ShouldRenderInnerExceptionMessageIfValidationErrorOccured()
        {
            // given
            string randomMessage = GetRandomString();
            string validationMessage = randomMessage;
            string expectedErrorMessage = validationMessage;
            var innerValidationException = new Exception(validationMessage);

            var tenantViewValidationException =
                new TenantViewValidationException(innerValidationException);

            this.tenantViewServiceMock.Setup(service =>
                service.AddTenantViewAsync(It.IsAny<TenantView>()))
                .ThrowsAsync(tenantViewValidationException);

            // when
            this.renderedTenantCreateComponent =
                RenderComponent<TenantCreateComponent>();

            this.renderedTenantCreateComponent.Instance.SubmitButton.Click();

            // then
            this.renderedTenantCreateComponent.Instance.ErrorLabel.Value
                .Should().BeEquivalentTo(expectedErrorMessage);

            this.tenantViewServiceMock.Verify(service =>
                service.AddTenantViewAsync(It.IsAny<TenantView>()), 
                Times.Once);

            this.tenantViewServiceMock.VerifyNoOtherCalls();
        }
    }
}
