namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class TenantValidationException : Exception
    {
        public TenantValidationException(Exception innerException)
            : base("Tenant validation error occured. try again. ", innerException) { }
    }
}
