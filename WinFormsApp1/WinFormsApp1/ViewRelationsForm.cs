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
    public partial class ViewRelationsForm : Form
    {
        public List<Form1.Property> properties = new List<Form1.Property>();
        public (Color color, bool isFree)[] colors;
        public ViewRelationsForm(Form1.Edge e, (Color color, bool isFree)[] _colors)
        {
            InitializeComponent();
            properties = e.properties;
            colors = _colors;

            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            
            listView1.Columns.Add("Edge", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Property", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Other info", -2, HorizontalAlignment.Left);

            foreach (Form1.Property property in properties)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = $"({property.e.u.X}, {property.e.u.Y}) -> ({property.e.v.X}, {property.e.v.Y})";
                listViewItem.SubItems.Add($"{property}");
                listViewItem.SubItems.Add($"{property.Info()}");
                listView1.Items.Add(listViewItem);
            }

            
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    if(properties[item.Index] is Form1.PerpendicularityProperty)
                    {
                        Form1.PerpendicularityProperty property = (Form1.PerpendicularityProperty)properties[item.Index];
                        property.perpendicularTo.properties.RemoveAll(
                            _property => _property is Form1.PerpendicularityProperty &&
                            ((Form1.PerpendicularityProperty)_property).perpendicularTo == property.e);
                        int? colorIndex = Array.IndexOf(colors, Array.Find(colors, c => c.color == property.color));
                        if (colorIndex != null) colors[(int)colorIndex].isFree = true;
                    }
                    properties.RemoveAt(item.Index);
                    listView1.Items.Remove(item);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
