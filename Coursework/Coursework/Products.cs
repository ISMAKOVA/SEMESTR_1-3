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
        int[] code_prod = new int[0];
        string[] product = new string[0];
        int[] value = new int[0];
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {

        }
        private void LoadCl()
        {
            string[] client_txt = File.ReadAllLines("client.txt", Encoding.GetEncoding(1251));
            len = client_txt.Length;
            for (int i = 0; i < len; i++)
            {
                Array.Resize(ref code_prod, len);
                Array.Resize(ref product, len);
                string[] ss = client_txt[i].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                code_prod[i] = int.Parse(ss[0]);
                product[i] = ss[1];
                value[i] = int.Parse(ss[2]);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
