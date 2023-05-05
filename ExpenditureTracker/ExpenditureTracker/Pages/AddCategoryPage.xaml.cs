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
    /// Логика взаимодействия для AddCategoryPage.xaml
    /// </summary>
    public partial class AddCategoryPage : Page
    {
        public AddCategoryPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var newCategory = new Models.Category
            {
                CategoryName = CategoryNameTextBox.Text,
                UserId = App.CurrentUser.UserId
            };
            App.Context.Categories.Add(newCategory);
            App.Context.SaveChanges();
            MessageBox.Show("Категория добавлена", "Успешно");
            NavigationService.GoBack();
        }
    }
}
