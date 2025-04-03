using System.Linq;
using System.Windows;
using System.Windows.Controls;
using kursipovisheniakvalificaciy.entities;

namespace kursipovisheniakvalificaciy.Pages
{
    public partial class EditGroupsPage : Page
    {
        private KursyPovysheniyaKvalifikaciiEntities _context = new KursyPovysheniyaKvalifikaciiEntities();
        private Gruppy _selectedGroup;

        public EditGroupsPage()
        {
            InitializeComponent();
            LoadGroups();
        }

        private void LoadGroups()
        {
            GroupsDataGrid.ItemsSource = _context.Gruppy.ToList();
        }

        private void GroupsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsDataGrid.SelectedItem is Gruppy selectedGroup)
            {
                _selectedGroup = selectedGroup;
                NomerGruppyTextBox.Text = selectedGroup.Nomer_gruppy.ToString();
                SpecialnostTextBox.Text = selectedGroup.Specialnost;
                OtdelenieTextBox.Text = selectedGroup.Otdelenie;
                KolichestvoStudentovTextBox.Text = selectedGroup.Kolichestvo_studentov.ToString();
            }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NomerGruppyTextBox.Text, out int nomer) &&
                int.TryParse(KolichestvoStudentovTextBox.Text, out int kolichestvo))
            {
                Gruppy newGroup = new Gruppy
                {
                    Nomer_gruppy = nomer,
                    Specialnost = SpecialnostTextBox.Text,
                    Otdelenie = OtdelenieTextBox.Text,
                    Kolichestvo_studentov = kolichestvo
                };

                _context.Gruppy.Add(newGroup);
                _context.SaveChanges();
                LoadGroups();
            }
            else
            {
                MessageBox.Show("Некорректный ввод данных!");
            }
        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedGroup != null &&
                int.TryParse(KolichestvoStudentovTextBox.Text, out int kolichestvo))
            {
                _selectedGroup.Specialnost = SpecialnostTextBox.Text;
                _selectedGroup.Otdelenie = OtdelenieTextBox.Text;
                _selectedGroup.Kolichestvo_studentov = kolichestvo;

                _context.SaveChanges();
                LoadGroups();
            }
            else
            {
                MessageBox.Show("Выберите группу для редактирования!");
            }
        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedGroup != null)
            {
                _context.Gruppy.Remove(_selectedGroup);
                _context.SaveChanges();
                LoadGroups();
            }
            else
            {
                MessageBox.Show("Выберите группу для удаления!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
