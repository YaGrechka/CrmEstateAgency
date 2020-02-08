namespace CrmBl
{
    class HouseInfo
    {
        public int HouseInfoId { get; set; }

        public virtual RealEstateAddress Address { get; set; }

        public int? Rooms { get; set; }

        public float? Area { get; set; }

        public int? Floors { get; set; }
    }
}
