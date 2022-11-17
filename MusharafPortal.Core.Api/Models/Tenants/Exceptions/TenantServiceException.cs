namespace MusharafPortal.Core.Api.Models.Tenants.Exceptions
{
    public class TenantServiceException : Exception
    {
        public TenantServiceException(Exception innerException) 
            : base(message: "Service error occurred, contact support.", innerException)
        {

        }
    }
}
