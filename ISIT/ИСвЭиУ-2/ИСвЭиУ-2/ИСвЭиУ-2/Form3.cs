using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИСвЭиУ_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public int matrix_size;
        int x = 0;
        public List<double> cord_y1 = new List<double>();
        public List<double> cord_y2 = new List<double>();
        private void Form3_Load(object sender, EventArgs e)
        {
            for (int y = 0; y < matrix_size; y++)
            {
                x++;
                chart1.Series[0].Points.AddXY(x, cord_y1.ElementAt(y));
                
            }
            x = 0;
            for (int y = 0; y < matrix_size; y++)
            {
                x++;
                chart1.Series[1].Points.AddXY(x, cord_y2.ElementAt(y));

            }
           
        }
    }
}
