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
            
            int s = 0;
            int r;
            
   
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
            Label l = (Label)sender;
            l.BackColor = Color.LightYellow;
            e.Effect = DragDropEffects.All;
        }

        private void checkGame(int r,int s)
        {
            Boolean gewonnen = false;
           
           if(checkH(r) )  // Horizontal
           {
               gewonnen = true;
           }
            if(gewonnen == false && checkV() == true) // Vertikal
            {
                gewonnen = true;
            }
            if(gewonnen == false && checkD(r,s) == true) // Diagonal
            {
                gewonnen = true;
            }
            if(gewonnen)
            {
               String Farbe = "Rot";
               if(labelGelb.Visible) Farbe = "Gelb";
               label8.Text = Farbe + " hat gewonnen";
               labelGelb.Visible = false;
               labelRot.Visible = false;
            }

        }

        private bool checkD(int row,int col)
        {
            Image img = null;
            int anzahl = 0;
            // teil 1 von links nach rechts
            int r = 0, s = 0;
            if (labelGelb.Visible) img = imgg;
            else img = imgr;
            Boolean gewonnen = false;
            // nach links unten
            anzahl = 1;
            for(r = row+1,s = col -1; r <= 6 && s >= 0 && gewonnen == false; r++,s--)
            {
                if (picArray[r, s].Image == img) anzahl++;
                if (anzahl == 4) gewonnen = true;
            }
            // nach links oben
            if(gewonnen == false)
            {
                anzahl = 1;
                for (r = row - 1, s = col - 1; r >= 1 && s >= 0 && gewonnen == false; r--, s--)
                {
                    if (picArray[r, s].Image == img) anzahl++;
                    if (anzahl == 4) gewonnen = true;
                } 

            }
            // nach rechts unten
            if (gewonnen == false)
            {
                anzahl = 1;
                for (r = row + 1, s = col + 1; r <= 6 && s <= 6 && gewonnen == false; r++, s++)
                {
                    if (picArray[r, s].Image == img) anzahl++;
                    if (anzahl == 4) gewonnen = true;
                }
            }
            // nach rechts oben
            if (gewonnen == false)
            {
                anzahl = 1;
                for (r = row - 1, s = col + 1; r >= 1 && s <= 6 && gewonnen == false; r--, s++)
                {
                    if (picArray[r, s].Image == img) anzahl++;
                    if (anzahl == 4) gewonnen = true;
                }
            }

            return gewonnen;
        }

        private bool checkV()
        {
            int r, s;
            Boolean gewonnen = false;
            // modus  gelb =1, rot = 2;
            modusEnum modus = modusEnum.weiss;
            int anzahl = 0;

            for (s = 0; s <= 6 && gewonnen == false; s++)
            {
                modus = modusEnum.weiss;
                for (r = 6; r >= 1; r--)
                {
                    if (picArray[r, s].Image == imgg)
                    {
                        switch (modus)
                        {
                            case modusEnum.weiss:
                            case modusEnum.rot:
                                modus = modusEnum.gelb;
                                anzahl = 1;
                                break;
                            case modusEnum.gelb:
                                anzahl++;
                                break;
                        }
                    }
                    else if (picArray[r, s].Image == imgr)
                    {
                        switch (modus)
                        {
                            case modusEnum.weiss:
                            case modusEnum.gelb:
                                modus = modusEnum.rot;
                                anzahl = 1;
                                break;
                            case modusEnum.rot:
                                anzahl++;
                                break;
                        }
                    }
                    if (anzahl == 4)
                    {
                        gewonnen = true;
                        break;
                    }
                }

            }
            return gewonnen;
        }

        private bool checkH(int row)
        {
            int r, s;
            Boolean gewonnen = false;
            // modus  gelb =1, rot = 2;
            modusEnum modus = modusEnum.weiss;
            int anzahl = 0;

            for (r = 6; r >= 1 && gewonnen == false; r--)
            {
                modus = modusEnum.weiss;
                for (s = 0; s <= 6; s++)
                {
                    if (picArray[r, s].Image == imgg )
                    {
                        switch (modus)
                        {
                            case modusEnum.weiss:
                            case modusEnum.rot:
                                modus = modusEnum.gelb;
                                anzahl = 1;
                                break;
                            case modusEnum.gelb:
                                anzahl++;
                                break;
                        }
                    }
                    else if(picArray[r, s].Image == imgr)
                    {
                        switch(modus)
                        {
                            case modusEnum.weiss:
                            case modusEnum.gelb:
                               modus = modusEnum.rot;
                               anzahl = 1;
                               break;
                            case modusEnum.rot:
                               anzahl++;
                               break;
                        }
                     }
                    if (anzahl == 4)
                    {
                        gewonnen = true;
                        break;
                    }
                }

            }
            return gewonnen;
        }

        private void labelGelb_MouseDown(object sender, MouseEventArgs e)
        {
            labelGelb.DoDragDrop("GELB", DragDropEffects.Move);
        }

        private void labelRot_MouseDown(object sender, MouseEventArgs e)
        {
            labelRot.DoDragDrop("ROT", DragDropEffects.Move);
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            int r;
            Label l = sender as Label;
            l.BackColor = Color.Olive;
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
                Application.DoEvents();
                checkGame(r,s);
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

     

        private void label1_DragLeave(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            l.BackColor = Color.Olive;
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            int r, s;
            for (r = 1; r < 7; r++)
                for (s = 0; s < 7; s++)
                {
                    picArray[r, s].Image = imgw;
                }
            label8.Text = "";
            labelGelb.Visible = true;
            labelRot.Visible = false;

        }

 
    }
    enum modusEnum {  weiss = 0, gelb = 1, rot = 2}
}
