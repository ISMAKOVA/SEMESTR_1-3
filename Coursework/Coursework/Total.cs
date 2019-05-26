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
using System.Collections;

namespace Coursework
{
    public partial class Total : Form
    {
        int [] codeCl= new int[0];
        int [] value= new int[0];
        int [] num= new int[0];
        int[] code_cl = new int[0];
        string[] fio = new string[0];
        string[] fioCl = new string[0];
        int len;
        int len1;
        public Total()
        {
            InitializeComponent();
        }

        private void Total_Load(object sender, EventArgs e)
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

            string[] sells = File.ReadAllLines("sell.txt", Encoding.GetEncoding(1251));
            len1 = sells.Length;
            for(int i = 0; i < len1; i++)
            {
                Array.Resize(ref codeCl, len1);
                Array.Resize(ref fioCl, len1);
                Array.Resize(ref value, len1);
                Array.Resize(ref num, len1);
                string[] ss = sells[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                codeCl[i] = Convert.ToInt32(ss[1]);
                fioCl[i] = ss[2];
                value[i] = Convert.ToInt32(ss[5]);
                num[i] = Convert.ToInt32(ss[6]);
            }
            DGV();
            
        }
        private void DGV()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < len; i++)
            {
                int counter = 0;
                int sumProd = 0;
                int result=1;
                dataGridView1.Rows.Add(code_cl[i],fio[i]);
                for(int j = 0; j < len1; j++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == codeCl[j].ToString())
                    {
                        counter++;
                        sumProd += num[j];
                        result = sumProd * value[j];

                    }
                    dataGridView1.Rows[i].Cells[2].Value = counter;
                    dataGridView1.Rows[i].Cells[3].Value = sumProd;
                    if (result == 1)
                    {
                        dataGridView1.Rows[i].Cells[4].Value = 0;
                    }
                    else
                    dataGridView1.Rows[i].Cells[4].Value = result;

                }
            }

        }
    }
}
