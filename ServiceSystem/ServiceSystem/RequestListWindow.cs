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
            dataGridView1.Columns["OBJECT"].Visible = false;
            dataGridView1.Columns["PERSONEL"].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedRequest = (REQUEST)this.dataGridView1.CurrentRow.DataBoundItem;
            OBJECT obj = ObjectController.GetObjectById(selectedRequest.nr_obj);
            Form form;
            form = new RequestWindow(obj, selectedRequest, manager, this, null);
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

        public void PerformRefresh()
        {
            dataGridView1.DataSource = RequestController.GetAllRequests();
        }

        private void OnSearchClick(object sender, EventArgs e)
        {
            CLIENT client = new CLIENT();
            client.name = textBox1.Text;
            client.fname = textBox2.Text;
            client.lname = textBox3.Text;
            OBJECT obj = new OBJECT();
            obj.code = textBox4.Text;
            obj.code_type = comboBox1.Text;
            dataGridView1.DataSource = RequestController.GetRequestsByCriteria(client, obj);
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var selectedRequest = (REQUEST)this.dataGridView1.CurrentRow.DataBoundItem;
            OBJECT obj = ObjectController.GetObjectById(selectedRequest.nr_obj);
            Form form;
            form = new ActivityWindow(Mode.MANAGER, null, obj, selectedRequest);
            form.Show();
        }
    }
}
