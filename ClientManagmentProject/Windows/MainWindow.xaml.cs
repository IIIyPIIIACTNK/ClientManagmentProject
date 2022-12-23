using System.Windows;

namespace ClientManagmentProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void StartButton(object sender, RoutedEventArgs e)
        {

            switch (ClientType.SelectedIndex)
            {
                case 0:
                    var managerWindow = new ManagerWindow();
                    Close();
                    managerWindow.Show();
                    break;
                case 1:
                    var consultantWindow = new ConsultantWindow();
                    Close();
                    consultantWindow.Show();
                    break;
                default:
                    MessageBox.Show("Выберите тип клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }
    }
}
