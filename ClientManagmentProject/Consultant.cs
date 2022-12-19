using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagmentProject
{
    public class Consultant : ManagmentBaseClass
    {

        public virtual void SetPhoneNumber(ClientObject client, string number)
        {
            if (client.PhoneNumber == number) return;
            client.PhoneNumber = number;
            ChangedData(client, DataType.phoneNumber, ChangeType.setClientData);
        }


        public Consultant() 
        {

        }
    }
}
