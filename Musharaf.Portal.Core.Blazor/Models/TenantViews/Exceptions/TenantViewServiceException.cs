// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions
{
    public class TenantViewServiceException : Exception
    {
        public TenantViewServiceException(Exception innerException)
            : base("Tenant View service error occured, contact support.", innerException) { }
    }
}
