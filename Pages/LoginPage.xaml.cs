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
    public partial class LoginPage : Page
    {
        private readonly KursyPovysheniyaKvalifikaciiEntities _db = new KursyPovysheniyaKvalifikaciiEntities();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            using (var db = new KursyPovysheniyaKvalifikaciiEntities())
            {
                var user = db.Polzovateli.FirstOrDefault(u => u.Login == login && u.Parol == password);

                if (user != null)
                {
                    if (user.Rol == 3) 
                    {
                        NavigationService.Navigate(new AdminMenu(user));
                    }
                    else
                    {
                        NavigationService.Navigate(new MainMenu(user));
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}