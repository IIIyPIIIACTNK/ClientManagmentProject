using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ClientManagmentProject
{
    static class XMLManager
    {
        public static void SerializeToXML(string path, List<ClientObject> res)
        {
            XDocument document = new XDocument(
               new XElement("clients",
               from e in res
               select new XElement("client", new XAttribute("IsSerialised", "true"),
                         new XElement("name", e.Name),
                         new XElement("phoneNumber", e.PhoneNumber),
                         new XElement("idNumber", e.IdNumber),
                         from c in e.changes
                         select new XElement("changes",
                         new XElement("recentChangeDate", c.recentChangeDate),
                         new XElement("changeDataType", c.changeDataType),
                         new XElement("changeType", c.changeType),
                         new XElement("changeUserType", c.changeUserType)))));
            document.Save(path);
        }

        public static List<ClientObject> Deserialize(string path, List<ClientObject> res)
        {
            var document = XDocument.Load(path);

            var residents = document.Element("clients");

            

            if (residents != null)
            {
                foreach (var r in residents.Elements("client"))
                {
                    res.Add(new ClientObject(
                        r.Element("name").Value,
                        r.Element("phoneNumber").Value,
                        r.Element("idNumber").Value,
                        Convert.ToBoolean(r.Attribute("IsSerialised").Value)));
                   
                    foreach (var c in r.Elements("changes"))
                    {
                        res.Last().changes.Add(new Changes(
                            Convert.ToDateTime(c.Element("recentChangeDate").Value),
                            (DataType)Enum.Parse(typeof(DataType), c.Element("changeDataType").Value),
                            (ChangeType)Enum.Parse(typeof(ChangeType), c.Element("changeType").Value),
                            (UserType)Enum.Parse(typeof(UserType), c.Element("changeUserType").Value)
                            ));
                    }


                }
            }
            return res;
        }

        static public List<ClientObject> Deserialize(string path)
        {
            var document = XDocument.Load(path);

            var res = new List<ClientObject>();

            var residents = document.Element("clients");



            if (residents != null)
            {
                foreach (var r in residents.Elements("client"))
                {
                    res.Add(new ClientObject(
                        r.Element("name").Value,
                        r.Element("phoneNumber").Value,
                        r.Element("idNumber").Value,
                        Convert.ToBoolean(r.Attribute("IsSerialised").Value)));

                    foreach (var c in r.Elements("changes"))
                    {
                        res.Last().changes.Add(new Changes(
                            Convert.ToDateTime(c.Element("recentChangeDate").Value),
                            (DataType)Enum.Parse(typeof(DataType), c.Element("changeDataType").Value),
                            (ChangeType)Enum.Parse(typeof(ChangeType), c.Element("changeType").Value),
                            (UserType)Enum.Parse(typeof(UserType), c.Element("changeUserType").Value)
                            ));
                    }


                }
            }
            return res;
        }
    }
}
