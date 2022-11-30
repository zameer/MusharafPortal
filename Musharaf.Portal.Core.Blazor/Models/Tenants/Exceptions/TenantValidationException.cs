using Xeptions;

namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class TenantValidationException : Xeption
    {
        public TenantValidationException(Exception innerException)
            : base("Tenant validation error occured. try again. ", innerException) { }
    }
}
