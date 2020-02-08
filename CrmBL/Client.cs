namespace CrmBl
{
    class Client
    {
        public int ClientId { get; set; }

        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                if (Name == "")
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
                if (Surname == "")
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
                if (Patronymic == "")
                {
                    Patronymic = "не введено";
                }
                else
                {
                    Patronymic = value;
                }

            }
        }

        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Имя {Name}, фамилия {Surname}, отчество {Patronymic}, номер телефона {Phone}.";
        }
    }
}
