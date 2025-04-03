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
using kursipovisheniakvalificaciy.entities;
using kursipovisheniakvalificaciy.Pages;

namespace kursipovisheniakvalificaciy.Pages
{
 public partial class MainMenu : Page
{
    private Polzovateli CurrentUser; // Хранит данные авторизованного пользователя

    public MainMenu(Polzovateli user)
    {
        InitializeComponent();
        CurrentUser = user; // Сохраняем пользователя
    }


        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage(CurrentUser)); // Перейти в профиль
        }

        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupPage()); // Перейти к группам
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage()); // Вернуться на страницу входа
        }
    }
}

