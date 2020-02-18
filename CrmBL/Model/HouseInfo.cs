namespace CrmBL.Model
{
    class HouseInfo : RealEstateAddress
    {
        public int HouseInfoId { get; set; }
        public virtual RealEstateAddress Address { get; set; }

        public int? Rooms { get; set; }

        public float? Area { get; set; }

        public int? Floors { get; set; }
        //Позже будут добавлены новые поля 
    }
}
