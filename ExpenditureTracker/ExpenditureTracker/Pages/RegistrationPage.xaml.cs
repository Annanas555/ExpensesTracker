using ExpenditureTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ExpenditureTracker.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            // Хотя бы 1: заглавная, строчная буква, знак, цифра, длина не менее 8 символов.
            Regex reg = new Regex(@"^(?=.*[\p{Ll}\p{Lu}])(?=.*\d)(?=.*[^\p{L}\d])[\p{L}\d\S]{1,10}$");
            // Создание списка ошибок, которые может допустить пользователь.
            List<string> errors = new List<string>();
            using (var db = new TrackerContext())
            {
                // Переменная для выборки существующего логина в базе данных, при попытке создать аккаунт с таким же именем.
                var existingUser = db.Users.FirstOrDefault(u => u.UserName == TBoxLogin.Text);

                if (TBoxLogin.Text == "")
                {
                    errors.Add("Введите логин.");
                }

                if (TBoxLogin.Text.Length < 4)
                {
                    errors.Add("Логин должен быть не менее 4 символов в длину.");
                }

                if (existingUser != null)
                {
                    errors.Add("Пользователь с таким именем уже существует.");
                }

                if (PBoxPassword.Password == "")
                {
                    errors.Add("Введите пароль.");
                }

                if (PBoxConfirmPassword.Password == "")
                {
                    errors.Add("Подтвердите пароль.");
                }

                if (PBoxPassword.Password.Length < 8 || PBoxConfirmPassword.Password.Length < 8)
                {
                    errors.Add("Пароль должен быть не менее 8 символов в длину.");
                }

                if (PBoxPassword.Password.Length > 20 || PBoxConfirmPassword.Password.Length > 20)
                {
                    errors.Add("Пароль должен быть не более 20 символов в длину.");
                }

                if (!reg.IsMatch(PBoxPassword.Password) || !reg.IsMatch(PBoxConfirmPassword.Password))
                {
                    errors.Add("Пароль должен содержать хотя бы одну заглавную букву, одну строчную букву, одну цифру и один символ, не являющийся буквой или цифрой.");
                }

                if (PBoxPassword.Password != PBoxConfirmPassword.Password)
                {
                    errors.Add("Пароли не совпадают.");
                }

                // Проверка на наличие ошибок во время попытки регистрации.
                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors), "Ошибка");
                }
                else
                {
                    // Шифрование введенного пароля.
                    MD5 md5 = new MD5CryptoServiceProvider();
                    string pass = PBoxPassword.Password;
                    byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
                    // Создание записи пользователя в базе данных.
                    var newUser = new Models.User
                    {
                        UserName = TBoxLogin.Text,
                        Password = checkSum
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    MessageBox.Show("Ваш аккаунт создан", "Успешно");
                    NavigationService.GoBack();
                }
            }
        }
    }
}
