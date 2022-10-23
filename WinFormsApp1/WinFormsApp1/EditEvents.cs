using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class Form1
    {
        private void polygonCreateButton_CheckedChanged(object sender, EventArgs e)
        {
            if (polygonCreateButton.Checked)
            {
                vertexAddButton.Checked = false;
                vertexRemoveButton.Checked = false;
                lengthLimitButton.Checked = false;
                lengthChangeButton.Checked = false;
                perpendicularityButton.Checked = false;
                viewRelationsButton.Checked = false;
            }
        }

        private void vertexAddButton_CheckedChanged(object sender, EventArgs e)
        {
            if (vertexAddButton.Checked)
            {
                polygonCreateButton.Checked = false;
                vertexRemoveButton.Checked = false;
                lengthLimitButton.Checked = false;
                lengthChangeButton.Checked = false;
                perpendicularityButton.Checked = false;
                viewRelationsButton.Checked = false;
            }
        }

        private void vertexRemoveButton_CheckedChanged(object sender, EventArgs e)
        {
            if (vertexRemoveButton.Checked)
            {
                polygonCreateButton.Checked = false;
                vertexAddButton.Checked = false;
                lengthLimitButton.Checked = false;
                lengthChangeButton.Checked = false;
                perpendicularityButton.Checked = false;
                viewRelationsButton.Checked = false;
            }
        }
    }
}
