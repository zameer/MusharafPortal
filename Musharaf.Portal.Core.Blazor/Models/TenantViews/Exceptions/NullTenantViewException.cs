using Xeptions;

namespace Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions
{
    public class NullTenantViewException : Exception
    {
        public NullTenantViewException() : base(message: "Null tenant error occured.") { }
    }
}
