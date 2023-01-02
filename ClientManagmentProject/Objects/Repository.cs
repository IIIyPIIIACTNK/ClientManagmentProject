using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientManagmentProject
{
    public class Repository : INotifyPropertyChanged
    {
        readonly string path = @"Clients.xml";


        private List<ClientObject> clients = new List<ClientObject>();

        private ObservableCollection<ClientObject> obsClients;
        private ClientObject selectedClient;

        //Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand saveCommand;

        #region Поля
        public ObservableCollection<ClientObject> ObsClients { get => obsClients; set { obsClients = value; } }
        public List<ClientObject> Clients { get => clients; set { clients = value; } }
        public ClientObject SelectedClient
        {
            get => selectedClient;
            set { selectedClient = value; OnPropertyChanged("SelectedClient"); }
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(x =>
                    {
                        ClientObject client = new ClientObject();
                        obsClients.Add(client);
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
                            obsClients.Remove(client);
                        }
                    }, (x => obsClients.Count >= 0)));
        }

        #endregion

        /// <summary>
        /// Возвращает список изменения клиента по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        public List<ClientObject.Changes> GetClientChangesList(int index)
        {
            return clients[index].ThisClientChanges;
        }



        public void SaveRepository()
        {
            XMLManager.SerializeToXML(path, clients);
        }
        /// <summary>
        /// Репозиторий клиентов. При создании сортируется по имени
        /// </summary>
        public Repository()
        {
            clients = XMLManager.Deserialize(path, clients);
            clients.Sort();
            obsClients = new ObservableCollection<ClientObject>(clients);
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
