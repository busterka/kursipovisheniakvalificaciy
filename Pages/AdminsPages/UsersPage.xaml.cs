using System.Linq;
using System.Windows;
using System.Windows.Controls;
using kursipovisheniakvalificaciy.entities;

namespace kursipovisheniakvalificaciy.Pages
{
    public partial class UsersPage : Page
    {
        private readonly KursyPovysheniyaKvalifikaciiEntities dbContext;

        public UsersPage()
        {
            InitializeComponent();
            dbContext = new KursyPovysheniyaKvalifikaciiEntities();
            LoadUsers();
        }

        private void LoadUsers()
        {
            UsersDataGrid.ItemsSource = dbContext.Polzovateli.ToList();
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Polzovateli selectedUser)
            {
                try
                {
                    dbContext.SaveChanges();
                    MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadUsers();
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Polzovateli selectedUser)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    dbContext.Polzovateli.Remove(selectedUser);
                    dbContext.SaveChanges();
                    LoadUsers();
                }
            }
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
