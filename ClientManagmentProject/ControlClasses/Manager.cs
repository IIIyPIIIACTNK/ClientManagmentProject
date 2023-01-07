using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientManagmentProject
{
    public class Manager : ManagmentBaseClass, INotifyPropertyChanged
    {
        private ClientObject selectedClient;

        //Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;

        #region Поля
        public ClientObject SelectedClient
        {
            get => selectedClient; 
            set { selectedClient = value; OnPropertyChanged(); 
                if (selectedClient != null)selectedClient.userType = UserType.manager; }
        }
        //Комманды
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(x =>
                    {
                        ClientObject client = new ClientObject();
                        base.ObsClients.Add(client);
                        SelectedClient = client;
                    }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get => removeCommand ?? (removeCommand = new RelayCommand(x =>
                    {
                        ClientObject client = x as ClientObject;
                        if (client != null)
                        {
                            base.obsClients.Remove(client);
                        }
                    }, (x => obsClients.Count >= 0)));
        }
        #endregion


        /// <summary>
        /// Репозиторий клиентов. При создании сортируется по имени
        /// </summary>
        public Manager()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
