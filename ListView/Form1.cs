using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //listView1.Columns.Add("ID", 100);
            //listView1.Columns.Add("NAME", 100);
            //listView1.Columns.Add("AGE", 100);

            //listView1.Items.Add(new ListViewItem(new[] { "1", "Laylo", "21" }));

            listView1.Columns.Add("ID");
            listView1.Columns.Add("NAME");
            listView1.Columns.Add("AGE");
            string[] row1 = { "1", "John", "25" };
            string[] row2 = { "2", "Jane", "30" };

            listView1.Items.Add(new ListViewItem(row1));
            listView1.Items.Add(new ListViewItem(row2));
        }

    }
}
