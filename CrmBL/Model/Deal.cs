namespace CrmBL.Model
{
    class Deal
    {
        public int Id { get; set; }

        public int SupplyId { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
