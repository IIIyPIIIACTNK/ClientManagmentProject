using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public enum ChangeType
{
    createClient,
    setClientData,
    removeClinet,
}
public enum UserType
{
    manager,
    consultant,
    selfChanged
}

public enum DataType
{
    name,
    phoneNumber,
    idNumber,
    all
}

namespace ClientManagmentProject
{
    public class ClientObject : INotifyPropertyChanged, IComparable<ClientObject>
    {
        private string name;
        private string phoneNumber;
        private string idNumber;
        private List<Changes> thisClientChanges = new List<Changes>();
        public string Name { get => name; 
            set { name = value; OnPropertyChanged(Name); 
                ThisClientChanges.Add(new Changes(DateTime.Now, DataType.name, ChangeType.setClientData, userType)); } }
        public string PhoneNumber { get => phoneNumber; 
            set { phoneNumber = value; OnPropertyChanged(PhoneNumber); 
                ThisClientChanges.Add(new Changes(DateTime.Now, DataType.phoneNumber, ChangeType.setClientData, userType)); } }
        public string IdNumber { get => idNumber; set { idNumber = value; 
                OnPropertyChanged(IdNumber); 
                ThisClientChanges.Add(new Changes(DateTime.Now, DataType.idNumber, ChangeType.setClientData, userType)); } }
        /// <summary>
        /// Список изменений клиента
        /// </summary>
        public List<Changes> ThisClientChanges { get => thisClientChanges; set => thisClientChanges = value; }
        /// <summary>
        /// Тип аккаунта исполнителя
        /// </summary>
        public UserType userType;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Констуркторы

        /// <summary>
        /// Клиент банка. Для создания из архива
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="idNumber"></param>
        /// <param Из архива="flag"></param>
        public ClientObject(string name, string phoneNumber, string idNumber, bool flag)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.idNumber = idNumber;

        }
        /// <summary>
        /// Клиент банка. Для создания в приложении
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="idNumber"></param>
        public ClientObject(string name, string phoneNumber, string idNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.idNumber = idNumber;
            thisClientChanges.Add(new Changes(DateTime.Now, DataType.all, ChangeType.createClient, UserType.selfChanged));

        }

        public ClientObject()
        {
            thisClientChanges.Add(new Changes(DateTime.Now, DataType.all, ChangeType.createClient, UserType.selfChanged));
        }
        #endregion
        public int CompareTo(ClientObject other)
        {
            return Name.CompareTo(other.Name);
        }

        public class Changes
        {
            public DateTime recentChangeDate { get; set; }
            public DataType changeDataType { get; set; }
            public ChangeType changeType { get; set; }
            public UserType changeUserType { get; set; }

            public Changes(DateTime dateTime, DataType dataType, ChangeType changeType, UserType userType)
            {
                this.changeDataType = dataType;
                this.changeType = changeType;
                this.changeUserType = userType;
                this.recentChangeDate = dateTime;
            }
        }
    }

}
