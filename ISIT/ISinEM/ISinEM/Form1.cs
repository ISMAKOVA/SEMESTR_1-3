using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISinEM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public static double [] IBZ = new double[4]; 

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] names = { "1.Конструктивные", "2.Эксплуатационные", "3.Технологические", "4.Стоимостные", "Итого" };
            foreach (string name in names)
            {
                dataGridView1.Rows.Add(name);
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(DataGridView1_KeyPress);
        }

        private void DataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                { e.Handled = true; }

            }
        }
        private void GetRandom()
        {
            Random rand = new Random();
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    int n = rand.Next(10);
                    if (i + 1 == j)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                    }
                    else
                    {
                        dataGridView1[i + 1, j - 1].Value = n.ToString();
                        dataGridView1[j, i].Value = (10 - n).ToString();
                    }
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            double[] sum = new double[4];
            double Xij = 0.0;
            double Vx;
            double TotalSum = 0;
            GetRandom();
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    sum[i] += Convert.ToInt32(dataGridView1[j, i].Value);
                    Xij += Convert.ToInt32(dataGridView1[j, i].Value);

                }

            }
            for (int i = 0; i <= 3; i++)
            {
                Vx = sum[i] / Xij;
                TotalSum += Vx;
                dataGridView1.Rows[i].Cells[5].Value = sum[i].ToString();
                dataGridView1.Rows[i].Cells[6].Value = Math.Round((Vx), 3).ToString();
                dataGridView1.Rows[4].Cells[5].Value = Xij.ToString();
                dataGridView1.Rows[4].Cells[6].Value = TotalSum.ToString();
                IBZ[i] = Math.Round((Vx), 3);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string[] names = { "1.Конструктивные", "2.Эксплуатационные", "3.Технологические", "4.Стоимостные", "Итого" };
            foreach (string name in names)
            {
                dataGridView1.Rows.Add(name);
            }
            for(int i = 0; i <= 3; i++)
            {
                IBZ[i] = 0;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            double Vx;
            double TotalSum = 0;
            double[] sum = new double[4];
            double Xij = 0.0;
            int[,] dgv = new int[5, 5];
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    dgv[j, i] = Convert.ToInt32(dataGridView1[j, i].Value);
                    sum[i] += dgv[j, i];
                    Xij += dgv[j, i];
                }
            }
            for (int i = 0; i <= 3; i++)
            {
                Vx = sum[i] / Xij;
                TotalSum += Vx;
                for (int j = 1; j <= 4; j++)
                {
                    if (i + 1 == j)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                    }
                    else if(dgv[i + 1, j - 1] + dgv[j, i] != 10)
                    {
                        dataGridView1[j, i].Style.BackColor = Color.PaleGoldenrod;
                        dataGridView1[i + 1, j - 1].Style.BackColor = Color.PaleGoldenrod;
                        dataGridView1.Rows[4].Cells[5].Value = "";
                        dataGridView1.Rows[4].Cells[6].Value = "";
                        for (int k = 0; k <= 3; k++)
                        {
                            IBZ[k] = 0;
                        }
                    }
                    else
                    {
                        dataGridView1[j, i].Style.BackColor = Color.White;
                        dataGridView1[i + 1, j - 1].Style.BackColor = Color.White;
                        dataGridView1.Rows[i].Cells[5].Value = sum[i].ToString();
                        dataGridView1.Rows[i].Cells[6].Value = Math.Round(Vx, 3).ToString();
                        dataGridView1.Rows[4].Cells[5].Value = Xij.ToString();
                        dataGridView1.Rows[4].Cells[6].Value = TotalSum.ToString();
                        IBZ[i] = Math.Round((Vx), 3);

                    }
                   
                }
            }
            if(dataGridView1.CurrentCell.Style.BackColor== Color.PaleGoldenrod)
            {
                for(int i = 0; i <= 3; i++)
                {
                    dataGridView1[6, i].Value = "";
                    dataGridView1.Rows[4].Cells[6].Value = "";
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (IBZ[0]==0)
            {
                MessageBox.Show("Заполните матрицу парных сравнений");
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }
    }
}
