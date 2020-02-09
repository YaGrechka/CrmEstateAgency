namespace CrmBL.Model
{
    class LandFilter
    {
        public int Id { get; set; }
        public virtual RealEstateAddressFilter RealEstateAddressFilter { get; set; }

        public int MinArea { get; set; }

        public int MaxArea { get; set; }
    }
}