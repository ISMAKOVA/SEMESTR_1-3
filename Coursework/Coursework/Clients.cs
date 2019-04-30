using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Coursework
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }
        string[] total = new string[0];
        int[] code_cl = new int [0];
        string[] fio = new string[0];
        int len;
        int num_row;
        int dtgL;
        private void Clients_Load(object sender, EventArgs e)
        {
            LoadCl();
            DGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fio[num_row] = textBox2.Text;
            DGV();

        }
        private void LoadCl()
        {
            string[] client_txt = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
            len = client_txt.Length;
            for(int i = 0; i < len-1; i++)
            {
                Array.Resize(ref code_cl, len);
                Array.Resize(ref fio, len);
                string []ss = client_txt[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                code_cl[i] = int.Parse(ss[0]);
                fio[i] = ss[1];
            }
        }
        private void DGV()
        {
            dataGridView1.Rows.Clear();
            for(int i = 0; i < len; i++)
            {
                dataGridView1.Rows.Add(code_cl[i], fio[i]);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            num_row = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[num_row].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[num_row].Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int code = code_cl[len - 1];
            len++;
            Array.Resize(ref code_cl, len);
            Array.Resize(ref fio, len);
            code_cl[len - 1] = code+1;
            code++;
           /* DGV();
            dataGridView1.Rows[num_row].Selected = false;
            dataGridView1.Rows[len-1].Selected=true;
            dataGridView1.CurrentCell = dataGridView1[0, len - 1];
            num_row = dataGridView1.CurrentRow.Index;*/
            textBox1.Text = code.ToString();
            textBox2.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtgL = dataGridView1.RowCount;
            fio[len - 1] = textBox2.Text;
            DGV();
            for (int i = 0; i < dtgL; i++)
            {
                Array.Resize(ref total, total.Length + 1);
                total[i] = code_cl[i].ToString() +"#"+ fio[i];
            }
            File.WriteAllLines("client.txt", total, Encoding.GetEncoding(1251));
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

}
