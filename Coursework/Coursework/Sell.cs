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
    public partial class Sell : Form
    {
        int len = 1;
        int length;
        public Sell()
        {
            InitializeComponent();
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            client_code.DropDownStyle = ComboBoxStyle.DropDownList;
            product_code.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox1.Text = len.ToString();
            string [] text_cl=File.ReadAllLines("client.txt",Encoding.GetEncoding(1251));
            int len1 = text_cl.Length;
            for(int i=0; i < len1; i++)
            {
                if (text_cl[i] != "")
                {
                    string[] ss = text_cl[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    // string addStr = ss[0] + " " + ss[1];
                    client_code.Items.Add(ss[0] + "-" + ss[1]);
                }
            }

            string[] text_prod = File.ReadAllLines("product.txt", Encoding.GetEncoding(1251));
            int len2 = text_prod.Length;
            for (int i = 0; i < len2; i++)
            {
                if (text_prod[i] != "")
                {
                    string[] ss = text_prod[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    product_code.Items.Add(ss[0] + "-" + ss[1]+"-"+ss[2]);
                }
            }

            string[] sells = File.ReadAllLines("sell.txt", Encoding.GetEncoding(1251));
            length = sells.Length;
            for(int i=0; i < sells.Length; i++)
            {
                if (sells != null)
                {
                    string [] ss = sells[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    dataGridView1.Rows.Add(ss);

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numUpD = (int)numericUpDown1.Value;
            string dt = dateTimePicker1.Value.ToShortDateString();
            string [] codeCl =client_code.Text.Split(new char[] { '-' },StringSplitOptions.RemoveEmptyEntries);
            string []codeProd = product_code.Text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (codeCl[0] != "" && codeProd[0]!="" && numUpD!=0)
            {
                dataGridView1.Rows.Add(len, codeCl[0],codeCl[1], codeProd[0],codeProd[1], codeProd[2], numUpD, dt);
                len++;
                textBox1.Text = len.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count!=0) {
                int num_row = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.Remove(dataGridView1.Rows[num_row]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] total = new string[0];
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Array.Resize(ref total, total.Length + 1);
            for(int j=0; j < 8; j++)
                {
                    total[i] += dataGridView1.Rows[i].Cells[j].Value.ToString()+"#";
                }
            }
            File.WriteAllLines("sell.txt", total, Encoding.GetEncoding(1251));
        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            int code_sell =Convert.ToInt32( (length + 1).ToString());
           // textBox1.Text = code_sell.ToString()
        }
    }
}
