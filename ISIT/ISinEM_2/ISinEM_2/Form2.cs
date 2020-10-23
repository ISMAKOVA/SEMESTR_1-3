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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int num;
        int rowIndex = 0;
        int columnIndex = 0;
        int curNum = 0;
        int numForm1 = Form1.numRows;
        int systemValue = Form1.systemValue;
       
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

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (columnIndex > 0)
            {
                if (Convert.ToInt32(dataGridView1[columnIndex, rowIndex].Value) > 10)
                {
                    MessageBox.Show("Значения не меньше 0 и не больше 10");
                    if(dataGridView1[columnIndex, rowIndex].Value == null)
                    dataGridView1[columnIndex, rowIndex].Value = 0;
                    dataGridView1[columnIndex, rowIndex].Value = 0;
                }
                else
                {
                    curNum = Convert.ToInt32(dataGridView1[columnIndex, rowIndex].Value);
                    dataGridView1[rowIndex + 1, columnIndex - 1].Value = 10 - curNum;
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            rowIndex = dataGridView1.CurrentCell.RowIndex;
            columnIndex = dataGridView1.CurrentCell.ColumnIndex;

        }
        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            double [] rowSum = new double[num];
            int totalSum = 0;
            double Vx = 0;
            int Xij=0;
            for (int i = 0; i < num; i++)
            {
                for (int j = 1; j <= num; j++)
                {
                    rowSum[i] += Convert.ToInt32(dataGridView1[j, i].Value);
                    dataGridView1[num + 1, i].Value = rowSum[i];
                    Xij+= Convert.ToInt32(dataGridView1[j, i].Value);
                }
            }
            for (int i = 0; i < num; i++)
            {
                dataGridView1[num + 2, i].Value = Math.Round(rowSum[i] / Xij, 2);
                totalSum += Convert.ToInt32(dataGridView1[num + 1, i].Value);
                dataGridView1[num + 1, num].Value = totalSum;
                Vx+= Convert.ToDouble(dataGridView1[num + 2, i].Value);
                dataGridView1[num + 2, num].Value = Math.Round(Vx);

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Top", "");
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите кол-во функций");

            }
            else
            {
                num = Convert.ToInt32(textBox1.Text);
                for(int i=0; i < num; i++)
                {
                    dataGridView1.Rows.Add("Ф" + (i+1));
                    dataGridView1[0, i].ReadOnly = true;
                    dataGridView1.Columns.Add("Name","Ф" + (i+1));     
                }
                dataGridView1.Rows.Add("Итого:");
                dataGridView1.Rows[num].ReadOnly = true;
                dataGridView1.Columns.Add("Sum", "Сумма ряда");
                dataGridView1.Columns.Add("Index", "Индекс балло-значимости");
                for (int i = 0; i < num; i++)
                {
                    dataGridView1.Rows[i].Cells[num + 1].ReadOnly = true;
                    dataGridView1.Rows[i].Cells[num + 2].ReadOnly = true;
                }
                for (int i = 0; i < num; i++)
                {
                    for (int j = 1; j < num + 1; j++)
                    {
                        if (i == j - 1)
                        {
                            dataGridView1[j,i].Value = 0;
                            dataGridView1[j,i].ReadOnly = true;
                        }
                        if (dataGridView1[j,i].Value == null)
                        {
                            dataGridView1[num+1,i].Value = 0;
                        }
                    }
                }
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                { e.Handled = true; }

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double[] totalSum = Form1.totalSum;
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Постройте таблицу 'Функциональная модель'");
                return;
            }
            for (int j = 0; j < num; j++)
            {
                for (int i = 0; i < num + 1; i++)
                {
                    if (dataGridView1[i,j].Value == null)
                    {
                        MessageBox.Show("Таблица 'Матрица парных сравнений' заполнена не полностью");
                        return;
                    }
                }
            }
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Name", "Модули");
            dataGridView2.Columns.Add("Cost", "Стоимость");
            for(int i = 0; i < num; i++)
            {
                dataGridView2.Columns.Add("Function", "Ф" + (i + 1));
            }
            for (int i=0; i < numForm1; i++)
            {
                dataGridView2.Rows.Add("Элемент");
                dataGridView2.Rows.Add("Денежная доля");
            }
            dataGridView2.Rows.Add("Итого:");
            dataGridView2.Rows.Add("В долях:");
            for (int i=0; i<dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Cells[0].ReadOnly = true;
                dataGridView2.Rows[i].Cells[1].ReadOnly = true;
                if (i % 2 != 0 )
                {
                    dataGridView2.Rows[i].ReadOnly = true;
                    dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.AliceBlue;
                    dataGridView2.Rows[dataGridView2.RowCount-1].Cells[0].Style.BackColor = Color.White;
                }
            }
            dataGridView2.Rows[numForm1*2].ReadOnly = true;
            dataGridView2.Rows[numForm1*2 + 1].ReadOnly = true;

            for (int i = 0; i < numForm1 * 2; i++)
            {
                for (int j = 0; j < numForm1; j++)
                {
                    if (i % 2 != 0)
                    {
                        dataGridView2[1, i].Value = totalSum[j];
                    }
                }
            }



        }

        private void DataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb2 = (TextBox)e.Control;
            tb2.KeyPress -= tb2_KeyPress;
            tb2.KeyPress += new KeyPressEventHandler(this.tb2_KeyPress);
        }

        private void DataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }

        }
        void tb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double count = 0;
           // double[] totalSum = Form1.totalSum;
            double value = 0;
            double partValue = 0;
            int id = 0;
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Постройте таблицу 'Совемещенная модель'");
                return;
            }
            for (int j = 0; j < num; j++)
            {
                for (int i = 0; i < num + 1; i++)
                {
                    if (dataGridView1.Rows[j].Cells[i].Value == null)
                    {
                        MessageBox.Show("Заполните матрицу парных сравнений");
                        return;
                    }
                }
            }
            button3.Enabled = true;
            for (int i = 0; i < numForm1 * 2; i++)
            {
                if (i % 2 != 0)
                {
                    value = Convert.ToDouble(dataGridView2[1,i].Value);
                    for (int j = 2; j < dataGridView2.Columns.Count; j++)
                        count += Convert.ToDouble(dataGridView2[j,id].Value);

                    for (int j = 2; j < dataGridView2.Columns.Count; j++)
                    {
                        if (count < 1 || count > 1)
                        {
                            MessageBox.Show("Функция должна иметь распределение в сумме равное единице!");
                            break;
                        }
                        else
                            partValue = value * Convert.ToDouble(dataGridView2[j,id].Value);

                        if (partValue == 0)
                            dataGridView2[j,i].Value = "";
                        else
                            dataGridView2[j,i].Value = partValue;
                    }
                    partValue = 0;
                    id += 2;
                    count = 0;
                }
            }
            id = 0;
            double sum = 0;
            for (int i = 1; i < dataGridView2.Columns.Count; i++)
            {
                for (int j = 0; j < numForm1 * 2; j++)
                {
                    if (j % 2 != 0)
                        if (dataGridView2[i,j].Value.ToString() == "")
                            sum += 0;
                        else
                            sum += Convert.ToDouble(dataGridView2[i,j].Value);
                }
                dataGridView2.Rows[numForm1 * 2].Cells[i].Value = sum;
                dataGridView2.Rows[numForm1 * 2 + 1].Cells[i].Value = sum / systemValue;
                sum = 0;
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
          //  chart1.Visible = true;
            for(int i = 1; i < num; i++)
            {
                chart1.Series[0].Points.AddXY(i, dataGridView1.Rows[i].Cells[num + 2].Value);
                chart1.Series[1].Points.AddXY(i, dataGridView2.Rows[numForm1 * 2 + 1].Cells[i + 2].Value);
            }
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
