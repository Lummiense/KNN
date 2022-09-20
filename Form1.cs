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
        public double[,] View1 = new double[2, 50];
        /// <summary>
        /// Образ 2.
        /// </summary>
        public double[,] View2 = new double[2, 50];
        /// <summary>
        /// Образ 3.
        /// </summary>
        public double[,] View3 = new double[2, 50];
        /// <summary>
        /// Образ 4.
        /// </summary>
        public double[,] View4 = new double[2, 50];
        /// <summary>
        /// Материалы экзамена.
        /// </summary>
        public double[,] Exam = new double[2, 30];
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
            NeighborsCount = uint.Parse(textBox1.Text);
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
                int k = 0;
               for (int j=0;j<50;j++) //идём по всем образам
                {
                    
                    Metric[k] = Math.Sqrt(Math.Pow(Exam[0, i] - View1[0, j],2) + Math.Pow(Exam[1, i] - View1[1, j], 2));
                    Views[k] = "Образ 1";
                    k++;
                    Metric[k] = Math.Sqrt(Math.Pow(Exam[0, i] - View2[0, j],2) + Math.Pow(Exam[1, i] - View2[1, j], 2));
                    Views[k] = "Образ 2";
                    k++;
                    Metric[k] = Math.Sqrt(Math.Pow(Exam[0, i] - View3[0, j],2) + Math.Pow(Exam[1, i] - View3[1, j], 2));
                    Views[k] = "Образ 3";
                    k++;
                    Metric[k] = Math.Sqrt(Math.Pow(Exam[0, i] - View4[0, j],2) + Math.Pow(Exam[1, i] - View4[1, j], 2));
                    Views[k] = "Образ 4";
                    k++;
                }
            }

            /*for (k = 0; k < Metric.Length; k++)
            {
                
            }*/
        }
    }
}
