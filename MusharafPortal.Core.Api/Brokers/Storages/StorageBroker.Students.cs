using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusharafPortal.Core.Api.Models.Tenants;

namespace MusharafPortal.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Tenant> Tenants { get; set; }

        public async ValueTask<Tenant> InsertTenantAsync(Tenant tenant)
        {
            using var broker = new StorageBroker(configuration);
            EntityEntry<Tenant> tenantEntityEntry = await broker.Tenants.AddAsync(tenant);
            await broker.SaveChangesAsync();

            return tenantEntityEntry.Entity;
        }

        public IQueryable<Tenant> SelectAllTenants() => this.Tenants;

        public async ValueTask<Tenant> SelectTenantByIdAsync(Guid tenantId)
        {
            using var broker = new StorageBroker(configuration);
            broker.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return await broker.Tenants.FindAsync(tenantId);
        }

        public async ValueTask<Tenant> UpdateTenantAsync(Tenant tenant)
        {
            using var broker = new StorageBroker(configuration);
            EntityEntry<Tenant> tenantEntityEntry = broker.Tenants.Update(entity: tenant);

            await broker.SaveChangesAsync();

            return tenantEntityEntry.Entity;
        }

        public async ValueTask<Tenant> DeleteTenantAsync(Tenant tenant)
        {
            using var broker = new StorageBroker(configuration);
            EntityEntry<Tenant> tenantEntityEntry = broker.Tenants.Remove(entity: tenant);

            await broker.SaveChangesAsync();

            return tenantEntityEntry.Entity;
        }
    }
}
