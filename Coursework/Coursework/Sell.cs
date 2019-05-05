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
using System.Text;

namespace Coursework
{
    public partial class Sell : Form
    {
        int len = 1;
        public Sell()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form Clients = new Clients();
            Clients.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form Products = new Products();
            Products.Show();
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            textBox1.Text = len.ToString();
            string [] text_cl=File.ReadAllLines("client.txt",Encoding.GetEncoding(1251));
            int len1 = text_cl.Length;
            for(int i=0; i < len1; i++)
            {
                if (text_cl[i] != "")
                {
                    string[] ss = text_cl[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    // string addStr = ss[0] + " " + ss[1];
                    client_code.Items.Add(ss[0] + " " + ss[1]);
                }
            }

            string[] text_prod = File.ReadAllLines("product.txt", Encoding.GetEncoding(1251));
            int len2 = text_prod.Length;
            for (int i = 0; i < len2; i++)
            {
                if (text_prod[i] != "")
                {
                    string[] ss = text_prod[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    product_code.Items.Add(ss[0] + " " + ss[1]);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numUpD = (int)numericUpDown1.Value;
            string dt = dateTimePicker1.Value.ToShortDateString();
            string codeCl = client_code.Text;
            string codeProd = product_code.Text;
            dataGridView1.Rows.Add(len, codeCl, codeProd, numUpD, dt);
            len++;
            textBox1.Text = len.ToString();

        }
    }
}
