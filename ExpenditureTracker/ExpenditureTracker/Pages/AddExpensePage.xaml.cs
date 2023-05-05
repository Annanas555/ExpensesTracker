using ExpenditureTracker.Data;
using ExpenditureTracker.Models;
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
    /// Логика взаимодействия для AddExpensePage.xaml
    /// </summary>
    public partial class AddExpensePage : Page
    {
        public AddExpensePage()
        {
            InitializeComponent();
            var categories = App.Context.Categories.Where(c => c.UserId == App.CurrentUser.UserId).Select(c => c.CategoryName).ToList();
            CategoryComboBox.ItemsSource = categories;
            CategoryComboBox.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = (Category)CategoryComboBox.SelectedItem;

            if (!decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                StatusTextBlock.Text = "Введите корректную сумму";
                return;
            }

            using (var dbContext = new TrackerContext())
            {
                var newExpense = new Models.Expense
                {
                    UserId = App.CurrentUser.UserId,
                    CategoryId = selectedCategory.CategoryId,
                    ExpenseAmount = amount,
                    ExpenseDescription = DescriptionTextBox.Text,
                    ExpenseDate = DateTime.Now
                };

                App.Context.Expenses.Add(newExpense);
                App.Context.SaveChanges();
            }

            StatusTextBlock.Text = "Запись успешно добавлена";
        }
    }
}
