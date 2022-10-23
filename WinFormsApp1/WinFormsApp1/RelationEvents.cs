using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public partial class Form1 
    {
        private void lengthChangeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lengthChangeButton.Checked)
            {
                lengthLimitButton.Checked = false;
                perpendicularityButton.Checked = false;
                viewRelationsButton.Checked = false;
                polygonCreateButton.Checked = false;
                vertexAddButton.Checked = false;
                vertexRemoveButton.Checked = false;
            }
        }

        private void lengthLimitButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lengthLimitButton.Checked)
            {
                lengthChangeButton.Checked = false;
                perpendicularityButton.Checked = false;
                viewRelationsButton.Checked = false;
                polygonCreateButton.Checked = false;
                vertexAddButton.Checked = false;
                vertexRemoveButton.Checked = false;
            }
        }

        private void perpendicularityButton_CheckedChanged(object sender, EventArgs e)
        {
            if (perpendicularityButton.Checked)
            {
                lengthLimitButton.Checked = false;
                lengthChangeButton.Checked = false;
                viewRelationsButton.Checked = false;
                polygonCreateButton.Checked = false;
                vertexAddButton.Checked = false;
                vertexRemoveButton.Checked = false;
            }
        }

        private void viewRelationsButton_CheckedChanged(object sender, EventArgs e)
        {
            if(viewRelationsButton.Checked)
            {
                lengthLimitButton.Checked = false;
                perpendicularityButton.Checked = false;
                lengthChangeButton.Checked = false;
                polygonCreateButton.Checked = false;
                vertexAddButton.Checked = false;
                vertexRemoveButton.Checked = false;
            }
        }
    }
}
