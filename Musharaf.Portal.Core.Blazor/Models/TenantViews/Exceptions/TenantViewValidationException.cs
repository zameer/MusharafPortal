using Xeptions;

namespace Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions
{
    public class TenantViewValidationException : Exception
    {
        public TenantViewValidationException(Exception innerException)
            : base("Tenant view validation error occured, try again.", innerException)
        { }
    }
}
