using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientManagmentProject
{
    public class Manager : ManagmentBaseClass
    {
        readonly string path = @"Clients.xml";
        Repository repository;

        //Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand saveCommand;

        #region Поля
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(x =>
                    {
                        ClientObject client = new ClientObject();
                        repository.ObsClients.Add(client);
                        repository.SelectedClient = client;
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
                    repository.ObsClients.Remove(client);
                }
            }, (x => repository.ObsClients.Count >= 0)));
        }
        #endregion

        #region Констуктор
        #endregion
       
        private new void ChangedData(ClientObject client, DataType dataType, ChangeType changeType)
        {
            client.ThisClientChanges.Add(new ClientObject.Changes(DateTime.Now, dataType, changeType, UserType.manager));
        }


        /// <summary>
        /// Проверка на пристутствие необхоимых данных для изменния
        /// </summary>
        private void CheckForFilledFields(ClientObject client, string input)
        {
            if (client == null)
            {
                MessageBox.Show("Необходимо выбрать клиента для изменения", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (input == String.Empty)
            {
                MessageBox.Show("Полe необходимо заполнить", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
