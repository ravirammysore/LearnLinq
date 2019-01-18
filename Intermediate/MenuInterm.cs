using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intermediate
{
    public partial class MenuInterm : Form
    {
        public MenuInterm()
        {
            InitializeComponent();
        }

        //Select And GroupBy
        private void button1_Click(object sender, EventArgs e)
        {
            new SelectGroupBy().Show();
        }

        //GroupJoin
        private void button2_Click(object sender, EventArgs e)
        {
            new GroupJoinInterm().Show();
        }
    }
}
