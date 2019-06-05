using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Coursework
{
    public partial class Dependent : Form
    {
        int len;
        int len2;
        int len_sell;
        int[] code_cl = new int[0];
        string[] fio = new string[0];
        int[] codeCl = new int[0];
        int[] codeProd = new int[0];
        int[] codeSell = new int[0];
        int[] num = new int[0];
        int[] code_prod = new int[0];
        string[] product = new string[0];
        string[] value = new string[0];
        string[] date = new string[0];
        int num_row;
        public Dependent()
        {
            InitializeComponent();
        }
        public void Loadc()
        {
            string[] client = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
            len = client.Length;
            for (int i = 0; i < len; i++)
            {
                Array.Resize(ref code_cl, len);
                Array.Resize(ref fio, len);
                string[] ss = client[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                code_cl[i] = int.Parse(ss[0]);
                fio[i] = ss[1];
            }

            string[] text_prod = File.ReadAllLines("product.txt", Encoding.GetEncoding(1251));
            len2 = text_prod.Length;
            for (int i = 0; i < len2; i++)
            {
                Array.Resize(ref code_prod, len2);
                Array.Resize(ref product, len2);
                Array.Resize(ref value, len2);
                if (text_prod[i] != "")
                {
                    string[] ss = text_prod[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    code_prod[i] = Convert.ToInt32(ss[0]);
                    product[i] = ss[1];
                    value[i] = ss[2];
                }
            }
            string[] sells = File.ReadAllLines("sell.txt", Encoding.GetEncoding(1251));
            len_sell = sells.Length;
            for (int i = 0; i < len_sell; i++)
            {
                Array.Resize(ref codeSell, len_sell);
                Array.Resize(ref codeCl, len_sell);
                Array.Resize(ref codeProd, len_sell);
                Array.Resize(ref num, len_sell);
                Array.Resize(ref date, len_sell);

                string[] ss = sells[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                codeSell[i] = Convert.ToInt32(ss[0]);
                codeCl[i] = Convert.ToInt32(ss[1]);
                codeProd[i] =Convert.ToInt32(ss[2]);
                num[i] = Convert.ToInt32(ss[3]);
                date[i] = ss[4];
            }


        }
        private void DGV(int len)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < len; i++)
            {
                dataGridView1.Rows.Add(code_cl[i], fio[i]);
            }
        }

        private void Dependent_Load(object sender, EventArgs e)
        {
            Loadc();
            DGV(len);
        }


        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            textBox1.Text = "";
            int result = 0;
            num_row = dataGridView1.CurrentCell.RowIndex;

            int kodeCl = Convert.ToInt32(dataGridView1.Rows[num_row].Cells[0].Value.ToString());
            for(int i = 0; i < len_sell; i++)
            {
                if (kodeCl == codeCl[i])
                {
                    for (int j = 0; j < len_sell; j++) {

                        if (codeProd[i] == code_prod[j]) {
                            result += Convert.ToInt32(value[j]) * num[i];
                            dataGridView2.Rows.Add(codeSell[i], codeProd[i], product[j], value[j], num[i], date[j]);
                            textBox1.Text = result.ToString();
                        }
                    }
                }
            }



           


        }
    }
}
  