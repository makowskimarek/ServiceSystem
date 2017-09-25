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
    public partial class RequestListWindow : Form
    {
        public RequestListWindow()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form;
            form = new RequestWindow(null);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var selectedActivity = (WorkerActivity)this.dataGridView1.CurrentRow.DataBoundItem;
            Form form;
            form = new ActivityWindow(Mode.MANAGER, selectedActivity);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form;
            form = new ActivityListWindow(Mode.MANAGER);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
