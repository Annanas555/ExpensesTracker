using ExpenditureTracker.Data;
using ExpenditureTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace ExpenditureTracker.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку "Регистрация"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        /// <summary>
        /// Обработчик нажатия на кнопку входа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение введенных учетных данных
            string username = LoginTextBox.Text;
            string password = PasswordBox.Password;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            User user = App.Context.Users.SingleOrDefault(u => u.UserName == username && u.Password == hash);

            if (user != null)
            {
                App.CurrentUser = user;
                MessageBox.Show("Вход выполнен успешно");
                NavigationService.Navigate(new UserPage());

            }
            else
            {
                MessageBox.Show("Пользователь с таким именем не найден");
            }
        }

    }
}
