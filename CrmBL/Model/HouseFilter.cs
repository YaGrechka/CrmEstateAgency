namespace CrmBL.Model
{
    class HouseFilter
    {
        public int Id { get; set; }
        public virtual RealEstateAddressFilter RealEstateAddressFilter { get; set; }

        public int MinFloors { get; set; }

        public int MaxFloors { get; set; }

        public int MinArea { get; set; }

        public int MaxArea { get; set; }

        public int MinRooms { get; set; }

        public int MaxRooms { get; set; }
    }
}