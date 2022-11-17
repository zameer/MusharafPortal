﻿using Moq;
using MusharafPortal.Core.Api.Models.Tenants;
using MusharafPortal.Core.Api.Models.Tenants.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusharafPortal.Core.Api.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRetrieveWhenIdIsInvalidAndLogItAsync()
        {
            // given
            Guid randomTenantId = default;
            Guid inputTenantId = randomTenantId;

            var invalidTenantException = new InvalidTenantException(
                parameterName: nameof(Tenant.Id),
                parameterValue: inputTenantId
                );

            var expectedTenantValidationException = new TenantValidationException(invalidTenantException);

            // when
            ValueTask<Tenant> retrieveTenantByIdTask =
                this.tenantService.RetreiveTenantByIdAsync(inputTenantId);

            // then
            await Assert.ThrowsAsync<TenantValidationException>(() => retrieveTenantByIdTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectTenantByIdAsync(It.IsAny<Guid>()),
                Times.Never
            );

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
