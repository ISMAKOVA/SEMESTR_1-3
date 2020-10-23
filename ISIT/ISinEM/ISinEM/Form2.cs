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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string[] names = { "1.Конструктивные", "2.Эксплуатационные", "3.Технологические", "4.Стоимостные"," "};
            foreach (string name in names)
            {
                dataGridView1.Rows.Add(name);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string[] names = { "1.Конструктивные", "2.Эксплуатационные", "3.Технологические", "4.Стоимостные"," " };
            foreach (string name in names)
            {
                dataGridView1.Rows.Add(name);
            }
            for (int i = 0; i <= 3; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = Form1.IBZ[i].ToString();
                dataGridView1.Rows[i].Cells[5].Value = Form1.IBZ[i].ToString();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            double total1 = 0;
            double total2 = 0;
            for (int i = 0; i <= 3; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = Form1.IBZ[i].ToString();
                dataGridView1.Rows[i].Cells[5].Value = Form1.IBZ[i].ToString();
                if(Convert.ToDouble(dataGridView1[1, i].Value) > 10 )
                {
                    dataGridView1[1, i].Style.BackColor = Color.PaleGoldenrod;
                    dataGridView1[3, i].Value = dataGridView1[3, 4].Value = "";
                }
                else if(Convert.ToDouble(dataGridView1[4, i].Value) > 10 )
                {
                    dataGridView1[4, i].Style.BackColor = Color.PaleGoldenrod;
                    dataGridView1[6, i].Value = dataGridView1[6, 4].Value = "";
                }
                else
                {
                    dataGridView1[1, i].Style.BackColor = Color.White;
                    dataGridView1[4, i].Style.BackColor = Color.White;
                    dataGridView1[3, i].Value = (Convert.ToDouble(dataGridView1[1, i].Value) * Form1.IBZ[i]).ToString();
                    dataGridView1[6, i].Value = (Convert.ToDouble(dataGridView1[4, i].Value) * Form1.IBZ[i]).ToString();
                    total1 += Convert.ToDouble( dataGridView1[3, i].Value);
                    dataGridView1[3, 4].Value = total1.ToString();
                    total2 += Convert.ToDouble(dataGridView1[6, i].Value);
                    dataGridView1[6, 4].Value = total2.ToString();
                }
            }
            if (total1 > total2)
            {
                MessageBox.Show("Автоматизация данных функций оправдана");

            }
            else
            {
                MessageBox.Show("Автоматизация данных функций не оправдана");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            double total1=0;
            double total2 =0;
            for (int i = 0; i <= 3; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = Form1.IBZ[i].ToString();
                dataGridView1.Rows[i].Cells[5].Value = Form1.IBZ[i].ToString();
            }
            Random rand = new Random();
            for (int i = 0; i <= 3; i++)
            {
                int n = rand.Next(10);
                dataGridView1[3 , i].Value = (n* Form1.IBZ[i]).ToString();
                dataGridView1[1, i].Value = n.ToString();
                total1 += n * Form1.IBZ[i];
                dataGridView1[3, 4].Value = total1.ToString();
            }
            for (int i = 0; i <= 3; i++)
            {
                int n = rand.Next(10);
                dataGridView1[4, i].Value = n.ToString();
                dataGridView1[6, i].Value = (n * Form1.IBZ[i]).ToString();
                total2 += n * Form1.IBZ[i];
                dataGridView1[6, 4].Value = total2.ToString();
            }


        }
    }
}
