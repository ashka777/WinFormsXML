using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsXML.Logic;
using WinFormsXML.Models;

namespace WinFormsXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> updateIndexRows = new();
        CRUDDataBase crud = new CRUDDataBase();

        //Получаем их XML и вставляем в БД
        private void btGet_Click(object sender, EventArgs e)
        {
            CallingReadAndPasteOperation();
        }

        //Заполняем грид
        private async void btRead_Click(object sender, EventArgs e)
        {
            BindingList<Client> data = new();
            await Task.Run(() =>
            {
                data = crud.ReadData();
            });
            if (data is not null)
            {
                dataGridView1.DataSource = data;
                dataGridView1.Columns["CARDCODE"].DisplayIndex = 0;
                dataGridView1.Columns["CARDCODE"].ReadOnly = true;
            }
        }

        //Сохраняем изменения в БД 
        private void btSave_Click(object sender, EventArgs e)
        {
            SaveOperation();
        }

        private void btInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Просьба о результатах сообщить в любом случае, \n " +
                "с указанием основных ошибок. Андрей. Спасибо!");
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введен не верный формат данных!");
            e.ThrowException = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!updateIndexRows.Contains(e.RowIndex))
                updateIndexRows.Add(e.RowIndex);
        }


        //-------Логика для контролов
        private async void CallingReadAndPasteOperation()
        {
            await Task.Run(() =>
            {
                string pathXML = string.Format(@"C:\Users\mit\source\repos\WinFormsXML\WinFormsXML\XML\Clients.xml");//Cards//Clients
                ReadXML readXML = new ReadXML(pathXML);
                var data = readXML.DeserializeXML();//читаем данные из XML

                CRUDDataBase crud = new CRUDDataBase();
                if (crud.InsertDataToDB(data) && data.Count > 0) //передаем данные на запись в БД
                    MessageBox.Show("Данные получены и сохранены в БД.");
                else
                    MessageBox.Show("Что-то пошло не так! Подробности в Логах.");
            });
        }

        private void SaveOperation()
        {
            bool resultUpd = false;
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                if (updateIndexRows.Contains(dataGridView1.Rows[row].Index))
                {
                    List<string> dataList = new();
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        if (dataGridView1[col, row].Value is null)
                            dataList.Add(string.Empty);
                        else
                            dataList.Add(dataGridView1[col, row].Value.ToString());
                        if (dataList[0] is null) //Проверка на наличие CARDCODE
                            break;
                    }
                    resultUpd = crud.UpdateData(dataList);
                }
            }
            updateIndexRows.Clear();
            if (resultUpd)
                MessageBox.Show("Данные сохранены.");
            else
                MessageBox.Show("Данные не сохранены. Подробности в Логах");
        }
    }
}
