using System.Data.Entity;

namespace CrmBL.Model
{
    class CrmContext : DbContext
    {
        public CrmContext() : base("CrmConnection") {}

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<RealEstateAddress> RealEstateAddresses { get; set; }
        public DbSet<HouseInfo> HouseInfos { get; set; }
        public DbSet<ApartmentInfo> ApartmentInfos { get; set; }
        public DbSet<LandInfo> LandInfos { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<RealEstateAddressFilter> RealEstateAddressFilters { get; set; }
        public DbSet<ApartmentFilter> ApartmentFilters { get; set; }
        public DbSet<HouseFilter> HouseFilters { get; set; }
        public DbSet<LandFilter> LandFilters { get; set; }
    }
}
