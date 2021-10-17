using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WinFormsXML.Models;

namespace WinFormsXML.Logic
{
    internal class CRUDDataBase
    {
        ClientsContext db;

        //Вставка данных в БД
        internal bool InsertDataToDB(List<Client> dataList)
        {
            using (ClientsContext db = new ClientsContext())
            {
                try
                {
                    //using SqlConnection connection = new SqlConnection(db.Database.GetConnectionString());
                    //connection.Open();
                    //SqlCommand sqlCommand = new SqlCommand("CREATE TABLE dbo.[TETSTEST] (id int, name nvarchar(55));", connection);
                    //sqlCommand.BeginExecuteNonQuery();

                    foreach (var item in dataList)
                    {
                        var searchResult = db.Client.Where(w => w.CARDCODE == item.CARDCODE).FirstOrDefault();
                        if (searchResult is not null)
                        {
                            InsertToLog($"Данные с CARDCODE {item.CARDCODE} уже есть.");
                            continue;
                        }
                        db.Client.AddRange(item);
                        db.SaveChanges();
                        InsertToLog($"Успешно добавлена запись {item.CARDCODE}");
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    InsertToLog($"Метод InsertDataToDB, {ex.Message}, {ex.InnerException.Message}");
                }

                return false;
            };
        }

        //Логирование
        internal void InsertToLog(string message)
        {
            using (ClientsContext db = new ClientsContext())
            {
                LogMessages log = new LogMessages
                {
                    Message = message,
                    DtIns = DateTime.Now,
                };
                db.LogMessage.Add(log);
                db.SaveChanges();
            };
        }

        //Чтение данных из БД
        internal BindingList<Client> ReadData()
        {
            using (ClientsContext db = new ClientsContext())
            {
                try
                {
                    BindingList<Client> data = new BindingList<Client>();
                    var dataTable = db.Client.Select(s => s).DefaultIfEmpty().AsNoTracking();
                    foreach (var item in dataTable)
                    {
                        data.Add(item);
                    }
                    return data;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    InsertToLog($"Метод ReadData, {ex.Message}, {ex.InnerException.Message}");
                }
                return new BindingList<Client>();
            }
        }

        //Обновление данных в БД
        internal bool UpdateData(List<string> dataList)
        {
            using (ClientsContext db = new ClientsContext())
            {
                try
                {
                    decimal id = Convert.ToDecimal(dataList[0]);
                    var clientUpd = db.Client.Where(w => w.CARDCODE == id).Select(s => s).First();
                    clientUpd.STARTDATE = (dataList[1].Equals("")) ? DateTime.MinValue : Convert.ToDateTime(dataList[1]);
                    clientUpd.FINISHDATE = (dataList[2].Equals("")) ? DateTime.MinValue : Convert.ToDateTime(dataList[2]);
                    clientUpd.LASTNAME = dataList[3];
                    clientUpd.FIRSTNAME = dataList[4];
                    clientUpd.SURNAME = dataList[5];
                    clientUpd.GENDER = dataList[6];
                    clientUpd.BIRTHDAY = (dataList[7].Equals("")) ? DateTime.MinValue : Convert.ToDateTime(dataList[7]);
                    clientUpd.PHONEHOME = dataList[8];
                    clientUpd.PHONEMOBIL = dataList[9];
                    clientUpd.EMAIL = dataList[10];
                    clientUpd.CITY = dataList[11];
                    clientUpd.STREET = dataList[12];
                    clientUpd.HOUSE = dataList[13];
                    clientUpd.APARTMENT = dataList[14];
                    db.Client.Update(clientUpd);
                    db.SaveChanges();
                    InsertToLog($"Запись {id} успешно обновлена");
                    return true;
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    InsertToLog($"Метод UpdateData, {ex.Message}, {ex.InnerException.Message}");
                }
                return false;
            }
        }
    }
}
