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
    public partial class Products : Form
    {
        int len;
        int num_row;
        int[] code_prod = new int[0];
        string[] product = new string[0];
        string[] value = new string[0];
        string[] total = new string[0];

        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            LoadCl();
            DGV(len);
        }
        private void LoadCl()
        {
            try
            {
                string[] text = File.ReadAllLines("product.txt", Encoding.GetEncoding(1251));
                HashSet<string> remEmpF = new HashSet<string>();
                for(int i = 0; i < text.Length; i++)
                {
                    remEmpF.Add(text[i]);
                }
                remEmpF.Where(x => !string.IsNullOrWhiteSpace(x));

                string[] client_txt = new string[0];
                for(int i = 0; i < remEmpF.Count; i++)
                {
                    Array.Resize(ref client_txt, remEmpF.Count);
                    client_txt[i] = remEmpF.ElementAt(i);
                }
                len = client_txt.Length;
                for (int i = 0; i < len; i++)
                {
                    if (client_txt[i] != "")
                    {
                        Array.Resize(ref code_prod, len);
                        Array.Resize(ref product, len);
                        Array.Resize(ref value, len);
                        string[] ss = client_txt[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                        code_prod[i] = int.Parse(ss[0]);
                        product[i] = ss[1];
                        value[i] = ss[2];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Данные в файле заполнены неправильно");
            }
        }
        private void DGV(int len)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < len; i++)
            {
                dataGridView1.Rows.Add(code_prod[i], product[i],value[i]);
            }
        }


        private void change_btn_Click(object sender, EventArgs e)
        {
            product[num_row] = textBox2.Text;
            value[num_row] = textBox3.Text;
            DGV(len);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                num_row = dataGridView1.CurrentCell.RowIndex;
                textBox1.Text = dataGridView1.Rows[num_row].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[num_row].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[num_row].Cells[2].Value.ToString();
            }
            catch { }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                product[len - 1] = textBox2.Text;
                value[len - 1] = textBox3.Text;
                DGV(len);
            }

        }

        private void save_btn_Click(object sender, EventArgs e)
        {

                for (int i = 0; i < len; i++)
                {
                    Array.Resize(ref total, total.Length + 1);
                    total[i] = code_prod[i].ToString() + "#" + product[i] + "#" + value[i];
                }
                File.WriteAllLines("product.txt", total, Encoding.GetEncoding(1251));
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.Rows[num_row]);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Array.Resize(ref code_prod, len-1);
            Array.Resize(ref product, len - 1);
            Array.Resize(ref value, len - 1);
            len--;

        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[len - 1].Cells[1].Value != null)
                {
                    int code = code_prod[len - 1];
                    len++;
                    Array.Resize(ref code_prod, len);
                    Array.Resize(ref product, len);
                    Array.Resize(ref value, len);
                    code_prod[len - 1] = code + 1;
                    code++;
                    textBox1.Text = code.ToString();
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            catch {
                MessageBox.Show("Сохраните и попробуйте снова");
            }
        }
    }
}
