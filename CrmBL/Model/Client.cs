using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Client
    {
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                if (value == "")
                {
                    Name = "не введено";
                }
                else
                {
                    Name = value;
                }

            }
        }

        public string Surname
        {
            get
            {
                return Surname;
            }
            set
            {
                if (value == "")
                {
                    Surname = "не введено";
                }
                else
                {
                    Surname = value;
                }

            }
        }

        public string Patronymic
        {
            get
            {
                return Patronymic;
            }
            set
            {
                if (value == "")
                {
                    Patronymic = "не введено";
                }
                else
                {
                    Patronymic = value;
                }

            }
        }

        public string Pasport { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; } 

        public virtual ICollection<Demand> Demands { get; set; }

        public override string ToString()
        {
            return $"Имя {Name}, фамилия {Surname}, отчество {Patronymic}, номер телефона {Phone}.";
        }
    }
}
