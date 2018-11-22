using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Library
{
    public partial class Ins_Book : Form
    {
        public Ins_Book()
        {
            InitializeComponent();
            FMain.SelfRef.conn2(FMain.SelfRef.ConnectionString, FMain.SelfRef.select_Ganre, comboBox2, "Название", "номер");
            FMain.SelfRef.conn2(FMain.SelfRef.ConnectionString, FMain.SelfRef.select_Author, comboBox3, "названиеАвтора", "номер");
        }

        private void Ins_Book_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn3 = new SqlConnection();
            conn3.ConnectionString = FMain.SelfRef.ConnectionString;
            //Теперь можно устанавливать соединение, вызывая метод Open объекта
            conn3.Open();
            //создаем новый экземпляр SQLCommand
            SqlCommand cmd = conn3.CreateCommand();
            //определяем тип SQLCommand=StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            //определяем имя вызываемой процедуры
            cmd.CommandText = "[Ins_Book]";
            //создаем параметр
            cmd.Parameters.Add("@NAME_B", SqlDbType.NVarChar, 150);
            //задаем значение параметра
            cmd.Parameters["@NAME_B"].Value = txtName.Text;
            //аналогично для всех параметров
            cmd.Parameters.Add("@SOURCE", SqlDbType.NVarChar, 70);
            cmd.Parameters["@SOURCE"].Value = comboBox1.Text;
            cmd.Parameters.Add("@DATE_P", SqlDbType.Date, 70);
            cmd.Parameters["@DATE_P"].Value = dateTimePicker1.Value;
            cmd.Parameters.Add("@COUNT", SqlDbType.Int, 4);
            cmd.Parameters["@COUNT"].Value = txtCount.Text;
            cmd.Parameters.Add("@PRICE", SqlDbType.Decimal, 5);
            cmd.Parameters["@PRICE"].Value = txtPrice.Text;
            cmd.Parameters.Add("@ID_GENRE", SqlDbType.Int, 4);
            cmd.Parameters["@ID_GENRE"].Value = comboBox2.SelectedValue;
            cmd.Parameters.Add("@ID_AUTHOR", SqlDbType.Int, 4);
            cmd.Parameters["@ID_AUTHOR"].Value = comboBox3.SelectedValue;
            cmd.Parameters.Add("@PUBLISHER", SqlDbType.NVarChar, 150);
            cmd.Parameters["@PUBLISHER"].Value = txtPub.Text;
            cmd.Parameters.Add("@NAMBER_PAGES", SqlDbType.Int, 4);
            cmd.Parameters["@NAMBER_PAGES"].Value = txtPageCount.Text;
            cmd.Parameters.Add("@YEAR_PUB", SqlDbType.Int, 4);
            cmd.Parameters["@YEAR_PUB"].Value = txtYear.Text;
            //возврат идентификатора добавленной записи
            cmd.Parameters.Add("@Id", SqlDbType.Int, 4);
            cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

            //Выполнение хранимой процедуры-добавление экземпляра
            cmd.ExecuteScalar();
            //присовение переменной значения ID
            int ID_Instance = Convert.ToInt32(cmd.Parameters["@id"].Value);

            MessageBox.Show("Изменения внесены. ID= " + ID_Instance.ToString(), "Добавление записей");
            //создание отдельных рег№ экземпляра в количестве, указанном в поле txtCount
            // выполнение хранимой процедуры InsDoc
            int Count_Doc = Convert.ToInt32(txtCount.Text);


            //k-количество добавленных документов
            int k = 0;
            for (int i = 0; i < Count_Doc; i++)
            {

                SqlCommand cmdd = conn3.CreateCommand();
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.CommandText = "[INS_DOC]";
                cmdd.Parameters.Add("@ID_Book", SqlDbType.Int, 4);
                cmdd.Parameters["@ID_Book"].Value = ID_Instance;
                cmdd.Parameters.Add("@Status", SqlDbType.Int, 4);
                cmdd.Parameters["@Status"].Value = "0";
                cmdd.ExecuteNonQuery();
                k++;
            }
            MessageBox.Show("Изменения внесены. Добавлено документов - " + k, "Добавление записей");

            //обновление списка книг в каталоге
            if (FMain.SelfRef != null)
            {
                FMain.SelfRef.conn(FMain.SelfRef.ConnectionString, FMain.SelfRef.select_book, FMain.SelfRef.dataGridView2);
            }

        }

    }
}

