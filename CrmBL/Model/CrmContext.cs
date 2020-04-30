using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrmBL.Model
{
    public class CrmContext : DbContext
    {
        public CrmContext() : base("CrmConnection") {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<RealEstate> RealEstate { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Demand> Demands { get; set; }
    }
}
