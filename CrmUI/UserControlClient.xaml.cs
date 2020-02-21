using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CrmUI
{
    /// <summary>
    /// Логика взаимодействия для UserControlClient.xaml
    /// </summary>
    public partial class UserControlClient : UserControl
    {
        string connectionString = "Data Source=VALUN;Initial Catalog=Test;Integrated Security=True";
        string query = "SELECT * FROM Person";
        SqlDataAdapter ad;
        DataSet dataSet;

       
        //SqlDataAdapter adapter;
        //DataTable phonesTable;

        public UserControlClient()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ad = new SqlDataAdapter(query, connectionString);
                dataSet = new DataSet();

                ad.Fill(dataSet);

                dataGrid.DataContext = dataSet.Tables[0];
            }
        }

        private void ListVievButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listVievButtons.SelectedIndex;

            switch (index)
            {
                case 0:
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        ad.SelectCommand = new SqlCommand(query, connection);
                        SqlCommandBuilder builder = new SqlCommandBuilder(ad);

                        ad.UpdateCommand = builder.GetUpdateCommand();
                        ad.Update(dataSet);
                    }
                    break;
                case 1:
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        ad = new SqlDataAdapter(query, connectionString);
                        dataSet = new DataSet();
                        ad.Fill(dataSet);
                    }
                    dataGrid.DataContext = dataSet.Tables[0];
                    break;

                default:
                    break;
            }
        }
    }
}
