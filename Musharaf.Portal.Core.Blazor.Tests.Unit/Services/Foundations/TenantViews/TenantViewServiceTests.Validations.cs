﻿using Moq;
using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.TenantViews
{
    public partial class TenantViewServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task ShouldThrowValidationExceptionOnAddIfNameIsInvalidAndLogItAsync(
            string invalidText)
        {
            // given
            TenantView randomTenantView = CreateRandomTenantView();
            TenantView invalidTenantView = randomTenantView;
            invalidTenantView.Name = invalidText;

            var invlaidTenantViewException = new InvalidTenantViewException(
                parameterName: nameof(invalidTenantView.Name),
                parameterValue: invalidTenantView.Name);

            var expectedTenantViewValidationException = 
                new TenantViewValidationException(invlaidTenantViewException);

            // when
            ValueTask<TenantView> createTenantViewTask = 
                this.tenantViewService.AddTenantViewAsync(invalidTenantView);

            // then
            await Assert.ThrowsAsync<TenantViewValidationException>(() =>
                createTenantViewTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedTenantViewValidationException))),
                    Times.Once);

            this.userServiceMock.Verify(service =>
                service.GetCurrentlyLoggedInUser(), 
                    Times.Never);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTimeOffset(),
                    Times.Never);

            this.tenantServiceMock.Verify(broker =>
                broker.CreateTenantAsync(It.IsAny<Tenant>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userServiceMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.tenantServiceMock.VerifyNoOtherCalls();
        }
    }
}
