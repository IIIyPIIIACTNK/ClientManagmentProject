using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ClientManagmentProject
{
    /// <summary>
    /// Логика взаимодействия для ConsultantWindow.xaml
    /// </summary>
    public partial class ConsultantWindow : Window
    {
        Consultant consultant;

        readonly string path = @"C:\Users\gerem\VSProjects\ClientManagmentProject\ClientManagmentProject\Data\Clients.xml";

        List<ClientObject> clients = new List<ClientObject>();
        ObservableCollection<ClientObject> obsClients { get; set; }
        ObservableCollection<Changes> clientsChanges { get; set; }
        public ConsultantWindow()
        {
            InitializeComponent();
            XMLManager.Deserialize(path, clients);
            consultant = new Consultant();
            obsClients = new ObservableCollection<ClientObject>(clients);
            clientsList.ItemsSource = obsClients;
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            XMLManager.SerializeToXML(path, clients);
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void clientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clientPhoneNumber.Text = clients[clientsList.SelectedIndex].PhoneNumber;

            clientsChanges = new ObservableCollection<Changes>(clients[clientsList.SelectedIndex].changes);
            clientsChangesList.ItemsSource = clientsChanges;
        }


        private void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            if(clientsList.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать клиента для изменения", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(clientPhoneNumber.Text == String.Empty)
            {
                clientPhoneNumber.Text = clients[clientsList.SelectedIndex].PhoneNumber;
                MessageBox.Show("Поле необходимо заполнить", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            consultant.SetPhoneNumber(clients[clientsList.SelectedIndex], clientPhoneNumber.Text);
        }
    }


}
