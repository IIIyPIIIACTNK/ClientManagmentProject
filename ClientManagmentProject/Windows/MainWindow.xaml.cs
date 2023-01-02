using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace ClientManagmentProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository = new Repository();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = repository;
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {

            switch (ClientType.SelectedIndex)
            {
                case 0:
                    var managerWindow = new ManagerWindow();
                    Close();
                    managerWindow.Show();
                    managerWindow.DataContext = repository;
                    break;
                case 1:
                    var consultantWindow = new ConsultantWindow();
                    Close();
                    consultantWindow.Show();
                    consultantWindow.DataContext = repository;
                    break;
                default:
                    MessageBox.Show("Выберите тип клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }
    }
}
