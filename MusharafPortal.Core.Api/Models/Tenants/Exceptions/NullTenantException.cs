namespace Musharaf.Portal.Core.Api.Models.Tenants.Exceptions
{
    public class NullTenantException : Exception
    {
        public NullTenantException() : base(message: "The tenant is null.") { }
    }
}
