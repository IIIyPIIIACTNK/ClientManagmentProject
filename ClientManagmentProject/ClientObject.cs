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
    public class ClientObject : INotifyPropertyChanged
    {
        private string name;
        private string phoneNumber;
        private string idNumber;
        public string Name { get => name; set { name = value; OnPropertyChanged(Name); } }
        public string PhoneNumber { get => phoneNumber; set { phoneNumber = value; OnPropertyChanged(PhoneNumber); } }
        public string IdNumber { get => idNumber; set { idNumber = value; OnPropertyChanged(IdNumber); } }

        public List<Changes> changes = new List<Changes>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
        /// Клмент банка. Для создания в приложении
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="idNumber"></param>
        public ClientObject(string name, string phoneNumber, string idNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.idNumber = idNumber;
            changes.Add(new Changes(DateTime.Now, DataType.all, ChangeType.createClient, UserType.selfChanged));
            
        }
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
