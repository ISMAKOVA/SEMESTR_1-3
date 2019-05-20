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
        string result;
        string codeCl;
        string codeProd;
        string value;
        string date;
        string num;
        public Total()
        {
            InitializeComponent();
        }

        private void Total_Load(object sender, EventArgs e)
        {
            string[] sells = File.ReadAllLines("sell.txt", Encoding.GetEncoding(1251));
            if (sells != null)
            {
                for (int i = 0; i < sells.Length; i++)
                {
                    string[] ss = sells[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                    result = (Convert.ToInt32(ss[5]) * Convert.ToInt32(ss[6])).ToString();
                    codeCl = ss[2];
                    codeProd = ss[4];
                    value = ss[5];
                    date = ss[7];
                    num = ss[6];
                    dataGridView1.Rows.Add(codeCl, codeProd, value, date, num, result);
                }

            }
        }
    }
}
