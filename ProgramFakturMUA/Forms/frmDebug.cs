using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramFakturMUA
{
    public partial class frmDebug : Form
    {
        public string str = "";

        public frmDebug()
        {
            InitializeComponent();
        }

        private void frmDebug_Load(object sender, EventArgs e)
        {
            textBox1.Text = str;
        }
    }
}
