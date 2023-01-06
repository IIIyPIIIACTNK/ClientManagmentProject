using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ClientManagmentProject
{
    public abstract class ManagmentBaseClass
    {
        readonly string path = @"Clients.xml";

        protected ObservableCollection<ClientObject> obsClients; 
        protected List<ClientObject> clientsList;

        private RelayCommand saveCommand;

        public ObservableCollection<ClientObject> ObsClients 
        { 
            get => obsClients; 
            set 
            {
                obsClients = value;
                clientsList = new List<ClientObject>(obsClients); clientsList.Sort(); 
                obsClients = new ObservableCollection<ClientObject>(clientsList);
                MessageBox.Show("sort");
            } 
        }

        //Комманды
        public RelayCommand SaveCommand
        {
            get => saveCommand ?? (saveCommand = new RelayCommand(x =>
            {
                clientsList = new List<ClientObject>(obsClients);
                XMLManager.SerializeToXML(path, clientsList);
            }));
        }
        #region Конструктор
        public ManagmentBaseClass()
        {
            clientsList = XMLManager.Deserialize(path);
            clientsList.Sort();
            obsClients = new ObservableCollection<ClientObject>(clientsList);
        }

        #endregion
        protected void ChangedData(ClientObject client, DataType dataType, ChangeType changeType,UserType userType)
        {
            client.ThisClientChanges.Add(new ClientObject.Changes(DateTime.Now, dataType, changeType, userType));
        }
        protected void SaveToXML()
        {
            XMLManager.SerializeToXML(path, clientsList);
        }

        /// <summary>
        /// Возвращает список изменения клиента по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        public List<ClientObject.Changes> GetClientChangesList(int index)
        {
            return clientsList[index].ThisClientChanges;
        }
    }
}
