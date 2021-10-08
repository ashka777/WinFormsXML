using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsXML.Logic;

namespace WinFormsXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CRUDDataBase crud = new CRUDDataBase();

        //Получаем их XML и вставляем в БД
        private void btGet_Click(object sender, EventArgs e)
        {
            CallingReadAndPasteOperation();
        }

        //Заполняем грид
        private void btRead_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = crud.ReadData();
            dataGridView1.Columns["CARDCODE"].DisplayIndex = 0;
            dataGridView1.Columns["CARDCODE"].ReadOnly = true;
        }

        //Сохраняем изменения в БД 
        private void btSave_Click(object sender, EventArgs e)
        {
            SaveOperation();
        }

        private void CallingReadAndPasteOperation()
        {
            string pathXML = string.Format(@"C:\Users\mit\source\repos\WinFormsXML\WinFormsXML\XML\Clients.xml");
            ReadXML readXML = new ReadXML(pathXML);
            var data = readXML.GetDataFromXML();//читаем данные из XML

            CRUDDataBase crud = new CRUDDataBase();
            if (crud.InsertDataToDB(data)) //передаем данные на запись в БД
                MessageBox.Show("Данные получены и сохранены в БД.");
            else
                MessageBox.Show("Что-то пошло не так! Подробности в Логах.");
        }
        private void SaveOperation()
        {
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                List<object> dataList = new List<object>();
                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    dataList.Add(dataGridView1[col, row].Value);
                }
                if (dataList[0] is null) return; //Проверка на наличие CARDCODE
                if (crud.UpdateData(dataList))
                    MessageBox.Show("Данные сохранены.");
                else
                    MessageBox.Show("Что-то пошло не так! Данные не сохранены.");
            }
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
    }
}
