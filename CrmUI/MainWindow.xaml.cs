using System.Data;
using System.Data.SqlClient;
using System.Windows;
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
        const string connectionString = "Data Source=VALUN;Initial Catalog=CrmRealEstate;Integrated Security=True";
        const string query = "SELECT * FROM Clients";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        } //Close app

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TransitionSlideContent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (125 + (60 * index)), 0, 0);
        }

        private void Button_ClickRefresh(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(query, connection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            
            dataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            dataGrid.Columns[0].Visibility = Visibility.Hidden;
        }

        private void Button_ClickUpload(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter.SelectCommand = new SqlCommand(query, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(dataSet);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(query, connection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
            }

            dataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            dataGrid.Columns[0].Visibility = Visibility.Hidden;



            //(wfhSample.Child as System.Windows.Forms.WebBrowser).Navigate("http://m.vk.com/YaGrechka");

            //GridClient.Children.Add(new UserControlClientTable());
            //GridClient.Children.Add(new UserControlClientButton());
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
            
        }
    }
}