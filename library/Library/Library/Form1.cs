using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;


namespace Library
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            //Создание конфиг. менеджера для работы с настройками подключения
            SqlConnectionStringBuilder csBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);
            //имя сервера
            string ServerName = csBuilder.DataSource;
            //имя базы данных
            string DBName = csBuilder.InitialCatalog;
            //строка подключения
            ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DBName + ";Integrated Security=True";
         
            conn(ConnectionString, select_Ganre, dataGridView1);
            conn(ConnectionString, select_book, dataGridView2);
            conn(ConnectionString, select_Reader, dataGridView3);
            conn2(ConnectionString, select_Ganre, comboBox2, "Название", "номер");
            conn2(ConnectionString, select_Author, comboBox3, "названиеАвтора", "номер");
            SelfRef = this;
            
        }
        public static FMain SelfRef
        {
            get; set;
        }


        public string ConnectionString;
        public string select_Ganre = "SELECT  ID_Genre AS номер, Name_G AS Название FROM Genre ";
        public string select_Author = "SELECT ID_Author AS номер, Name_A AS названиеАвтора FROM Author";
       
        public string select_book = "SELECT     Author.Name_A AS втор, Genre.Name_G AS жанр, Book.ID_Book AS [номер книги], Book.Name_B AS название, Book.Source AS источник, Book.Date_P AS дата, Book.Count AS [кол-во]," +
                " Book.Price AS цена, Book.ID_Genre AS[номер жанра], Book.ID_Author AS[номер автора], Book.Publisher AS издательство, Book.Number_of_Pages AS[кол - во стр.]," +
                   " Book.[Year_of_ Pub] AS[год издания] FROM         Author INNER JOIN" +
                     " Book ON Author.ID_Author = Book.ID_Author INNER JOIN " +
                    " Genre ON Book.ID_Genre = Genre.ID_Genre";
        public string select_Reader = "SELECT     ID_Reader AS [ID читателя], Name_R AS ФИО, Date_B AS [Дата рождения], Adres AS Адрес, Tel AS Телефон, Date_R AS [Дата регистрации] FROM Reader ";


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FMain_Load(object sender, EventArgs e)
        {
            lblDate.Text = "Сегодня" + DateTime.Now.ToShortDateString();
            lblTime.Text = "Время мск" + DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Время мск" + DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void conn(string CS, string cmdT, DataGridView dgv)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter(cmdT, CS);
            DataSet ds = new DataSet();
            Adapter.Fill(ds, "Table");
            dgv.DataSource = ds.Tables["Table"].DefaultView;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) 
            {
                conn(ConnectionString, select_Author, dataGridView1);
            }
            if ( comboBox1.SelectedIndex==1)
                {
                conn(ConnectionString, select_Author, dataGridView1);
            }
        }
        public void conn2(string CS, string cmdT, ComboBox CB, string field1, string field2)
        {
            //создание экземпляра адаптера
            SqlDataAdapter Adapter = new SqlDataAdapter(cmdT, CS);
            //создание объекта DataSet (набор данных)
            DataSet ds = new DataSet();
            Adapter.Fill(ds, "Table");
            // привязка ComboBox к таблице БД
            CB.DataSource = ds.Tables["Table"];

            CB.DisplayMember = field1; //установка отображаемого в списке поля
            CB.ValueMember = field2; //установка ключевого поля

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query_g = "";
            if (Convert.ToString(comboBox2.SelectedValue) != "System.Data.DataRowView")
            {
                query_g = select_book + " AND Genre.ID_Genre= " + Convert.ToString(comboBox2.SelectedValue);
            }
            else query_g = select_book;
            conn(ConnectionString, query_g, dataGridView2);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query_g = "";
            if (Convert.ToString(comboBox3.SelectedValue) != "System.Data.DataRowView")
            {
                query_g = select_book + " AND Genre.ID_Genre= " + Convert.ToString(comboBox3.SelectedValue);
            }
            else query_g = select_book;
            conn(ConnectionString, query_g, dataGridView2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //создание экземпляра формы Ins_Book
            Ins_Book FIns_I = new Ins_Book();
            //открываем форму как модальную
            FIns_I.ShowDialog();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query_r = select_Reader;
            if (txtSearch.Text != "")
            {
                query_r = select_Reader + "WHERE Name_R like" + "'" + txtSearch.Text + "%" + "'";
            }
            else
            {
                query_r = select_Reader;
            }
            conn(ConnectionString, query_r, dataGridView3);

        }
    }
}
