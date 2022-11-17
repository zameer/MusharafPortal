using Microsoft.EntityFrameworkCore;
using MusharafPortal.Core.Api.Models.Tenants;

namespace MusharafPortal.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Tenant> Tenants{ get; set; }
    }
}
