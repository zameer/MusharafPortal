namespace MusharafPortal.Core.Api.Models.Tenants.Exceptions
{
    public class NotFoundTenantException : Exception
    {
        public NotFoundTenantException(Guid tenantId) 
            : base(message: $"Couldn't find tenant with id {tenantId}.") { }  
    }
}
