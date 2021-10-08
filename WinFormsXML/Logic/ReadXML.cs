using System;
using System.Collections.Generic;
using System.Xml;

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

        internal List<object> GetDataFromXML()
        {
            List<object> listItems = new();
            try
            {
                int i = 0;
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(_xml);
                XmlElement xmlRroot = xDoc.DocumentElement; // корневой элемент
                // обход всех узлов в корневом элементе (Если их несколько)
                foreach (XmlNode xmlNode in xmlRroot)
                {
                    if (xmlNode.Attributes.Count > 0) // здесь ветка Client
                    {
                        foreach (var item in xmlNode.Attributes)
                        {
                            var nameItem = xmlNode.Attributes.Item(i).Name;
                            string attr = xmlNode.Attributes.GetNamedItem(nameItem).InnerText;
                            if (attr != null)
                                listItems.Add(attr);
                            i++;
                        }
                    }
                }
                crud.InsertToLog($"Данные из XML были выгружены успешно. Путь файла: {_xml}");
                return listItems;
            }
            catch (Exception ex)
            {
                crud.InsertToLog($"Метод GetDataFromXML, {ex.Message}");
            }
            return listItems;
        }
    }
}
