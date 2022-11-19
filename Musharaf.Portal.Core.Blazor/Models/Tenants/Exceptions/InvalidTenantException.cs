namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class InvalidTenantException : Exception
    {
        public InvalidTenantException(string parameterName, object parameterValue)
            : base("Invalid tenant error occured." +
                  $"Parameter name: " + parameterName +
                  $"Parameter value: " + parameterValue)
        {

        }
    }
}
