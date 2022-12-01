// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class FailedTenantDependencyException : Xeption
    {
        public FailedTenantDependencyException(Exception innerException)
            : base(message: "Failed tenant dependency error occurred, please contact support.", innerException)
        { }
    }
}
