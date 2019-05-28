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
        int numUpD;
        int num_row;
        int code_sell;
        string dt;
        string[] add_cl_code = new string[0];
        string[] codeCl = new string[0];
        string[] fio = new string[0];
        string[] codeProd = new string[0];
        string[] product = new string[0];
        string[] value = new string[0];
        string[] cCl = new string[0];
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
                Array.Resize(ref add_cl_code, len1);
                Array.Resize(ref codeCl, len1);
                Array.Resize(ref fio, len1);
                if (text_cl[i] != "")
                {
                    string[] ss = text_cl[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    codeCl[i] = ss[0];
                    fio[i] = ss[1];
                    client_code.Items.Add(codeCl[i]+"-"+fio[i]);
                }
            }

            string[] text_prod = File.ReadAllLines("product.txt", Encoding.GetEncoding(1251));
            int len2 = text_prod.Length;
            for (int i = 0; i < len2; i++)
            {
                Array.Resize(ref codeProd,len2);
                Array.Resize(ref product,len2);
                Array.Resize(ref value,len2);
                if (text_prod[i] != "")
                {
                    string[] ss = text_prod[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    codeProd[i] = ss[0];
                    product[i] = ss[1];
                    value[i] = ss[2];
                    product_code.Items.Add(codeProd[i] + "-" + product[i]+"-"+value[i]);
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

        private void add_btn_Click(object sender, EventArgs e)
        {

            numUpD = (int)numericUpDown1.Value;
            dt = dateTimePicker1.Value.ToShortDateString();
            Array.Resize(ref cCl, client_code.Text.Length);
            cCl =client_code.Text.Split(new char[] { '-' },StringSplitOptions.RemoveEmptyEntries);
            string []cProd = product_code.Text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (cCl[0] != "" && cProd[0]!="" && numUpD!=0)
            {
                dataGridView1.Rows.Add(code_sell, cCl[0],cCl[1], cProd[0],cProd[1], cProd[2], numUpD, dt);
                code_sell++;
                textBox1.Text = code_sell.ToString();
            }
            client_code.SelectedIndex = -1;
            product_code.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            code_sell++;
            add_btn.Enabled = false;

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count!=0) {
                int num_row = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.Remove(dataGridView1.Rows[num_row]);
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
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
            MessageBox.Show("Данные сохранены");
        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            textBox1.Text = code_sell.ToString();
            client_code.SelectedIndex = -1;
            product_code.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            add_btn.Enabled = true;
            
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            code_sell = Convert.ToInt32((length + 1).ToString());
            num_row = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[num_row].Cells[0].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32( dataGridView1.Rows[num_row].Cells[6].Value);
            
            string kodCl = dataGridView1.Rows[num_row].Cells[1].Value.ToString();
            int index = Array.IndexOf(codeCl, kodCl);
            client_code.SelectedIndex = index;
            string kodProd = dataGridView1.Rows[num_row].Cells[3].Value.ToString();
            int ind = Array.IndexOf(codeProd, kodProd);
            product_code.SelectedIndex = ind;
        }
    }
}
