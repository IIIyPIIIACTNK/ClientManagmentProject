using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagmentProject
{
    static class Repository
    {
        readonly static string path = @"Clients.xml";


        static private List<ClientObject> clients = XMLManager.Deserialize(path);

        static private ObservableCollection<ClientObject> obsClients;




        #region Поля

        static public ObservableCollection<ClientObject> ObsClients { get => obsClients; set { obsClients = value; } }

        static public List<ClientObject> Clients { get => clients; set { clients = value; } }

        #endregion

        /// <summary>
        /// Возвращает список изменения клиента по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        static public List<Changes> GetClientChangesList(int index)
        {
            return clients[index].changes;
        }

        static public void SaveRepository()
        {
            XMLManager.SerializeToXML(path, clients);
        }
        /// <summary>
        /// Репозиторий клиентов. При создании сортируется по имени
        /// </summary>
        static Repository() {
            clients.Sort();
            obsClients = new ObservableCollection<ClientObject>(clients);
        }

        
    }
}
