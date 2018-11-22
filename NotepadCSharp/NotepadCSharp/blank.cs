using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotepadCSharp
{
    public partial class blank : Form
    {
        private string BufferText = "";
        public string DocName = "";
        public bool IsSaved = false;
        public void Cut()
        {
            this.BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
           
        }
        public void Save(string SaveFileName)
        {
           
            if (SaveFileName == "")
            {
                return;
            }
            else
            {
                
                StreamWriter sw = new StreamWriter(SaveFileName);             
                sw.WriteLine(richTextBox1.Text);            
                sw.Close();           
                DocName = SaveFileName;
            }
        }

        public void Copy()
        {
            this.BufferText = richTextBox1.SelectedText;
        }
        public void Paste()
        {
            richTextBox1.SelectedText = this.BufferText;
        }
        public void SelectAll()
        {
            richTextBox1.SelectAll();
        
        }
        public void Delete()
        {
            richTextBox1.SelectedText = "";
            this.BufferText = "";
        }
        public void Open(string OpenFileName)
        {
            
            if (OpenFileName == "")
            {
                return;
            }
            else
            {
                StreamReader sr = new StreamReader(OpenFileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                DocName = OpenFileName;
            }
        }



        public blank()
        {
            InitializeComponent();
           
            sdTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            
            sdTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());

        }

        private void blank_Load(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
           
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void blank_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSaved == false)
                
                if (MessageBox.Show("Вы желаете сохранить изменения в документе " + this.DocName + "?",
                "Message", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                
                {
                    this.Save(this.DocName);
                }



        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            sdAmount.Text = "Аmount of symbols" + richTextBox1.Text.Length.ToString();

        }

        private void sdAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
