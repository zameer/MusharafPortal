using Microsoft.EntityFrameworkCore;
using MusharafPortal.Web.Api.Models.Tenants;

namespace MusharafPortal.Web.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Tenant> Tenants{ get; set; }
    }
}
