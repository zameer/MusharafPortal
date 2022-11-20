namespace Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions
{
    public class InvalidTenantViewException : Exception
    {
        public InvalidTenantViewException(string parameterName, string parameterValue)
            : base("Invalid tenant view error occured. " +
                  $"parameter name: {parameterName} " +
                  $"parameter value: {parameterValue}")
        { }
    }
}
