using System;
using System.Windows;
using System.Windows.Controls;

namespace ClientManagmentProject
{

    public partial class ManagerWindow : Window
    {
        Manager manager;

        public ManagerWindow()
        {
            InitializeComponent();
            manager = new Manager();
            clientsList.ItemsSource = Repository.ObsClients;
        }

        private void clientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clientPhoneNumber.Text = Repository.Clients[clientsList.SelectedIndex].PhoneNumber;
            clientIdNumber.Text = Repository.Clients[clientsList.SelectedIndex].IdNumber;

            clientsChangesList.ItemsSource = Repository.GetClientChangesList(clientsList.SelectedIndex);
        }

        private void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            if (clientsList.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать клиента для изменения", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (clientPhoneNumber.Text == string.Empty || clientIdNumber.Text == string.Empty || clientName.Text == string.Empty)
            {
                clientPhoneNumber.Text = Repository.Clients[clientsList.SelectedIndex].PhoneNumber;
                clientIdNumber.Text = Repository.Clients[clientsList.SelectedIndex].IdNumber;
                clientName.Text = string.Empty;
                MessageBox.Show("Поля необходимо заполнить", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            manager.SetPhoneNumber(Repository.Clients[clientsList.SelectedIndex], clientPhoneNumber.Text);
            manager.SetIdNumber(Repository.Clients[clientsList.SelectedIndex], clientIdNumber.Text);
            manager.SetClientName(Repository.Clients[clientsList.SelectedIndex], clientName.Text);
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Repository.SaveRepository();
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();

        }

        private void AddClientButtonClick(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void SaveClientButtonClick(object sender, RoutedEventArgs e)
        {
            Repository.SaveRepository();
            MessageBox.Show("Сохранено");
        }


    }
}
