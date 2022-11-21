namespace Musharaf.Portal.Core.Blazor.Models.TenantCreateComponents.Exceptions
{
    public class TenantCreateFormComponentException : Exception
    {
        public TenantCreateFormComponentException(Exception innerException)
            : base("Error occured, contact support.", innerException)
        { }
    }
}
