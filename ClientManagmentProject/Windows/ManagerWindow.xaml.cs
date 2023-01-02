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
        }


        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();

        }

        private void AddClientButtonClick(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow();
            addClientWindow.Show();
            addClientWindow.DataContext = DataContext;
        }

        private void SaveClientButtonClick(object sender, RoutedEventArgs e)
        {
            //Repository.SaveRepository();
            MessageBox.Show("Сохранено");
        }

        private void DeleteClientButtonClick(object sender, RoutedEventArgs e)
        {
            //Repository.Clients.Remove((ClientObject)clientsList.SelectedItem);
            //Repository.ObsClients.Remove((ClientObject)clientsList.SelectedItem);
        }
    }
}
