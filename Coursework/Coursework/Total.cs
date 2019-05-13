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
    public partial class Total : Form
    {
        int len;
        char d = '#';
        int num_row;
        int[] code_cl = new int[0];
        int[] code_prod = new int[0];
        string[] date = new string[0];
        int[] num = new int[0];
        string[] result = new string[0];
        public Total()
        {
            InitializeComponent();
        }
        public static string[] StringTxt(string []txt, HashSet<string> A)
        {
            string[] str = new string[0];
            for (int i = 0; i < txt.Length; i++)
            {
                A.Add(txt[i]);
            }
            A.Where(x => !string.IsNullOrWhiteSpace(x));

            for (int i = 0; i < A.Count; i++)
            {
                Array.Resize(ref str, A.Count);
                str[i] = A.ElementAt(i);
            }
            A.Clear();
            return str;
        }
        private void Total_Load(object sender, EventArgs e)
        {
            string[] product = File.ReadAllLines("product.txt", Encoding.GetEncoding(1251));

            var remEmpFA = new HashSet<string>();
            string[] sell = File.ReadAllLines("sell.txt", Encoding.GetEncoding(1251));
            string[] sells = StringTxt(sell, remEmpFA);
            len = sells.Length;
            for(int i=0; i < len; i++)
            {
                if (sells[i] != "")
                {
                    string[] ss = sells[i].Split(d);
                    Array.Resize(ref code_cl, len);
                    Array.Resize(ref code_prod, len);
                    Array.Resize(ref date, len);
                    Array.Resize(ref num, len);
                    Array.Resize(ref result, len);
                    code_cl[i] = int.Parse(ss[0]);
                    code_prod[i] = int.Parse(ss[1]);
                    date[i] = ss[2];
                    num[i] = int.Parse(ss[3]);
                    result[i] = (int.Parse(ss[3]) * 1).ToString();

                }
            }



        }
    }
}
