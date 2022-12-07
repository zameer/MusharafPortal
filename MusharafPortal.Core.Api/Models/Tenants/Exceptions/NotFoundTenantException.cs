using Xeptions;

namespace Musharaf.Portal.Core.Api.Models.Tenants.Exceptions
{
    public class NotFoundTenantException : Xeption
    {
        public NotFoundTenantException(Guid tenantId)
            : base(message: $"Couldn't find tenant with id {tenantId}.") { }
    }
}
