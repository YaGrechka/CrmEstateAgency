namespace CrmBl
{
    class LandInfo
    {
        public int LandInfoId { get; set; }

        public virtual RealEstateAddress Address { get; set; }

        public float? Area { get; set; }

        public float? Longitude { get; set; }

        public float? Latitude { get; set; }
    }
}
