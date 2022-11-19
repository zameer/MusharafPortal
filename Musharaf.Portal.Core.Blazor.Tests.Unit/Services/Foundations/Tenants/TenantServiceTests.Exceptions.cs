﻿using Moq;
using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using RESTFulSense.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateIfBadRequestErrorOccursAndLogItAsync()
        {
            // given
            Tenant someTenant = CreateRandomTenant();
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseBadRequestException = new HttpResponseBadRequestException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            var expectedTenantDependencyValidationException =
                new TenantDependencyValidationException(
                    httpResponseBadRequestException);

            this.apiBrokerMock.Setup(broker =>
               broker.PostTenantAsync(someTenant))
                .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Tenant> createTenantTask = 
                this.tenantService.CreateTenantAsync(someTenant);

            // then
            await Assert.ThrowsAsync<TenantDependencyValidationException>(() =>
                createTenantTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()),
                Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedTenantDependencyValidationException))),
                Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async Task ShouldThrowCriticalDependencyValidationExceptionOnCreateIfUrlNotFoundErrorOccursAndLogItAsync()
        {
            // given
            Tenant someTenant = CreateRandomTenant();
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseUrlNotFoundException = new HttpResponseUrlNotFoundException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            var expectedTenantDependencyException =
                new TenantDependencyException(
                    httpResponseUrlNotFoundException);

            this.apiBrokerMock.Setup(broker =>
               broker.PostTenantAsync(someTenant))
                .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Tenant> createTenantTask =
                this.tenantService.CreateTenantAsync(someTenant);

            // then
            await Assert.ThrowsAsync<TenantDependencyException>(() =>
                createTenantTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.PostTenantAsync(It.IsAny<Tenant>()),
                Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedTenantDependencyException))),
                Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}