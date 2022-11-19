namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class TenantDependencyValidationException : Exception
    {
        public TenantDependencyValidationException(Exception innerException)
            : base("Tenant dependency validation error occured. try again. ", innerException) { }
    }
}
