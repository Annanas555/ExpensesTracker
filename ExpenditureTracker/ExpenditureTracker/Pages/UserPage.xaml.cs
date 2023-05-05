using ExpenditureTracker.Data;
using ExpenditureTracker.Models;
using Microsoft.EntityFrameworkCore;
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

namespace ExpenditureTracker.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {

        public UserPage()
        {
            InitializeComponent();
            Title = App.CurrentUser.UserName;
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddExpensePage());
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCategoryPage());
        }

        public void MyExpenses()
        {
            var expenses = App.Context.Expenses.Where(e => e.UserId == App.CurrentUser.UserId).ToList();
            LViewExpenses.ItemsSource = expenses;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MyExpenses();
        }
    }
}
