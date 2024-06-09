using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static class Validation
        {
            public static bool IsValidUsername(string username)
            {
                string pattern = @"^[a-zA-Z0-9_]+$";
                return Regex.IsMatch(username, pattern);
            }

            public static bool IsValidIP(string ip)
            {
                IPAddress address;
                return IPAddress.TryParse(ip, out address);
            }
        }
        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string ip = IPTextBox.Text;

            if (!Validation.IsValidUsername(username))
            {
                MessageBox.Show("Пожалуйста, введите действительное имя пользователя (допускаются только буквы, цифры и символы подчеркивания).", "Неверное имя задрота", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ConnectChatRadioButton.IsChecked == true)
            {
                if (!Validation.IsValidIP(ip))
                {
                    MessageBox.Show("Пожалуйста, введите действительный IP-адрес.", "Недопустимый IP-адрес", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                IPAddress adress = IPAddress.Parse(ip);

                UserWindow userWindow = new UserWindow(ip, 8888, username);
                userWindow.Show();
                Close();
            }
            else if (CreateChatRadioButton.IsChecked == true)
            {
                AdminWindow adminWindow = new AdminWindow(username, 8888);
                adminWindow.Show();
                Close();
            }
        }
    }
}