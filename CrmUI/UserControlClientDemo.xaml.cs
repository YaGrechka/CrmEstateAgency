using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrmUI
{
    /// <summary>
    /// Логика взаимодействия для UserControlClientDemo.xaml
    /// </summary>
    public partial class UserControlClientDemo : UserControl
    {
        public UserControlClientDemo()
        {
            string connectionString = "Data Source=VALUN;Initial Catalog=Test;Integrated Security=True";
            string query = "SELECT * FROM Person";
            SqlDataAdapter ad;
            DataSet dataSet;

            InitializeComponent();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ad = new SqlDataAdapter(query, connectionString);
                dataSet = new DataSet();

                ad.Fill(dataSet);
            }
            (wfhSample.Child as System.Windows.Forms.DataGridView).DataSource = dataSet.Tables[0];

            dataGridView.DataSource = dataSet.Tables[0];
            dataGridView.Columns[0].Visible = false;
        }
    }
}
