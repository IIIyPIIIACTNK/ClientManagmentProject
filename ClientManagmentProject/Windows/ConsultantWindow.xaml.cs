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

        public ConsultantWindow()
        {
            InitializeComponent();
            consultant = new Consultant();
            clientsList.ItemsSource = Repository.ObsClients;
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Repository.SaveRepository();
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void clientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clientPhoneNumber.Text = Repository.Clients[clientsList.SelectedIndex].PhoneNumber;

            clientsChangesList.ItemsSource = Repository.GetClientChangesList(clientsList.SelectedIndex);
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
                clientPhoneNumber.Text = Repository.Clients[clientsList.SelectedIndex].PhoneNumber;
                MessageBox.Show("Поле необходимо заполнить", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            consultant.SetPhoneNumber(Repository.Clients[clientsList.SelectedIndex], clientPhoneNumber.Text);
        }
    }


}
