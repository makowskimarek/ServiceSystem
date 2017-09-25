using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BizzLayer;

namespace ServiceSystem
{
    public partial class ClientListWindow : Form
    {
        public ClientListWindow()
        {
            InitializeComponent();
            dataGridView1.DataSource = ClientController.GetAllClients();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form;
            form = new ClientWindow(this, null);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form;
            var selectedClient = (CLIENT)this.dataGridView1.CurrentRow.DataBoundItem;
            form = new ObjectWindow(selectedClient);
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
            var selectedClient = (CLIENT)this.dataGridView1.CurrentRow.DataBoundItem;
            form = new ClientWindow(this, selectedClient);
            form.Show();
        }

        public void PerformRefresh()
        {
            dataGridView1.Refresh();
            dataGridView1.DataSource = ClientController.GetAllClients();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedClient = (CLIENT)this.dataGridView1.CurrentRow.DataBoundItem;
            if (ClientController.DeleteClient(selectedClient))
            {
                PerformRefresh();
                MessageBox.Show("Selected client has been deleted", "Delete result",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Selected client has not been deleted. Try again...", "Delete result",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLIENT client = new CLIENT();
            client.name = textBox1.Text;
            client.fname = textBox2.Text;
            client.lname = textBox3.Text;
            dataGridView1.DataSource = ClientController.GetClientsByCriteria(client);
        }
    }
}
