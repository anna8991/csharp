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


namespace Library
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox1.Text == "123")
                {
                    FMain frm = new FMain();
                    frm.Text = "Library 1.0. Добро пожаловать в систему.";
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Для пользователя" + comboBox1 + "пароль не верный!");
                }
        }
        }
    }
}
