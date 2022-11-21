using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Tests.Unit.Services.Foundations.TenantViews
{
    public partial class TenantViewServiceTests
    {
        public static TheoryData TenantServiceValidationExceptions()
        {
            var innerException = new Exception();

            return new TheoryData<Exception>
            {
                new TenantValidationException(innerException),
                new TenantDependencyValidationException(innerException)
            };
        }

        [Theory]
        [MemberData(nameof(TenantServiceValidationExceptions))]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateIfTenantValidationErrorOccuredAndLogItAsync(
            Exception tenantServiceValidationException)
        {
            // given
            TenantView someTenantView = CreateRandomTenantView();

            var expectedDependencyValidationException = 
                new TenantViewDependencyValidationException()

            // when

            // then
        }
    }
}
