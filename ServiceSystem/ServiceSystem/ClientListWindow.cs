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
    public partial class ClientListWindow : Form
    {
        public ClientListWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form;
            form = new ClientWindow();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form;
            form = new ObjectWindow();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form;
            form = new ObjectListWindow();
            form.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form form;
            form = new Login();
            form.Show();
        }

        private void objectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form;
            form = new ObjectListWindow();
            form.Show();
        }

        private void requestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form;
            form = new RequestListWindow();
            form.Show();
        }

        private void activityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form;
            form = new ActivityListWindow(Mode.MANAGER);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form;
            form = new ClientWindow();
            form.Show();
        }
    }
}
