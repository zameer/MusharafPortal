using Xeptions;

namespace Musharaf.Portal.Core.Api.Models.Tenants.Exceptions
{
    public class AlreadyExistsTenantException : Xeption
    {
        public AlreadyExistsTenantException(Exception innerException)
                    : base(message: "Tenant with the same id already exists.", innerException) { }
    }
}
