using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using WinFormsXML.Models;

namespace WinFormsXML.Logic
{
    internal class CRUDDataBase
    {
        private List<object> _dataList;

        internal bool InsertDataToDB(List<object> dataList)
        {
            using ClientsContext db = new ClientsContext();
            try
            {
                this._dataList = dataList;
                //Проверяем на отсутствие значения
                _dataList[1] = (_dataList[1].Equals("")) ? DateTime.MinValue : _dataList[1];
                _dataList[2] = (_dataList[2].Equals("")) ? DateTime.MinValue : _dataList[2];
                _dataList[7] = (_dataList[7].Equals("")) ? DateTime.MinValue : _dataList[7];
                var id = Convert.ToDecimal(_dataList[0]);
                var searchResult = db.Client.Where(w => w.CARDCODE == id).FirstOrDefault();
                if (searchResult is not null)
                    throw new Exception($"Данные с CARDCODE {id} уже есть.");

                Clients newClient = new Clients
                {
                    CARDCODE = Convert.ToDecimal(_dataList[0]),
                    STARTDATE = Convert.ToDateTime(_dataList[1]),
                    FINISHDATE = Convert.ToDateTime(_dataList[2]),
                    LASTNAME = _dataList[3].ToString(),
                    FIRSTNAME = _dataList[4].ToString(),
                    SURNAME = _dataList[5].ToString(),
                    GENDER = _dataList[6].ToString(),
                    BIRTHDAY = DateTime.Parse(_dataList[7].ToString(), new CultureInfo("ru-RU")), //Для разнообразия, используется при других форматах
                    PHONEHOME = _dataList[8].ToString(),
                    PHONEMOBIL = _dataList[9].ToString(),
                    EMAIL = _dataList[10].ToString(),
                    CITY = _dataList[11].ToString(),
                    STREET = _dataList[12].ToString(),
                    HOUSE = Convert.ToInt32(_dataList[13]),
                    APARTMENT = Convert.ToInt32(_dataList[14])
                };
                db.Client.Add(newClient);
                db.SaveChanges();
                InsertToLog($"Успешно добавлена запись {id}");
                return true;
            }
            catch (Exception ex)
            {
                db.Dispose();
                InsertToLog($"Метод InsertDataToDB, {ex.Message}");
            }
            return false;
        }

        internal void InsertToLog(string error)
        {
            using (ClientsContext db = new ClientsContext())
            {
                LogMessages log = new LogMessages
                {
                    Message = error,
                    DtIns = DateTime.Now,
                };
                db.LogMessage.Add(log);
                db.SaveChanges();
            };
        }

        internal BindingList<Clients> ReadData()
        {
            using ClientsContext db = new ClientsContext(); try
            {
                IQueryable<Clients> dataTable;
                dataTable = db.Client.Select(s => s).DefaultIfEmpty().AsNoTracking();
                BindingList<Clients> data = new BindingList<Clients>();
                foreach (var item in dataTable)
                {
                    data.Add(item);
                }
                return data;
            }
            catch (Exception ex)
            {
                db.Dispose();
                InsertToLog($"Метод ReadData, {ex.Message}");
            }
            return new BindingList<Clients>();
        }

        internal bool UpdateData(List<object> dataList)
        {
            using ClientsContext db = new ClientsContext();
            try
            {
                List<object> _dataList = dataList;
                decimal id = Convert.ToDecimal(_dataList[0]);
                var clientUpd = db.Client.Where(w => w.CARDCODE == id).Select(s => s).First();
                clientUpd.STARTDATE = Convert.ToDateTime(_dataList[1]);
                clientUpd.FINISHDATE = Convert.ToDateTime(_dataList[2]);
                clientUpd.LASTNAME = _dataList[3].ToString();
                clientUpd.FIRSTNAME = _dataList[4].ToString();
                clientUpd.SURNAME = _dataList[5].ToString();
                clientUpd.GENDER = _dataList[6].ToString();
                clientUpd.BIRTHDAY = Convert.ToDateTime(_dataList[7]);
                clientUpd.PHONEHOME = _dataList[8].ToString();
                clientUpd.PHONEMOBIL = _dataList[9].ToString();
                clientUpd.EMAIL = _dataList[10].ToString();
                clientUpd.CITY = _dataList[11].ToString();
                clientUpd.STREET = _dataList[12].ToString();
                clientUpd.HOUSE = Convert.ToInt32(_dataList[13]);
                clientUpd.APARTMENT = Convert.ToInt32(_dataList[14]);
                db.Client.Update(clientUpd);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                db.Dispose();
                InsertToLog($"Метод UpdateData, {ex.Message}");
            }
            return false;
        }
    }
}
