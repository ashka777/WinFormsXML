using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WinFormsXML.Models;
using XML = WinFormsXML.XML;
using System.Linq;

namespace WinFormsXML.Logic
{
    class ReadXML
    {
        private readonly string _xml;
        CRUDDataBase crud = new CRUDDataBase();

        public ReadXML(string xml)
        {
            this._xml = xml;
        }

        internal List<Client> DeserializeXML()
        {
            List<Client> listClients = new();
            try
            {
                using (Stream readerXML = new FileStream(_xml, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XML.Clients));
                    var dataClients = (XML.Clients)serializer.Deserialize(readerXML);

                    foreach (var client in dataClients.Client)
                    {
                        listClients.Add(new Client
                        {
                            APARTMENT = client.APARTMENT,
                            BIRTHDAY = (client.BIRTHDAY.Equals("")) ? DateTime.MinValue : Convert.ToDateTime(client.BIRTHDAY),
                            CARDCODE = client.CARDCODE,
                            CITY = client.CITY,
                            EMAIL = client.EMAIL,
                            FINISHDATE = (client.FINISHDATE.Equals("")) ? DateTime.MinValue : Convert.ToDateTime(client.FINISHDATE),
                            FIRSTNAME = client.FIRSTNAME,
                            GENDER = client.GENDER,
                            HOUSE = client.HOUSE,
                            LASTNAME = client.LASTNAME,
                            PHONEHOME = client.PHONEHOME,
                            PHONEMOBIL = client.PHONEMOBIL,
                            STARTDATE = (client.STARTDATE.Equals("")) ? DateTime.MinValue : Convert.ToDateTime(client.STARTDATE),
                            STREET = client.STREET,
                            SURNAME = client.SURNAME
                        });
                    }
                };
                crud.InsertToLog($"Данные из XML были выгружены успешно. Путь файла: {_xml}");
                return listClients;
            }
            catch (Exception ex)
            {
                crud.InsertToLog($"Метод GetDataFromXML, {ex.Message}");
            }
            return listClients;
        }
    }





}
