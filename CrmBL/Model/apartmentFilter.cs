namespace CrmBL.Model
{
    class ApartmentFilter
    {
        public int Id { get; set; }
        public virtual RealEstateAddressFilter RealEstateAddressFilter { get; set; }

        public int MinFloor { get; set; }

        public int MaxFloor { get; set; }

        public int MinArea { get; set; }

        public int MaxArea { get; set; }

        public int MinRooms { get; set; }

        public int MaxRooms { get; set; }
    }
}