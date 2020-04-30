using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Supply
    {
        public int Id { get; set; }

        public int Price
        {
            get
            {
                return Price;
            }

            set
            {
                if(value > 0)
                {
                    Price = value;
                }
            }
        }

        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int RealEstate { get; set; }
        public virtual RealEstate RealEstateAddress { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }

        public override string ToString()
        {
            return $"Клиент {Client.Name} {Client.Surname} {Client.Patronymic} \r\n Агент {Agent.Name} {Agent.Surname} {Agent.Patronymic} \r\n Цена {Price}";
        }
    }
}
