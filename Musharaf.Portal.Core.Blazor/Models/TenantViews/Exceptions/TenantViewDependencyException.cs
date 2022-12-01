﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace OtripleS.Portal.Web.Models.StudentViews.Exceptions
{
    public class TenantViewDependencyException : Exception
    {
        public TenantViewDependencyException(Exception innerException)
            : base("Tenant view dependency error occurred, contact support.", innerException) { }
    }
}
