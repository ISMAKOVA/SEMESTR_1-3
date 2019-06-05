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
        string[] codeProd = new string[0];
        int [] num= new int[0];
        int[] code_cl = new int[0];
        string[] fio = new string[0];
        string[] code_prod = new string[0];
        string[] product = new string[0];
        string[] value = new string[0];
        int len1;
        int len_sell;
        int len2;
        public Total()
        {
            InitializeComponent();
        }

        private void Total_Load(object sender, EventArgs e)
        {

            string[] client = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
            len1 = client.Length;
            for (int i = 0; i < len1; i++)
            {
                Array.Resize(ref code_cl, len1);
                Array.Resize(ref fio, len1);
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
                    code_prod[i] = ss[0];
                    product[i] = ss[1];
                    value[i] = ss[2];
                }
            }

            string[] sells = File.ReadAllLines("sell.txt", Encoding.GetEncoding(1251));
            len_sell = sells.Length;
            for(int i = 0; i < len_sell; i++)
            {
                Array.Resize(ref codeCl, len_sell);
                Array.Resize(ref codeProd, len_sell);
                Array.Resize(ref num, len_sell);
                string[] ss = sells[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                codeCl[i] = Convert.ToInt32(ss[1]);
                codeProd[i] = ss[2];
                num[i] = Convert.ToInt32(ss[3]);
            }
            DGV();
           // DGV2();
            
        }
        private void DGV()
        {
            /* dataGridView1.Rows.Clear();
             for (int i = 0; i < len1; i++)
             {
                 int counter = 0;
                 int sumProd = 0;
                 int [] result=new int[len1];
                 int res = 0;
                 dataGridView1.Rows.Add(code_cl[i],fio[i]);
                 for(int j = 0; j < len_sell; j++)
                 {
                     if (dataGridView1.Rows[i].Cells[0].Value.ToString() == codeCl[j].ToString())
                     {
                         counter++;
                         sumProd += num[j];
                         for(int k = 0; k < len2; k++)
                         {
                             if (codeProd[i] == code_prod[k])
                             {
                                 result[i] = Convert.ToInt32(value[k]) * num[i];
                                // result = sumProd * Convert.ToInt32(value[k]); //сделать правильный расчет итогов 
                                 res += result[i];
                             }
                         }

                     }
                     dataGridView1.Rows[i].Cells[2].Value = counter;
                     dataGridView1.Rows[i].Cells[3].Value = sumProd;
                     if (result[i] == 1)
                     {
                         dataGridView1.Rows[i].Cells[4].Value = 0;
                     }
                     else
                         dataGridView1.Rows[i].Cells[4].Value = res;

                 }
             }*/
            dataGridView1.Rows.Clear();
            int[] sumProd = new int[0];
            int[] result = new int[0];
            int[] counter = new int[0];
            for (int i=0; i < len1; i++)
            {
               // dataGridView1.Rows.Add(code_cl[i], fio[i]);

                for (int j = 0; j < len_sell; j++)
                {
                    Array.Resize(ref counter, len_sell);
                    Array.Resize(ref sumProd, len_sell);
                    Array.Resize(ref result, len_sell);
                    if (code_cl[i] == codeCl[j])
                    {
                        for (int k = 0; k < len2; k++)
                        {
                            if (codeProd[j] == code_prod[k])
                            {
                                counter[i]++;
                                sumProd[i] += num[j];
                                result[i] += Convert.ToInt32(value[k]) * num[j];
                            }
                        }
                    }
                }
                dataGridView1.Rows.Add(codeCl[i], fio[i], counter[i], sumProd[i], result[i]);
            }

        }

        private void DGV2()
        {
            int result=0;
            for(int i=0; i < len_sell; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    if (codeProd[i] == code_prod[j])
                    {
                        result = num[i] * Convert.ToInt32(value[j]);
                    }
                }
                if (result == 0)
                {
                    dataGridView1.Rows[i].Cells[4].Value = 0;
                }
                else
                    dataGridView1.Rows[i].Cells[4].Value = result; 
            }
        }


    }
}
