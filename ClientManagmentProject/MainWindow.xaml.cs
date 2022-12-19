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
            //var test = new List<ClientObject>() { new ClientObject("Anton", "+993123", "0011"),
            //new ClientObject("Pasha", "+7765223", "0022"),
            //new ClientObject("Natalya", "+336553", "0033")};
            //XMLManager.SerializeToXML(@"D:\Проекты VS\ClientManagmentProject\Data\Clients.xml", test);


            switch (ClientType.Text)
            {
                case "Консультант":
                    var consultantWindow = new ConsultantWindow();
                    Close();
                    consultantWindow.Show();
                    break;
                case "Менеджер":
                    var managerWindow = new ManagerWindow();
                    Close();
                    managerWindow.Show();
                    break;
                default:
                    MessageBox.Show("Выберите тип клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }
    }
}
