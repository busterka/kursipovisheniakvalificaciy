using System.Linq;
using System.Windows;
using System.Windows.Controls;
using kursipovisheniakvalificaciy.entities;

namespace kursipovisheniakvalificaciy.Pages
{
    public partial class GroupPage : Page
    {
        private KursyPovysheniyaKvalifikaciiEntities dbContext;

        public GroupPage()
        {
            InitializeComponent();
            dbContext = new KursyPovysheniyaKvalifikaciiEntities();
            LoadGroups();
        }

        private void LoadGroups()
        {
            GroupsDataGrid.ItemsSource = dbContext.Gruppy.ToList();
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
