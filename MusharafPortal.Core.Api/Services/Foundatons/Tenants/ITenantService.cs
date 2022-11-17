﻿using MusharafPortal.Core.Api.Models.Tenants;

namespace MusharafPortal.Core.Api.Services.Foundatons.Tenants
{
    public interface ITenantService
    {
        ValueTask<Tenant> CreateTenantAsync(Tenant tenant);
        ValueTask<Tenant> RetreiveTenantByIdAsync(Guid Id);
        IQueryable<Tenant> RetrieveAllTenants();
        ValueTask<Tenant> ModifyTenantAsync(Tenant tenant);
        ValueTask<Tenant> RemoveTenantAsync(Guid Id);
    }
}
