using Xeptions;

namespace Musharaf.Portal.Core.Api.Models.Tenants.Exceptions
{
    public class NullTenantException : Xeption
    {
        public NullTenantException() : base(message: "The tenant is null.") { }
    }
}
