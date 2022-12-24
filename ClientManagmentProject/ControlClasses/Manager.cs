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
        public Manager() 
        {
        }
        public void SetClientName(ClientObject client, string name)
        {
            client.Name = name;
            ChangedData(client, DataType.name, ChangeType.setClientData);
        }

        public void SetIdNumber(ClientObject client, string idNumber)
        {
            client.IdNumber = idNumber;
            ChangedData(client, DataType.idNumber, ChangeType.setClientData);
        }

        public void SetPhoneNumber(ClientObject client, string number)
        {
            client.PhoneNumber = number;
            ChangedData(client, DataType.phoneNumber, ChangeType.setClientData);
        }

        private new void ChangedData(ClientObject client, DataType dataType, ChangeType changeType)
        {
            client.changes.Add(new ClientObject.Changes(DateTime.Now, dataType, changeType, UserType.manager));
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
