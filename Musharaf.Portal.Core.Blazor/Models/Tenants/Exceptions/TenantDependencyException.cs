namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class TenantDependencyException : Exception
    {
        public TenantDependencyException(Exception innerException)
            : base("Tenant dependency error occured. contact supprt. ", innerException) { }
    }
}
