namespace CrmBL.Model
{
    class ApartmentInfo : RealEstateAddress
    {
        public int ApartmentInfoId { get; set; }
        public virtual RealEstateAddress Address { get; set; }

        public int Floor { get; set; }

        public int Rooms { get; set; }

        public int Area { get; set; }

        //Позже будут добавлены новые поля 
    }
}
