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
        string [] result= new string[0];
        int [] codeCl= new int[0];
        string [] codeProd= new string[0];
        string [] value= new string[0];
        string [] date= new string[0];
        string [] num= new string[0];
        int[] code_cl = new int[0];
        string[] fio = new string[0];
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
            string[] totalStr = new string[len1];
           // var numProd = new List<string>();
            if (sells != null)
            {
                for (int i = 0; i < len1; i++)
                {
                    Array.Resize(ref result,len1);
                    Array.Resize(ref codeCl, len1);
                    Array.Resize(ref codeProd, len1);
                    Array.Resize(ref value, len1);
                    Array.Resize(ref date, len1);
                    Array.Resize(ref num, len1);
                    string[] ss = sells[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    result[i] = (Convert.ToInt32(ss[5]) * Convert.ToInt32(ss[6])).ToString();
                    codeCl[i] = Convert.ToInt32(ss[1]);
                    codeProd[i] = ss[4];
                    value[i] = ss[5];
                    date[i] = ss[7];
                    num[i] = ss[6];
                    for (int j = 0; j < len1; j++)
                    {
                        if (code_cl[j] == codeCl[i])
                        {
                            totalStr[i] = fio[j]+ num[i]+ value[i]+ date[i]+ result[i];
                            dataGridView1.Rows.Add(fio[j], num[i], value[i], date[i], result[i]);
                            // numProd.Add(codeProd[i]);
                        }
                        //сделать выбору по товарам: клиент купил столько-то товаров на такую-то общую сумму

                    }
                    //dataGridView1.Rows.Add(fio[i], numProd.Count, value[i], date[i], num[i], result[i]);
                   
                }

            }
        }
    }
}
