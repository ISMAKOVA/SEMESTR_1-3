using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "3";
            textBox2.Text = "33";
            textBox3.Text = "5";
            textBox4.Text = "8";

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!double.TryParse(textBox2.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!double.TryParse(textBox2.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!double.TryParse(textBox2.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!double.TryParse(textBox2.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        public double PuassonNum(int n,double count_people, double in_hour)
        {
            double a = count_people*in_hour;
            double[] y = new double[n];
            double[] x = new double[n];
            Random rnd = new Random();
            double p = a / n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    x[j] = rnd.NextDouble();
                }
                for (int k = 0; k < n; k++)
                {
                    if (x[k] < p)
                    {
                        y[i]++;
                    }
                }
            }
            //для проверки является ли распр. пуссона
            for (int i = 1; i < n; i++)
            {
              //  chart1.Series[0].Points.AddXY(y[i - 1], y[i]);
            }
            return y[rnd.Next(1,n)];
        }
        public double ExponentialNum(int n, double lambda)
        {
            double[] y = new double[n + 1];
            double num = -1 / lambda;
            double[] u = new double[n + 1];
            Random rnd = new Random();
            for (int i = 1; i <= n; i++)
            {
                u[i] = rnd.NextDouble();
            }
            for (int i = 1; i <= n; i++)
            {
                y[i] = Convert.ToDouble(num * Math.Log(u[i]));
            }
            //для проверки является ли показат. распр.
            for (int i = 1; i < n; i++)
            {
             //   chart1.Series[0].Points.AddXY(y[i - 1], y[i]);
            }
            return y[rnd.Next(1, n)];
        }


            private void Button1_Click(object sender, EventArgs e)
            {
            double n = Convert.ToDouble(textBox1.Text);
            double lambda = Convert.ToDouble(textBox2.Text)/60;
            double tao = Convert.ToDouble(textBox3.Text);
            Queue<double> queue = new Queue<double>();
            var client = new List<(int i, double t_coming, double t_leaving, bool serve)>(); //номер клиента / время прихода / время ухода / обслужен?да:нет
            double t_coming = 0.0;
            double t_leaving = 0.0;
            double t_service = 0.0;
            Random rnd = new Random();
            int i = 0;
            double t_cur = 0;
            int k = 3;
            while (t_leaving< 480)
            {
                i++;
                double x = PuassonNum(500, lambda, 1);
                t_coming = t_cur + x;
                if (k> 0)
                {
                    k--;
                    t_service = ExponentialNum(500, 1 / tao);
                    t_leaving = t_cur + t_service;
                    client.Add((i,t_cur ,t_leaving,true));
                    t_cur = t_coming;
                }
                else
                {
                    queue.Enqueue(t_coming);
                    double first_leave = Math.Min(Math.Min(client[client.Count-3].t_leaving, client[client.Count - 1].t_leaving), client[client.Count - 2].t_leaving);
                  //  t_coming = first_leave;
                    t_leaving = first_leave + ExponentialNum(500, 1 / tao);
                    client.Add((i, t_cur, t_leaving, true));
                    t_cur = t_coming;
                    k++;

                }

            }
            foreach (var item in client)
            {
                dataGridView1.Rows.Add(item.i, String.Format("{0}",item.t_coming), String.Format("{0:F3}", item.t_leaving));
            }
        }
    }
}
