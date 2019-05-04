﻿using System;
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
        private void Clients_Load(object sender, EventArgs e)
        {
            LoadCl();
            DGV(len);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fio[num_row] = textBox2.Text;
            DGV(len);

        }
        private void LoadCl()
        {
            try
            {
                string[] text = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
                HashSet<string> remEmpF = new HashSet<string>();
                for (int i = 0; i < text.Length; i++)
                {
                    remEmpF.Add(text[i]);
                }
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
                    if(client_txt[i] != "")
                    {
                        Array.Resize(ref code_cl, len);
                        Array.Resize(ref fio, len);
                        string[] ss = client_txt[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                        code_cl[i] = int.Parse(ss[0]);
                        fio[i] = ss[1];
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
            for(int i = 0; i < len-1; i++)
            {
                dataGridView1.Rows.Add(code_cl[i], fio[i]);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                num_row = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[num_row].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[num_row].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[len - 1].Cells[1].Value != null)
            {
                int code = code_cl[len - 1];
                len++;
                Array.Resize(ref code_cl, len);
                Array.Resize(ref fio, len);
                code_cl[len - 1] = code + 1;
                code++;
                textBox1.Text = code.ToString();
                textBox2.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int dtgL = dataGridView1.RowCount;
                fio[len - 1] = textBox2.Text;
                DGV(dtgL-1);
                for (int i = 0; i < dtgL-1; i++)
                {
                    Array.Resize(ref total, total.Length + 1);
                    total[i] = code_cl[i].ToString() + "#" + fio[i];
                }
                File.WriteAllLines("client.txt", total, Encoding.GetEncoding(1251));
            }
            catch
            {
                MessageBox.Show("Проверьте введенные данные");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dtgL = dataGridView1.RowCount;
            dataGridView1.Rows.Remove(dataGridView1.Rows[num_row]);
            textBox1.Text = "";
            textBox2.Text = "";
            Array.Resize(ref code_cl, dtgL - 1);
            Array.Resize(ref fio, dtgL - 1);
        }
    }

}
