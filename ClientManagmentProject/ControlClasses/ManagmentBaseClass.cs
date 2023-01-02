using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagmentProject
{
    public abstract class ManagmentBaseClass
    {


        protected void ChangedData(ClientObject client, DataType dataType, ChangeType changeType)
        {
            client.ThisClientChanges.Add(new ClientObject.Changes(DateTime.Now, dataType, changeType, UserType.consultant));
        }
        public ManagmentBaseClass()
        {
            
        }
    }
}
