using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ChangeLengthForm : Form
    {
        public double length = -1;
        public ChangeLengthForm(Form1.Edge e)
        {
            InitializeComponent();
            textBox1.Text = Math.Round(e.length, 2).ToString();
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            length = Convert.ToDouble(textBox1.Text);
            Close();
        }
    }
}
