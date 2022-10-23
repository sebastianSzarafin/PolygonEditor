using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class Form1
    {
        private void alg1Button_CheckedChanged(object sender, EventArgs e)
        {
            whichAlgorithm = Algorithm.Default;
        }

        private void alg2Button_CheckedChanged(object sender, EventArgs e)
        {
            whichAlgorithm = Algorithm.Bresenham;
        }
    }
}
