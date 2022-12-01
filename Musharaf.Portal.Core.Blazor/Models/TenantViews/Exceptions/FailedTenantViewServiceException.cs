// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Xeptions;

namespace Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions
{
    public class FailedTenantViewServiceException : Xeption
    {
        public FailedTenantViewServiceException(Exception innerException)
            : base(message: "Failed tenant view service error occurred, please contact support", innerException)
        { }
    }
}
