using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading.Tasks;
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
        string query = "SELECT * FROM Clients";

        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            //Запущено ли приложение с правами администратора
            if (isElevated)
            {
                ServiceController service = new ServiceController("MSSQLSERVER");
                // Если служба не остановлена
                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        // Останавливаем службу
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMinutes(1));
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось остановить службу для работы с базой данных. Для отключения службы перезапустите приложение от имени администратора.");
                    }

                }
                else
                {
                    MessageBox.Show("Служба уже остановлена!");
                }
            }

            System.Windows.Application.Current.Shutdown();
        } //Close app

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    query = "SELECT* FROM Clients";
                    Refresh();
                    break;
                case 1:
                    query = "SELECT* FROM Agents";
                    Refresh();
                    break;
                case 2:
                    query = "SELECT* FROM RealEstates";
                    Refresh();
                    break;
                case 3:
                    query = "SELECT* FROM Demands";
                    Refresh();
                    break;
                case 4:
                    query = "SELECT* FROM Supplies";
                    Refresh();
                    break;
                default:
                    query = "SELECT* FROM Clients";
                    Refresh();
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TransitionSlideContent.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (140 + (60 * index)), 0, 0);
        }

        private void Button_ClickRefresh(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            try
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
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Upload()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    adapter.Update(dataSet);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Button_ClickUpload(object sender, RoutedEventArgs e)
        {
            Upload();
        }

        async private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {

            });
            Refresh();

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

        private void ButtonFullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonFullScreenIcon.Kind == MaterialDesignThemes.Wpf.PackIconKind.Fullscreen)
            {
                ButtonFullScreenIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.FullscreenExit;
                ResizeMode = ResizeMode.NoResize;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                ButtonFullScreenIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Fullscreen;
                ResizeMode = ResizeMode.CanResize;
                this.WindowState = WindowState.Normal;
            }

        }

        private void ButtonWindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}