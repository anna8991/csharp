using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadCSharp
{
    public partial class frmmain : Form
    {
        private int openDocuments = 0;
        public frmmain()
        {
            InitializeComponent();
        }
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
             blank frm = new blank();

            frm.DocName = "Untitled" + ++openDocuments;
            frm.Text = frm.DocName;
            frm.MdiParent = this;
            frm.Show();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuWindow_Click(object sender, EventArgs e)
        {
            
 
        }

        private void mnuArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout. ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            blank frm =(blank) this.ActiveMdiChild;
            frm.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Paste();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Delete();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.SelectAll();

        }
        

        private void mnuOpen_Click_1(object sender, EventArgs e)
        {
            if ( openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                blank frm = new blank();
                frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = openFileDialog1.FileName;
                frm.Text = frm.DocName;
                frm.Show();
            }

        }
        private void mnuSave_Click(object sender, System.EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                blank frm = (blank)this.ActiveMdiChild;
                
                frm.Save(saveFileDialog1.FileName);
               
                frm.MdiParent = this;
                
                frm.DocName = saveFileDialog1.FileName;
                
                frm.Text = frm.DocName;
                frm.IsSaved = true;


            }

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            //Переключаем фокус на данную форму.
            blank frm = (blank)this.ActiveMdiChild;
            //Указываем, что родительской формой является форма frmmain  
            frm.MdiParent = this;
            //Вызываемдиалог
            fontDialog1.ShowColor = true;
            //Связываемсвойства SelectionFont и SelectionColor элемента RichTextBox 
            //ссоответствующимисвойствамидиалога
            fontDialog1.Font = frm.richTextBox1.SelectionFont;
            fontDialog1.Color = frm.richTextBox1.SelectionColor;
            //Если выбран диалог открытия файла, выполняем условие
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionFont = fontDialog1.Font;
                frm.richTextBox1.SelectionColor = fontDialog1.Color;
            }
            //Показываем форму
            frm.Show();

        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            colorDialog1.Color = frm.richTextBox1.SelectionColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionColor = colorDialog1.Color;
            }

            frm.Show();

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuFind_Click(object sender, EventArgs e)
        {
            
            FindForm frm = new FindForm();
            
            if (frm.ShowDialog(this) == DialogResult.Cancel) return;
            
            blank form = (blank)this.ActiveMdiChild;
             
            form.MdiParent = this;
            
            int start = form.richTextBox1.SelectionStart;
           
            form.richTextBox1.Find(frm.FindText, start, frm.FindCondition);

        }
        private void mnuAbout_Click(object sender, System.EventArgs e)
        {
            
            About frm = new About();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuAbout_Click_1(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();

        }

        private void toolBarMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            newToolStripMenuItem_Click(this, new EventArgs());
        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            mnuOpen_Click_1(this, new EventArgs());
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            mnuSave_Click(this, new EventArgs());
        }

        private void tbCut_Click(object sender, EventArgs e)
        {
            mnuCut_Click(this, new EventArgs());
           
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            mnuCopy_Click(this, new EventArgs());
        }

        private void tbPaste_Click(object sender, EventArgs e)
        {
            mnuPaste_Click(this, new EventArgs());
        }
    }
}
