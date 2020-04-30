namespace CrmBL.Model
{
    public class Deal
    {
        public int Id { get; set; }

        public int SupplyId { get; set; }
        public virtual Supply Supply { get; set; }

        public int DemandId { get; set; }
        public virtual Demand Demand { get; set; }
    }
}
