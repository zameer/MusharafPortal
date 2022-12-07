using Xeptions;

namespace Musharaf.Portal.Core.Api.Models.Tenants.Exceptions
{
    public class TenantValidationException : Xeption
    {
        public TenantValidationException(Xeption innerException)
            : base(message: "Invalid tenant, please contact musharaf", innerException) { }
    }
}
