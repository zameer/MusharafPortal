﻿using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public partial class TenantViewService
    {
        private delegate ValueTask<TenantView> ReturningTenantViewFunction();

        private async ValueTask<TenantView> TryCatch(ReturningTenantViewFunction returningTenantViewFunction)
        {
            try
            {
                return await returningTenantViewFunction();
            }
            catch (InvalidTenantViewException invalidTenantViewException)
            {
                throw CreateAndLogValidationException(invalidTenantViewException);
            }
        }

        private TenantViewValidationException CreateAndLogValidationException(Exception exception)
        {
            var tenantViewValidationException = new TenantViewValidationException(exception);
            this.loggingBroker.LogError(tenantViewValidationException);

            return tenantViewValidationException;
        }
    }
}