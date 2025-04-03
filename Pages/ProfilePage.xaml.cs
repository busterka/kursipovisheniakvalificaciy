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

namespace kursipovisheniakvalificaciy.Pages
{
    public partial class ProfilePage : Page
    {
        public ProfilePage(Polzovateli currentUser)
        {
            InitializeComponent();
            DataContext = currentUser; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
