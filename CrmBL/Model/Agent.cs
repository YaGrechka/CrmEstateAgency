using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CrmBL.Model
{
    public class Agent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Pasport { get; set; }

        public decimal Salary { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }

        public override string ToString()
        {
            return $"Имя {Name}, фамилия {Surname}, отчество {Patronymic}, заработная плата {Salary}.";
        }

        public string Connect(string Login, string Password)
        {
            string Message = "Данные были введены не верно";
            const string connectionString = "Data Source=VALUN;Initial Catalog=CrmRealEstate;Integrated Security=True";
            string query = $"SELECT Password FROM Agents WHERE Login = {Login}";
            string password = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    password = Convert.ToString(sqlCommand.ExecuteScalar());
                }
                catch (Exception x)
                {
                    string q = "\"";
                    if (x.Message == $"Недопустимое имя столбца {q}{Login}{q}.")
                    {
                        Message = "Данные были введены не верно";
                    }
                    else
                    {
                        Message = x.Message;
                    }
                }
            }
            if (password == Password)
            {
                return "";
            }
            return Message;
        }
    }
}
