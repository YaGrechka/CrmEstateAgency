using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.ServiceProcess;
using System.Security.Principal;

namespace CrmUI
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void ButtonWindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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

            
            Application.Current.Shutdown();
        } //CloseApp

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

        private void TextBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxKostil.Visibility = Visibility.Collapsed;
        }

        private void TextBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPassword.Password == "")
            {
                TextBoxKostil.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "Логин")
            {
                TextBoxLogin.Text = "";
                TextBoxLogin.Foreground = Brushes.Black;
            }
        }

        private void TextBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "")
            {
                TextBoxLogin.Text = "Логин";
                TextBoxLogin.Foreground = Brushes.Gray;
            }
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            const string connectionString = "Data Source=VALUN;Initial Catalog=CrmRealEstate;Integrated Security=True";
            string query = $"SELECT Password FROM Agents WHERE Login = {TextBoxLogin.Text}";
            string Password = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    Password = Convert.ToString(sqlCommand.ExecuteScalar());
                }
                catch (Exception x)
                {
                    string q = "\"";
                    if(x.Message == $"Недопустимое имя столбца {q}{TextBoxLogin.Text}{q}.")
                    {
                        goto Error;
                    }
                    MessageBox.Show(x.Message);
                    goto Skip;
                }
            }
            if (Password == TextBoxPassword.Password)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные были введены не верно!");
            }

            Error:
            MessageBox.Show("Данные были введены не верно!");
            ;
            Skip:;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
                // Проверяем не запущена ли служба
                if (service.Status != ServiceControllerStatus.Running)
                {
                    // Запускаем службу
                    service.Start();
                    // В течении минуты ждём статус от службы
                    service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMinutes(1));
                }
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxKostil.Visibility = Visibility.Collapsed;
            TextBoxPassword.Focus();
        }
    }
}