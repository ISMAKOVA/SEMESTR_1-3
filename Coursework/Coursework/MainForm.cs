using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void Button5_Click(object sender, EventArgs e)
        {
            Form Clients = new Clients();
            Clients.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form Products = new Products();
            Products.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form Sell = new Sell();
            Sell.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form Total = new Total();
            Total.ShowDialog();
        }
    }
}
