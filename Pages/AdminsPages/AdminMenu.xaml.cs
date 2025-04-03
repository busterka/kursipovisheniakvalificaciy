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

namespace kursipovisheniakvalificaciy.Pages
{
    public partial class AdminMenu : Page
    {
        public AdminMenu(entities.Polzovateli user)
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUsersPage()); // Страница добавления пользователя
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersPage()); // Страница списка пользователей
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditMenuPage()); // Страница редактирования данных
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage()); // Возвращение на страницу входа
        }
    }
}