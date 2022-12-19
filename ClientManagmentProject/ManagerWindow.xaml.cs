using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ClientManagmentProject
{

    public partial class ManagerWindow : Window
    {
        Manager manager;

        readonly string path = @"C:\Users\gerem\VSProjects\ClientManagmentProject\ClientManagmentProject\Data\Clients.xml";

        List<ClientObject> clients = new List<ClientObject>();


        ObservableCollection<ClientObject> ObsClients { get; set; }
        ObservableCollection<Changes> ClientsChanges { get; set; }
        public ManagerWindow()
        {
            InitializeComponent();
            manager = new Manager();
            XMLManager.Deserialize(path, clients);
            ObsClients = new ObservableCollection<ClientObject>(clients);
            clientsList.ItemsSource = ObsClients;
        }

        private void clientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clientPhoneNumber.Text = clients[clientsList.SelectedIndex].PhoneNumber;
            clientIdNumber.Text = clients[clientsList.SelectedIndex].IdNumber;

            ClientsChanges = new ObservableCollection<Changes>(clients[clientsList.SelectedIndex].changes);
            clientsChangesList.ItemsSource = ClientsChanges;
        }

        private void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            if (clientsList.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать клиента для изменения", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (clientPhoneNumber.Text == String.Empty || clientIdNumber.Text == String.Empty)
            {
                clientPhoneNumber.Text = clients[clientsList.SelectedIndex].PhoneNumber;
                clientIdNumber.Text = clients[clientsList.SelectedIndex].IdNumber;
                MessageBox.Show("Поля необходимо заполнить", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            manager.SetPhoneNumber(clients[clientsList.SelectedIndex], clientPhoneNumber.Text);
            manager.SetIdNumber(clients[clientsList.SelectedIndex], clientIdNumber.Text);
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            XMLManager.SerializeToXML(path, clients);
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();

        }

        private void AddClientButtonClick(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow(ref clients);
            addClientWindow.Show();
            addClientWindow.DataContext = this;
        }

        private void SaveClientButtonClick(object sender, RoutedEventArgs e)
        {
            XMLManager.SerializeToXML(path, clients);
            SystemSounds.Question.Play();
            MessageBox.Show("Сохранено");
        }

       
    }
}
