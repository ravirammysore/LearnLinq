using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basics
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        //starters
        private void button1_Click(object sender, EventArgs e)
        {
            new BasicForm1().Show();
        }

        //UDT
        private void button2_Click(object sender, EventArgs e)
        {
            new UDTForm2().Show();
        }

        //Handy Methods
        private void button3_Click(object sender, EventArgs e)
        {
            new HandyForm3().Show();
        }
    }
}
