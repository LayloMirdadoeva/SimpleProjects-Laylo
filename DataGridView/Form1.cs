using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectsDataGridView
{
    public partial class Form1 : Form
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void OkBtn_Click(object sender, EventArgs e)
        {
             firstName = FirstNameTxt.Text;
             lastName = LastNameTxt.Text;
             age = Convert.ToInt32(AgeTxt.Text);

            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
