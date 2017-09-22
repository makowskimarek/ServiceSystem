using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceSystem
{
    public partial class AdministratorWindow : Form
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form;
            form = new AccountWindow();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form form;
            form = new Login();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form;
            form = new AccountWindow();
            form.Show();
        }
    }
}
