namespace MusharafPortal.Core.Api.Models.Tenants.Exceptions
{
    public class TenantDependencyException : Exception
    {
        public TenantDependencyException(Exception exception)
            : base("Service dependency error occurred, contact support.", exception)
        {

        }
    }
}
