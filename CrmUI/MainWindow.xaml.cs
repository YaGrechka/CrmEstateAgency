using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Input;

namespace CrmUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlDataAdapter adapter;
        DataSet dataSet;
        string connectionString = "Data Source=VALUN;Initial Catalog=Test;Integrated Security=True";
        string query = "SELECT * FROM Person";

        public MainWindow()
        {
            InitializeComponent();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(query, connectionString);
                dataSet = new DataSet();

                adapter.Fill(dataSet);
            }
            dataGridView.DataSource = dataSet.Tables[0];
            //dataGridView.Columns[0].Visible = false;

            //GridClient.Children.Clear();
            //GridClient.Children.Add(new UserControlClientDemo());
        }

        private void wbWinForms_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Title = (sender as System.Windows.Forms.WebBrowser).DocumentTitle;
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            //switch (index)
            //{
            //    case 0:
            //        GridClient.Children.Clear();
            //        GridClient.Children.Add(new UserControlClientDemo());
            //        break;
            //    default:
            //        GridClient.Children.Clear();
            //        break;
            //}
        }

        private void ListViewDataBaseButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int index = ListViewMenu.SelectedIndex;

            //switch (index)
            //{
            //    case 0:
            //        using (SqlConnection connection = new SqlConnection(connectionString))
            //        {
            //            adapter = new SqlDataAdapter(query, connectionString);
            //            dataSet = new DataSet();

            //            adapter.Fill(dataSet);
            //        }
            //        dataGridView.DataSource = dataSet.Tables[0];
            //        break;
            //    case 1:
            //        using (SqlConnection connection = new SqlConnection(connectionString))
            //        {
            //            adapter.SelectCommand = new SqlCommand(query, connection);
            //            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            //            adapter.UpdateCommand = builder.GetUpdateCommand();
            //            adapter.Update(dataSet);
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }

        private void MoveCursorMenu(int index)
        {
            TransitionSlideContent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (125 + (60 * index)), 0, 0);
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e) //Refresh
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(query, connectionString);
                dataSet = new DataSet();

                adapter.Fill(dataSet);
            }
            dataGridView.DataSource = dataSet.Tables[0];
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e) //Update
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter.SelectCommand = new SqlCommand(query, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(dataSet);
                //dataGridView.DataSource = dataSet.Tables[0];
            }
        }
    }
}