using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISinEM_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int numRows=0;
        public static double [] totalSum = new double[0];
        public static int systemValue=0;
        double allDays = 0;
        double oneDayValue=0.0;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numRows = (int)numericUpDown1.Value;
            dataGridView1.RowCount = numRows+1;
            for (int i = 0; i <= numRows; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = "Элемент";
            }
            dataGridView1[0, numRows].Value = "Итого";
            dataGridView1.Rows[numRows].ReadOnly = true;

        }


        private void DataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                { e.Handled = true; }

            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(DataGridView1_KeyPress);
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) & e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Array.Resize(ref totalSum, numRows+1);
            double value = 0;
            allDays = 0;
            double totalColumn = 0;
            if (textBox1.Text != "")
            {
                systemValue = Convert.ToInt32(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Введите себестоимость системы");
                return;
            }
            for(int i = 0; i < numRows; i++)
            {
                if(dataGridView1[1,i].Value!=null || dataGridView1[3, i].Value != null || dataGridView1[5, i].Value != null || dataGridView1[7, i].Value != null)
                {
                    for(int j=1;j< 9; j++)
                    {
                        if (j % 2 != 0)
                        allDays += Convert.ToDouble(dataGridView1[j, i].Value);
                    }
                }
                else
                {
                    MessageBox.Show("Не все дни заполнены");
                    return;
                }
            }
            oneDayValue = systemValue / allDays;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (j % 2 != 0)
                    {
                        dataGridView1[j + 1, i].Value = Math.Round(oneDayValue * Convert.ToDouble(dataGridView1[j, i].Value), 2);
                        value+= Convert.ToDouble( dataGridView1[j + 1, i].Value);
                    }
                    dataGridView1[9, i].Value = value;
                    totalSum[i] = value;
                }
                value = 0;
            }
            for (int j = 1; j <= 8; j++)
            {
                for (int i = 0; i < numRows; i++)
                {
                    if (j % 2 == 0)
                    {
                        totalColumn += Convert.ToDouble(dataGridView1[j, i].Value);
                        dataGridView1[j, numRows].Value = Math.Ceiling(totalColumn);
                    }

                }
                totalColumn = 0;
            }
            dataGridView1[9, numRows].Value = systemValue;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < numRows; i++)
            {
                for(int j = 0; j < numRows; j++)
                {
                    if (j % 2 == 0)
                    {
                        if (dataGridView1[j, i].Value == null)
                        {
                            MessageBox.Show("Заполните таблицу");
                            return;
                        }
                    }
                }
            }
            if (numRows > 0)
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Заполните таблицу");
                return;
            }
        }
    }
}
