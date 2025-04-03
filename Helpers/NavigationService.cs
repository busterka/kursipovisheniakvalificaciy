using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kursipovisheniakvalificaciy.Helpers
{
    public static class NavigationService
    {
        public static void Navigate(Page page)
        {
            MainWindow.MainFrameRef.Navigate(page);
        }

        public static void GoBack()
        {
            if (MainWindow.MainFrameRef.CanGoBack)
                MainWindow.MainFrameRef.GoBack();
        }
    }
}
