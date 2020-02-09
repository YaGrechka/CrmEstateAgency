namespace CrmBL.Model
{
    class RealEstateAddressFilter
    {
        public int Id { get; set; }
        public virtual HouseFilter HouseFilter { get; set; }
        public virtual ApartmentFilter ApartmentFilter { get; set; }
        public virtual LandFilter LandFilter { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }
        
        public string Number { get; set; }

        public string Type { get; set; }

        public virtual Demand Demand { get; set; }
    }
}