using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using kursipovisheniakvalificaciy.Pages;

namespace kursipovisheniakvalificaciy.Pages
{
    public partial class EditMenuPage : Page
    {
        public EditMenuPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditGroups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditGroupsPage());
        }

        private void EditKursi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditKursiPage());
        }
    }
}
