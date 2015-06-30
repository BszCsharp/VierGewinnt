using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VierGewinnt
{
    public partial class FormVierGewinnt : Form
    {
        private PictureBox[,] picArray = new PictureBox[7,7];
        public FormVierGewinnt()
        {
            InitializeComponent();
            InitializArray();

        }

        private void InitializArray()
        {
            //tableLayoutPanel1.SetColumn(pictureBox1, 0);
            //tableLayoutPanel1.SetRow(pictureBox1, 1);
            int z = 1;
            int s = 0;
            int r, c;
           foreach(Control co in tableLayoutPanel1.Controls)
           {
               if(co.Name.Contains("pic"))
               {
                    PictureBox p = (PictureBox)co;
                    p.BackColor = Color.Blue;
                    z++;
                    s++;
                    r = z % 6 + 1;
                    c = s % 7;
                    picArray[r, c] = p;
                    p.Tag = 0;
                    

               }
           }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void oleDbDataAdapter1_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
        {

        }

        private void pictureBoxgelb_MouseDown(object sender, MouseEventArgs e)
        {
            //pictureBoxgelb.DoDragDrop("gelb",DragDropEffects.Move );
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
        
        }

        private void labelGelb_MouseDown(object sender, MouseEventArgs e)
        {
            labelGelb.DoDragDrop(labelGelb.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelGelb_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            int s = Convert.ToInt32(l.Text) - 1;
            int r;
            for(r = 1; r < 7; r++)
            {
                if( (Int32) picArray[r,s].Tag != 0)
                {
                    r--;
                    if(r>=1)
                    {

                    }
                    break;
                }
            }
            

        }
    }
}
