using System.Collections.Generic;

namespace CrmBL.Model
{
    class RealEstate
    {
        public int RealEstateId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Number { get; set; }

        public float? Longitude { get; set; }

        public float? Latitude { get; set; }

        public int? Rooms { get; set; }

        public float? Area { get; set; }

        public int? Floors { get; set; }

        public int Floor { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }

        public override string ToString()
        {
            return $"Город {City}, улица {Street}, дом {House}, номер квартиры {Number}.";
        }
    }
}
