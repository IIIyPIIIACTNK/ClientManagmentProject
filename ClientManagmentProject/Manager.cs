using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagmentProject
{
    public class Manager : Consultant
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

        public override void SetPhoneNumber(ClientObject client, string number)
        {
            if (client.PhoneNumber == number) return;
            client.PhoneNumber = number;
            ChangedData(client, DataType.phoneNumber, ChangeType.setClientData);
        }

        private new void ChangedData(ClientObject client, DataType dataType, ChangeType changeType)
        {
            client.changes.Add(new Changes(DateTime.Now, dataType, changeType, UserType.manager));
        }
    }
}
