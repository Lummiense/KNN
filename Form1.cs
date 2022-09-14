using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Образ 1.
        /// </summary>
        /// <param name="view1"></param>
        public int[,] View1 = new int[2, 50];
        /// <summary>
        /// Образ 2.
        /// </summary>
        public int[,] View2 = new int[2, 50];
        /// <summary>
        /// Образ 3.
        /// </summary>
        public int[,] View3 = new int[2, 50];
        /// <summary>
        /// Образ 4.
        /// </summary>
        public int[,] View4 = new int[2, 50];
        /// <summary>
        /// Материалы экзамена.
        /// </summary>
        public int[,] Exam = new int[2, 30];
        /// <summary>
        /// К-соседей
        /// </summary>
        uint NeighborsCount;

        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            
            NeighborsCount = uint.Parse(textBox1.Text);
            
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    View1[i, j] = rnd.Next(70, 95);
                    View2[i, j] = rnd.Next(20, 45);
                    View3[i, j] = rnd.Next(40, 65);
                    View4[i, j] = rnd.Next(60, 85);                    
                }
            }
            for (int i=0;i<2;i++)
            {
                for (int j=0;j<50;j++)
                {
                    textBox2.Text+= $"{View1[0, j]}       {View1[1, j]}\n";
                    textBox3.Text += $"{View2[0, j]}       {View2[1, j]} \n";
                    textBox4.Text += $"{View3[0, j]}       {View3[1, j]} \n";
                    textBox5.Text += $"{View4[0, j]}       {View4[1, j]} \n";                   
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Exam[i, j] = rnd.Next(20, 75);                    
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    textBox6.Text += $"{Exam[0, j]}       {Exam[1, j]}\n";                   
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] Metric = new double[200];
            string[] Views = new string[200];
            
            for (int i = 0; i < 30; i++) //идём по всем МЭ
            {
               for (int j=0;j<50;j++) //идём по всем образам
                {
                    int k = 0;
                    Metric[k] = Math.Sqrt((Exam[0, i] - View1[0, j]) ^ 2 + (Exam[1, i] - View1[1, j]) ^ 2);
                }
            }
        }
    }
}
