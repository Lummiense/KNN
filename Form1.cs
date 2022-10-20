using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
        int min;
        int max;

        public string ResultString;
        Chart chart = new Chart();


        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            int[] minRnd = new int[4];
            int[] maxRnd = new int[4];

            

            while (!int.TryParse(textBox7.Text, out minRnd[0]))
            {
                label14.Text = "Вы вводите некорректные данные минимального значения из диапазона образа 1";
                return;
            }
            while (!int.TryParse(textBox8.Text, out maxRnd[0]))
            {
                label14.Text = "Вы вводите некорректные данные максимального значения из диапазона образа 1";
                return;
            }
            while (!int.TryParse(textBox9.Text, out minRnd[1]))
            {
                label14.Text = "Вы вводите некорректные данные минимального значения из диапазона образа 2";
                return;
            }
            while (!int.TryParse(textBox10.Text, out maxRnd[1]))
            {
                label14.Text = "Вы вводите некорректные данные максимального значения из диапазона образа 2";
                return;
            }
            while (!int.TryParse(textBox11.Text, out minRnd[2]))
            {
                label14.Text = "Вы вводите некорректные данные минимального значения из диапазона образа 3";
                return;
            }
            while (!int.TryParse(textBox12.Text, out maxRnd[2]))
            {
                label14.Text = "Вы вводите некорректные данные максимального значения из диапазона образа 3";
                return;
            }
            while (!int.TryParse(textBox13.Text, out minRnd[3]))
            {
                label14.Text = "Вы вводите некорректные данные минимального значения из диапазона образа 4";
                return;
            }
            while (!int.TryParse(textBox14.Text, out maxRnd[3]))
            {
                label14.Text = "Вы вводите некорректные данные максимального значения из диапазона образа 4";
                return;
            }

            
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    View1[i, j] = rnd.Next(minRnd[0], maxRnd[0]);
                    View2[i, j] = rnd.Next(minRnd[1], maxRnd[1]);
                    View3[i, j] = rnd.Next(minRnd[2], maxRnd[2]);
                    View4[i, j] = rnd.Next(minRnd[3], maxRnd[3]);                    
                }
            }
            min = minRnd.Min();
            max = maxRnd.Max();
            for (int i=0;i<2;i++)
            {
                for (int j=0;j<50;j++)
                {
                    textBox2.Text += $"{View1[0, j]}       {View1[1, j]}\n";
                    textBox3.Text += $"{View2[0, j]}       {View2[1, j]}\n";
                    textBox4.Text += $"{View3[0, j]}       {View3[1, j]}\n";
                    textBox5.Text += $"{View4[0, j]}       {View4[1, j]}\n";                   
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            while (!uint.TryParse(textBox1.Text,out  NeighborsCount))
            {
                textBox1.Text = "Вы вводите некорректные данные";
                return;
            }
            textBox6.Text = "";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Exam[i, j] = rnd.Next(min, max);                    
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
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            double[] V1Metric = new double[50];
            double[] V2Metric = new double[50];
            double[] V3Metric = new double[50];
            double[] V4Metric = new double[50];
            double[] ResultMetric = new double[200];
            double[] VSum = new double[4];
            
            ResultString = null;

            
            for (int i = 0; i < 30; i++) //идём по всем МЭ
            {
                Array.Clear(VSum,0,4);
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
                for (int m = 0; m < 20; m++)
                {
                    if (Array.Exists(V1Metric, element => element == ResultMetric[m]))
                    {
                        VSum[0] += ResultMetric[m];
                    }
                    else if (Array.Exists(V2Metric, element => element == ResultMetric[m]))
                    {
                        VSum[1] += ResultMetric[m];
                    }
                    else if (Array.Exists(V3Metric, element => element == ResultMetric[m]))
                    {
                        VSum[2] += ResultMetric[m];
                    }
                    else
                    {
                        VSum[3] += ResultMetric[m];
                    }

                }
            }


               if (Array.IndexOf(VSum, VSum.Max()) == 0)
               {
                   ResultString += $"Точка {i+1} принадлежит образу 1\n";
               }
               else if(Array.IndexOf(VSum, VSum.Max()) == 1)
               {
                   ResultString += $"Точка {i+1} принадлежит образу 2\n";
               }
               else if (Array.IndexOf(VSum, VSum.Max()) == 2)
               {
                   ResultString += $"Точка {i+1} принадлежит образу 3\n";
               }
               else if (Array.IndexOf(VSum, VSum.Max()) == 3)
               {
                   ResultString += $"Точка {i+1} принадлежит образу 4\n";
               }
               
            }

            label18.Text = ResultString;
            
            
            chart.Parent = pictureBox1;            
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea("Распознавание образов"));

            

            Series view1points = new Series("Образ 1");
            view1points.ChartType = SeriesChartType.Point;
            view1points.ChartArea = "Распознавание образов";
            
            Series view2points = new Series("Образ 2");
            view2points.ChartType = SeriesChartType.Point;
            view2points.ChartArea = "Распознавание образов";

            Series view3points = new Series("Образ 3");
            view3points.ChartType = SeriesChartType.Point;
            view3points.ChartArea = "Распознавание образов";

            Series view4points = new Series("Образ 4");
            view4points.ChartType = SeriesChartType.Point;
            view4points.ChartArea = "Распознавание образов";

            Series exampoints = new Series("МЭ");
            exampoints.ChartType = SeriesChartType.Point;
            exampoints.ChartArea = "Распознавание образов";
            
            int y = 0;
            for (int i = 0; i < 50; i++)
            {
                view1points.Points.AddXY((int)View1[0, y], (int)View1[1, y]);
                view2points.Points.AddXY((int)View2[0, y], (int)View2[1, y]);
                view3points.Points.AddXY((int)View3[0, y], (int)View3[1, y]);
                view4points.Points.AddXY((int)View4[0, y], (int)View4[1, y]);
                
                y++;
            }
            y = 0;
            for (int i=0;i<30;i++)
            {
                exampoints.Points.AddXY((int)Exam[0, y], (int)Exam[1, y]);
                y++;
            }
            chart.Series.Add(view1points);
            chart.Series.Add(view2points);
            chart.Series.Add(view3points);
            chart.Series.Add(view4points);
            chart.Series.Add(exampoints);
            

        }
        
             
    }
}
