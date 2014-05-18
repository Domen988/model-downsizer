using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Model_Downsizer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources/ModelDownsizerIcon.ico");
            this.Text = "Help";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
