using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        public delegate void guardarnombre(string nom);
        public event guardarnombre Pasado;
        public delegate void guardarnombre1();
        public event guardarnombre1 Pasado1;
        public Form2()
        {
            InitializeComponent();
        }

        private void enviarnombre_Click(object sender, EventArgs e)
        {
            Pasado(textBox1.Text);
            Pasado1();
            this.Dispose();
        }
    }
}
