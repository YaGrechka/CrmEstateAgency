using System.Collections.Generic;

namespace CrmBL.Model
{
    class Demand
    {
        public int DemandId { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }

        public int MinFloors { get; set; }

        public int MaxFloors { get; set; }

        public int MinFloor { get; set; }

        public int MaxFloor { get; set; }

        public int MinArea { get; set; }

        public int MaxArea { get; set; }

        public int MinRooms { get; set; }

        public int MaxRooms { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }
    }
}
