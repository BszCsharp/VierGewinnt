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
   


        private void pictureBoxgelb_MouseDown(object sender, MouseEventArgs e)
        {
            //pictureBoxgelb.DoDragDrop("gelb",DragDropEffects.Move );
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move | DragDropEffects.Copy;
            }
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

            //String txt = ((Label)sender).Tag as String;
            labelGelb.DoDragDrop("GELB", DragDropEffects.Move);
        }

        private void labelGelb_DoubleClick(object sender, EventArgs e)
        {

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

        private void tableLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move | DragDropEffects.Copy;
            }
        }

        private void FormVierGewinnt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move | DragDropEffects.Copy;
            }
        }

        private void tableLayoutPanel1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move | DragDropEffects.Copy;
            }
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
  
            int r;
            Label l = sender as Label;
            int s = Convert.ToInt32(l.Text);
 
            s--;
            for (r = 0; r < 6 && picArray[r + 1, s].Image == imgw; r++)
            {
                ;
            }
            if (r != 0)
            {
                if (labelGelb.Visible) picArray[r, s].Image = imgg;
                else picArray[r, s].Image = imgr;
                check();
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
            }
           
            

        }
    }
}
