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
using System.Windows.Shapes;

namespace ClientManagmentProject
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        List<ClientObject> clients;
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if(clientName.Text == String.Empty || clientIdNumber.Text == String.Empty || clientIdNumber.Text == String.Empty)
            {
                MessageBox.Show("Поля необходимо запомнить", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            clients.Add(new ClientObject(clientName.Text, clientPhoneNumber.Text, clientIdNumber.Text));
            
            Close();
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public AddClientWindow(ref List<ClientObject> clients)
        {
            InitializeComponent();
            this.clients = clients;
        }
    }
}
