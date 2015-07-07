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
        Image imgw = Image.FromFile(@"Images\weiss.png"); // weiss
        Image imgr = Image.FromFile(@"Images\rot.png");   // rot
        Image imgg = Image.FromFile(@"Images\gelb.png"); // gelb 
        public FormVierGewinnt()
        {
            InitializeComponent();
            InitializeArray();

        }

        private void InitializeArray()
        {
            //tableLayoutPanel1.SetColumn(pictureBox1, 0);
            //tableLayoutPanel1.SetRow(pictureBox1, 1);
            int z = 1;
            int s = 0;
            int r, c;
            
           //foreach(Control co in tableLayoutPanel1.Controls)
           //{
           //    if(co.Name.Contains("pic"))
           //    {
           //         PictureBox p = (PictureBox)co;
           //         //p.BackColor = Color.Blue;
           //         p.Image = imgw;
           //         z++;
           //         s++;
           //         r = z % 6 + 1;
           //         c = s % 7;
           //         picArray[r, c] = p;
           //         p.Tag = 0;
                    

           //    }
           //}
            for (r = 1; r < 7;r++ )
                for (s = 0; s < 7; s++)
                {
                    PictureBox p = new PictureBox();
                    p.Image = imgw;
                    tableLayoutPanel1.Controls.Add(p);
                    tableLayoutPanel1.SetRow(p, r);
                    picArray[r, s] = p;
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
            int r;
            Label l = sender as Label;
            int s = Convert.ToInt32(l.Text);
            //if ( MessageBox.Show("Spalte " + s.ToString(),"Achtung",MessageBoxButtons.OK) != DialogResult.OK)
            //{
            //    return;
            //}
            s--;
            for(r = 0;  r< 6 && picArray[r+1,s].Image == imgw; r++)
            {
                ;
            }
            if(r != 0)
            {
                if (labelGelb.Visible) picArray[r, s].Image = imgg;
                else picArray[r, s].Image = imgr;
            }
            if (labelGelb.Visible)
            {
                labelGelb.Visible = false;
                labelRot.Visible = true;
            }
            else 
            {
                labelGelb.Visible = true;
                labelRot.Visible = false;
            }
            check();
        }

        private void check()
        {
           if(checkH)  // Horizontal
           {

           }
            if(checkV) // Vertikal
            {

            }
            if(checkD) // Diagonal
            {

            }
        }

        private void labelGelb_MouseDown(object sender, MouseEventArgs e)
        {
            labelGelb.DoDragDrop("GELB", DragDropEffects.Move);
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
                        //picArray[r,s].Image = 
                    }
                    break;
                }
            }
            

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void labelRot_MouseDown(object sender, MouseEventArgs e)
        {
            labelRot.DoDragDrop("ROT", DragDropEffects.Move);
        }

        public bool checkH { get; set; }

        public bool checkV { get; set; }

        public bool checkD { get; set; }
    }
}
