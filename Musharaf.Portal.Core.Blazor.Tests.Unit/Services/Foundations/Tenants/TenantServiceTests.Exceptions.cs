﻿using Moq;
using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using RESTFulSense.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.Tenants
{
    public partial class TenantServiceTests
    {
        public static TheoryData ValidationApiException()
        {
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseBadRequestException = new HttpResponseBadRequestException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            var httpResponseConflictException = new HttpResponseConflictException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            return new TheoryData<Exception>
            {
                httpResponseBadRequestException,
                httpResponseConflictException
            };
        }

        [Theory]
        [MemberData(nameof(ValidationApiException))]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateIfBadRequestErrorOccursAndLogItAsync(
            Exception validationApiException)
        {
            // given
            Tenant someTenant = CreateRandomTenant();
            string exceptionMessage = GetRandomString();

            var expectedTenantDependencyValidationException =
                new TenantDependencyValidationException(
                    validationApiException);

            this.apiBrokerMock.Setup(broker =>
               broker.PostTenantAsync(someTenant))
                .ThrowsAsync(validationApiException);

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

        public static TheoryData CriticalApiException()
        {
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseUrlNotFoundException = new HttpResponseUrlNotFoundException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            var httpResponseUnauthorizedException = new HttpResponseUnauthorizedException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            return new TheoryData<Exception>
            {
                httpResponseUrlNotFoundException,
                httpResponseUnauthorizedException
            };
        }

        [Theory]
        [MemberData(nameof(CriticalApiException))]
        public async Task ShouldThrowCriticalDependencyValidationExceptionOnCreateIfUrlNotFoundErrorOccursAndLogItAsync(
            Exception httpResponseCriticalException)
        {
            // given
            Tenant someTenant = CreateRandomTenant();

            var expectedTenantDependencyException =
                new TenantDependencyException(
                    httpResponseCriticalException);

            this.apiBrokerMock.Setup(broker =>
               broker.PostTenantAsync(someTenant))
                .ThrowsAsync(httpResponseCriticalException);

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
