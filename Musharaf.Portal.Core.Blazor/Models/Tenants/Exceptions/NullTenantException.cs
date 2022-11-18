namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class NullTenantException : Exception
    {
        public NullTenantException()
            : base(message: "Null tenant error occured.") { }
    }
}
