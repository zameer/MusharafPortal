// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions
{
    public class NotFoundTenantException : Exception
    {
        public NotFoundTenantException(Guid tenantId)
            : base(message: $"Couldn't find tenant with id: {tenantId}.") { }
    }
}
