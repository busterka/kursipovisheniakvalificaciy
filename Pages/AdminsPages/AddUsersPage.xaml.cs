using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using kursipovisheniakvalificaciy.entities;

namespace kursipovisheniakvalificaciy.Pages
{
    public partial class AddUsersPage : Page
    {
        private KursyPovysheniyaKvalifikaciiEntities dbContext;

        public AddUsersPage()
        {
            InitializeComponent();
            dbContext = new KursyPovysheniyaKvalifikaciiEntities();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            // Загружаем роли из базы
            RoleComboBox.ItemsSource = dbContext.Roli.ToList();
            RoleComboBox.DisplayMemberPath = "Nazvanie";
            RoleComboBox.SelectedValuePath = "Kod_roli";

            // Загружаем пол из базы
            GenderComboBox.ItemsSource = dbContext.Pol.ToList();
            GenderComboBox.DisplayMemberPath = "Tip_pola";
            GenderComboBox.SelectedValuePath = "Kod_pola";
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password) ||
                RoleComboBox.SelectedValue == null ||
                GenderComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newUser = new Polzovateli
            {
                Login = LoginTextBox.Text,
                Parol = PasswordBox.Password,
                Rol = (int)RoleComboBox.SelectedValue,
                Kod_pola = (int)GenderComboBox.SelectedValue
            };

            dbContext.Polzovateli.Add(newUser);
            dbContext.SaveChanges();
            MessageBox.Show("Пользователь добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            // Очищаем поля после добавления
            LoginTextBox.Clear();
            PasswordBox.Clear();
            RoleComboBox.SelectedIndex = -1;
            GenderComboBox.SelectedIndex = -1;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
