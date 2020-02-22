using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace CrmBL.test
{
    public class DataGridWork
    {
        SqlDataAdapter adapter;

        readonly string SelectQuery;
        readonly string connectionString = "Data Source=VALUN;Initial Catalog=CrmRealEstate;Integrated Security=True";

        public DataGridWork(string selectQuery)
        {
            SelectQuery = selectQuery;
        }

        public DataSet Refresh()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(SelectQuery, connection);
                adapter.Fill(dataSet);
            }
            return dataSet;
        }

        public void UpLoad(DataSet dataSet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(SelectQuery,connection);
                adapter.SelectCommand = new SqlCommand(SelectQuery, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(dataSet);
            }
        }
    }
}
