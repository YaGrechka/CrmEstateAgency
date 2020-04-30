using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.ServiceProcess;
using System.Security.Principal;
using CrmBL.Model;
using System.Threading.Tasks;
using System.Threading;

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
            Agent agent = new Agent();
            string Message = agent.Connect(TextBoxLogin.Text, TextBoxPassword.Password);
            if (Message == "")
            {
                MainWindow mainWindow = new MainWindow(agent);
                mainWindow.Show();
                this.Close();
            }else
            {
                MessageBox.Show(Message);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadAnimation.Visibility = Visibility.Visible;
            await Task.Run(()=>Connection());
            loadAnimation.Visibility = Visibility.Hidden;
        }


        void Connection()
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