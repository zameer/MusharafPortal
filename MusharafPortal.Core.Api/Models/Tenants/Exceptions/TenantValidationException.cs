namespace MusharafPortal.Core.Api.Models.Tenants.Exceptions
{
    public class TenantValidationException : Exception
    {
        public TenantValidationException(Exception innerException) 
            : base(message: "Invalid tenant, please contact musharaf", innerException) { }
    }
}
