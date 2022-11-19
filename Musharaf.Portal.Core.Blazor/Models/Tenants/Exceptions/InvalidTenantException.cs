using Xeptions;

namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class InvalidTenantException : Xeption
    {
        public InvalidTenantException(string parameterName, object parameterValue)
            : base("Invalid tenant error occured." +
                  $"Parameter name: " + parameterName +
                  $"Parameter value: " + parameterValue)
        { }

        public InvalidTenantException() : base(message: "Invalid tenant. please fix the error and try again") { }
    }
}
