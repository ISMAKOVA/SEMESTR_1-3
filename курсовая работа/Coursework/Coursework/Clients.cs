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
        int[] code_cl = new int[0];
        string[] fio = new string[0];
        int len;
        int num_row;
        int code;
        private void Clients_Load(object sender, EventArgs e)
        {
            LoadCl();
            DGV(len);
        }

        private void LoadCl()
        //считываение данных при загрузке
        {
            try
            {
                //получаем данные в массив text
                string[] text = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
                HashSet<string> remEmpF = new HashSet<string>();
                for (int i = 0; i < text.Length; i++)
                {
                    remEmpF.Add(text[i]);
                }
                //избавляемся от пустых строк в текстовом файле
                remEmpF.Where(x => !string.IsNullOrWhiteSpace(x));
                string[] client_txt = new string[0];
                for (int i = 0; i < remEmpF.Count; i++)
                {
                    Array.Resize(ref client_txt, client_txt.Length + 1);
                    client_txt[i] = remEmpF.ElementAt(i);
                }
                len = client_txt.Length;
                for (int i = 0; i < len; i++)
                {
                    if (client_txt[i] != "")
                    {
                        Array.Resize(ref code_cl, len);
                        Array.Resize(ref fio, len);
                        string[] ss = client_txt[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                        code_cl[i] = int.Parse(ss[0]);//массив с кодом клиентов
                        fio[i] = ss[1];//массив фамилий клиентов
                    }
                }
            }
            catch
            {
                MessageBox.Show("Данные в файле заполнены неправильно");
            }
        }
        private void DGV(int len)//заполнение таблицы
        {
            //очищение таблицы перед заполнением
            dataGridView1.Rows.Clear();
            for (int i = 0; i < len; i++)
            {
                //добавление строк
                dataGridView1.Rows.Add(code_cl[i], fio[i]);
            }
        }


        private void Save_btn_Click_1(object sender, EventArgs e)
        {
            int countStr = dataGridView1.Rows.Count;
            string[] saveClient = new string[countStr];
            for (int i = 0; i < countStr; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    saveClient[i] += dataGridView1.Rows[i].Cells[j].Value + "#";
                    File.WriteAllLines("client.txt", saveClient, Encoding.GetEncoding(1251));
                }
            }
            MessageBox.Show("Данные сохранены");
        }

        private void Delete_btn_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.Rows[num_row]);
            textBox1.Text = "";
            textBox2.Text = "";
            Array.Resize(ref code_cl, len - 1);
            Array.Resize(ref fio, len - 1);
            len--;
        }

        private void DataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                num_row = dataGridView1.CurrentCell.RowIndex;
                textBox1.Text = dataGridView1.Rows[num_row].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[num_row].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void New_btn_Click(object sender, EventArgs e)
        {
            add_btn.Enabled = true;
            if (dataGridView1.Rows[len - 1].Cells[1].Value != null)
            {
                code = code_cl[len - 1];
                len++;
                Array.Resize(ref code_cl, len);
                Array.Resize(ref fio, len);
                code_cl[len - 1] = code + 1;
                code++;
                textBox1.Text = code.ToString();
                textBox2.Text = "";
                new_btn.Enabled = false;
            }
        }

        private void Change_btn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Поле пустое");
            }
            else
            {
                fio[num_row] = textBox2.Text;
                DGV(len);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            add_btn.Enabled = false;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Поле пустое");
            }
            else
            {
                fio[len - 1] = textBox2.Text;
                DGV(len);
                new_btn.Enabled = true;
            }
        }
    }

}

