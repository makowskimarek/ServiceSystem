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
        public PERSONEL manager;
        public RequestListWindow(PERSONEL man)
        {
            InitializeComponent();
            manager = man;
            dataGridView1.DataSource = RequestController.GetAllRequests();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedRequest = (REQUEST)this.dataGridView1.CurrentRow.DataBoundItem;
            OBJECT obj = ObjectController.GetObjectById(selectedRequest.nr_obj);
            Form form;
            form = new RequestWindow(obj, selectedRequest, manager);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //var selectedActivity = (WorkerActivity)this.dataGridView1.CurrentRow.DataBoundItem;
            Form form;
            form = new ActivityWindow(Mode.MANAGER, null);
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

        private void OnDeleteClick(object sender, EventArgs e)
        {
            var selectedRequest = (REQUEST)this.dataGridView1.CurrentRow.DataBoundItem;
            RequestController.DeleteRequest(selectedRequest);
            dataGridView1.DataSource = RequestController.GetAllRequests();
        }
    }
}
