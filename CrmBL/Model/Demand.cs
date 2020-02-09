namespace CrmBL.Model
{
    class Demand
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }

        public virtual RealEstateAddressFilter RealEstateAddressFilter { get; set; }
    }
}
