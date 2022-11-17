namespace MusharafPortal.Core.Api.Models.Tenants.Exceptions
{
    public class FailedTenantServiceException : Exception
    {
        public FailedTenantServiceException(Exception exception) 
            : base("Failed tenant service error occurred, contact support.", exception)
        {

        }
    }
}
