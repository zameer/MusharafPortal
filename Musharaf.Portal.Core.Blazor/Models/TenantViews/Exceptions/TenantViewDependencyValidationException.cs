namespace Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions
{
    public class TenantViewDependencyValidationException : Exception
    {
        public TenantViewDependencyValidationException(Exception innerException)
            : base("TenantView dependency validation error occured, try again.", innerException)
        {

        }
    }
}
