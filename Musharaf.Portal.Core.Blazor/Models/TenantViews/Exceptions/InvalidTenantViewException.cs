using Xeptions;

namespace Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions
{
    public class InvalidTenantViewException : Xeption
    {
        public InvalidTenantViewException(string parameterName, string parameterValue)
            : base("Invalid tenant view error occured. " +
                  $"parameter name: {parameterName} " +
                  $"parameter value: {parameterValue}")
        { }

        public InvalidTenantViewException() : base(message: "Invalid tenant view. please fix the error and try again") { }
    }
}
