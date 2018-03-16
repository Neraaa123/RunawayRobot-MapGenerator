using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunawayBot_MapGenerator
{
    public partial class Form1 : Form
    {
        public static int rows ;
        public static int colums;
        public PictureBox[,] pb = new PictureBox[rows, colums];

        public Form1()
        {
            InitializeComponent();
            panel2.Width = Screen.PrimaryScreen.Bounds.Width;
            panel2.Height = Screen.PrimaryScreen.Bounds.Height;
        }

        public void displayMap()
        {
            int posX = 0, posY = 0;
            for (int i = 0; i < rows; i++)
            {
                posY = 0;
                for (int j = 0; j < colums; j++)
                {
                    pb[i, j] = new PictureBox();
                    pb[i, j].Size = new Size(50, 50);
                    pb[i, j].Location = new Point(posX, posY);
                    pb[i, j].Image = Image.FromFile(@"c:\users\lled\documents\visual studio 2017\Projects\RunawayBot MapGenerator\RunawayBot MapGenerator\field.png");
                    pb[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    pb[i, j].Tag = "okay";
                    pb[i,j].MouseClick += new MouseEventHandler(field_click);
                    panel2.Controls.Add(pb[i, j]);

                    posY += 51;
                }
                posX += 51;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displayMap();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void field_click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (p.Tag.Equals("okay"))
            {
                p.Image = Image.FromFile(@"C:\Users\LLED\Documents\Visual Studio 2017\Projects\RunawayBot MapGenerator\RunawayBot MapGenerator\boom.png");
                p.Tag = "boom";
            }
            else
            {
                p.Image = Image.FromFile(@"c:\users\lled\documents\visual studio 2017\Projects\RunawayBot MapGenerator\RunawayBot MapGenerator\field.png");
                p.Tag = "okay";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Array.Clear(pb, 0, pb.Length);
            rows = int.Parse(textBox1.Text);
            colums = int.Parse(textBox2.Text);
            pb = new PictureBox[rows, colums];
            displayMap();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<rows;i++)
            {
                Debug.Write("{");
                for(int j=0;j<colums;j++)
                {
                    if(i==rows-1)
                    {
                        if (j == colums - 1)
                        {
                            Debug.Write("0");
                        }
                        else
                        {
                            Debug.Write("0, ");
                        }
                    }
                    else
                    {
                        if (j == colums - 1)
                        {
                            Debug.Write("0");
                        }
                        else
                        {
                            if (pb[j, i].Tag.Equals("okay")) Debug.Write("0, ");
                            else Debug.Write("1, ");
                        }
                    }
                    
                }
                if(i==rows-1)
                {
                    Debug.Write("}");
                }
                else
                {
                    Debug.WriteLine("},");
                }
            }
        }
    }
}
