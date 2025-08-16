using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikaScan
{
    public partial class Form1 : Form
    {
        public Form1(string deeplink)
        {
            InitializeComponent();
            MessageBox.Show("Deeplink recibido: " + deeplink);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.twainCapture1.StartModule();
        }
    }
}
