using System.Linq;
using System.Windows;
using System.Windows.Controls;
using kursipovisheniakvalificaciy.entities;
using System.Data.Entity;

namespace kursipovisheniakvalificaciy.Pages
{
    public partial class EditKursiPage : Page
    {
        private KursyPovysheniyaKvalifikaciiEntities _context = new KursyPovysheniyaKvalifikaciiEntities();
        private Nagruzka _selectedNagruzka;

        public EditKursiPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Загружаем нагрузку преподавателей
            NagruzkaDataGrid.ItemsSource = _context.Nagruzka
                .Include(n => n.Prepodavateli)
                .Include(n => n.Gruppy)
                .ToList();

            // Заполняем список преподавателей
            PrepodavatelComboBox.ItemsSource = _context.Prepodavateli
                .ToList();
            PrepodavatelComboBox.DisplayMemberPath = "Familiya";
            PrepodavatelComboBox.SelectedValuePath = "Kod_prepodavatelya";

            // Заполняем список групп
            GruppaComboBox.ItemsSource = _context.Gruppy.ToList();
            GruppaComboBox.DisplayMemberPath = "Nomer_gruppy";
            GruppaComboBox.SelectedValuePath = "Nomer_gruppy";
        }

        private void NagruzkaDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NagruzkaDataGrid.SelectedItem is Nagruzka selectedNagruzka)
            {
                _selectedNagruzka = selectedNagruzka;

                PrepodavatelComboBox.SelectedValue = selectedNagruzka.Kod_prepodavatelya;
                GruppaComboBox.SelectedValue = selectedNagruzka.Nomer_gruppy;
                PredmetTextBox.Text = selectedNagruzka.Predmet;
                TipZanyatiyaTextBox.Text = selectedNagruzka.Tip_zanyatiya;
                KolichestvoChasovTextBox.Text = selectedNagruzka.Kolichestvo_chasov.ToString();
                OplataTextBox.Text = selectedNagruzka.Oplata.ToString();
            }
        }

        private void AddNagruzka_Click(object sender, RoutedEventArgs e)
        {
            if (PrepodavatelComboBox.SelectedValue != null && GruppaComboBox.SelectedValue != null &&
                int.TryParse(KolichestvoChasovTextBox.Text, out int chasy) &&
                decimal.TryParse(OplataTextBox.Text, out decimal oplata))
            {
                Nagruzka newNagruzka = new Nagruzka
                {
                    Kod_prepodavatelya = (int)PrepodavatelComboBox.SelectedValue,
                    Nomer_gruppy = (int)GruppaComboBox.SelectedValue,
                    Predmet = PredmetTextBox.Text,
                    Tip_zanyatiya = TipZanyatiyaTextBox.Text,
                    Kolichestvo_chasov = chasy,
                    Oplata = oplata
                };

                _context.Nagruzka.Add(newNagruzka);
                _context.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Некорректный ввод данных!");
            }
        }

        private void EditNagruzka_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedNagruzka != null &&
                int.TryParse(KolichestvoChasovTextBox.Text, out int chasy) &&
                decimal.TryParse(OplataTextBox.Text, out decimal oplata))
            {
                _selectedNagruzka.Predmet = PredmetTextBox.Text;
                _selectedNagruzka.Tip_zanyatiya = TipZanyatiyaTextBox.Text;
                _selectedNagruzka.Kolichestvo_chasov = chasy;
                _selectedNagruzka.Oplata = oplata;

                _context.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования!");
            }
        }

        private void DeleteNagruzka_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedNagruzka != null)
            {
                _context.Nagruzka.Remove(_selectedNagruzka);
                _context.SaveChanges();
                LoadData();
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
