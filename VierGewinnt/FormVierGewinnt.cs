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
                    

               }
           }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
