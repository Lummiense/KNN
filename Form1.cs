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
            double[] V1Metric = new double[50];
            double[] V2Metric = new double[50];
            double[] V3Metric = new double[50];
            double[] V4Metric = new double[50];
            double[] ResultMetric = new double[200];
            for (int i = 0; i < 30; i++) //идём по всем МЭ
            { 
                
               for (int j=0;j<50;j++) //идём по всем образам
               {
                    V1Metric[j] = Math.Sqrt(Math.Pow(Exam[0, i] - View1[0, j],2) + Math.Pow(Exam[1, i] - View1[1, j], 2));
                    V2Metric[j] = Math.Sqrt(Math.Pow(Exam[0, i] - View2[0, j],2) + Math.Pow(Exam[1, i] - View2[1, j], 2));
                    V3Metric[j] = Math.Sqrt(Math.Pow(Exam[0, i] - View3[0, j],2) + Math.Pow(Exam[1, i] - View3[1, j], 2));
                    V4Metric[j] = Math.Sqrt(Math.Pow(Exam[0, i] - View4[0, j],2) + Math.Pow(Exam[1, i] - View4[1, j], 2));
                    
               }

               ResultMetric = V1Metric.Concat(V2Metric).Concat(V3Metric).Concat(V4Metric).ToArray();
               Array.Sort(ResultMetric);
               for (int k = 0; k < NeighborsCount; k++)
            {
                
            }
               
            }
            

            
        }
    }
}
