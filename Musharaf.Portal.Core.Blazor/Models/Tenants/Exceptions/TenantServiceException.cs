namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class TenantServiceException : Exception
    {
        public TenantServiceException(Exception innerException)
            : base("Tenant service error occured. contact support. ", innerException) { }
    }
}
