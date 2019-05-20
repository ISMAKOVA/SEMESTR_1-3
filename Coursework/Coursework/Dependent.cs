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
        int[] code_cl = new int[0];
        string[] fio = new string[0];
        int len;
        string[] code_sell = new string[0];
        string[] code_client = new string[0];
        string[] code_prod = new string[0];
        string[] product = new string[0];
        string[] value = new string[0];
        string[] num = new string[0];
        string[] date = new string[0];
        int [] total = new int[0];
        int num_row;
        int len1;
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

        }
        private void DGV(int len)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < len; i++)
            {
                dataGridView1.Rows.Add(code_cl[i], fio[i]);
            }
        }
        public void LoadSell()
        {
            string[] sell = File.ReadAllLines("sell.txt", Encoding.GetEncoding(1251));
            len1 = sell.Length;
            for(int i=0; i < len1; i++)
            {
                Array.Resize(ref code_sell, len1);
                Array.Resize(ref code_prod, len1);
                Array.Resize(ref code_client, len1);
                Array.Resize(ref product, len1);
                Array.Resize(ref value, len1);
                Array.Resize(ref num, len1);
                Array.Resize(ref date, len1);
                Array.Resize(ref total, len1);
                string[] ss = sell[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                code_sell[i] = ss[0];
                code_client[i] = ss[1];
                code_prod[i] = ss[3];
                product[i] = ss[4];
                value[i] = ss[5];
                num[i] = ss[6];
                date[i] = ss[7];
                total[i] = Convert.ToInt32(ss[5]) * Convert.ToInt32(ss[6]);
            }
        }

        private void Dependent_Load(object sender, EventArgs e)
        {
            LoadSell();
            Loadc();
            DGV(len);
        }


        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            textBox1.Text = "";
            int result = 0;
            num_row = dataGridView1.CurrentCell.RowIndex;
            string kodeCl = dataGridView1.Rows[num_row].Cells[0].Value.ToString();
            for(int i = 0; i < len1; i++)
            {
                if (kodeCl == code_client[i])
                {
                    dataGridView2.Rows.Add(code_sell[i], code_prod[i], product[i], value[i], num[i], date[i]);
                    result += total[i];
                    textBox1.Text = result.ToString();
                }
            }

            


        }
    }
}
  