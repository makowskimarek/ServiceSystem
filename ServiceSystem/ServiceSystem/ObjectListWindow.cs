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
    public partial class ObjectListWindow : Form
    {
        public PERSONEL manager;
        public ObjectListWindow(PERSONEL man)
        {
            InitializeComponent();
            manager = man;
            dataGridView1.DataSource = ObjectController.GetAllObjects();
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form;
            form = new RequestListWindow(manager);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onDeleteItemClick(object sender, EventArgs e)
        {
            var selectedObject = (OBJECT)this.dataGridView1.CurrentRow.DataBoundItem;
            ObjectController.DeleteObject(selectedObject);
            PerformRefresh();

        }

        public void PerformRefresh() {
            dataGridView1.DataSource = ObjectController.GetAllObjects();
        }

        private void onEditItemClick(object sender, EventArgs e)
        {
            var selectedObjectAndClient = (ObjectAndClient)this.dataGridView1.CurrentRow.DataBoundItem;
            OBJECT obj = new OBJECT();
            obj.code = selectedObjectAndClient.code;
            obj.code_type = selectedObjectAndClient.code_type;
            obj.nr_obj = selectedObjectAndClient.nr_obj;
            CLIENT client = new CLIENT();
            client.name = selectedObjectAndClient.name;
            client.fname = selectedObjectAndClient.fname;
            client.lname = selectedObjectAndClient.lname;
            client.tel = selectedObjectAndClient.tel;

            Form form;
            form = new ObjectWindow(null, this, client, obj);
            form.Show();
        }

        private void onSearchClick(object sender, EventArgs e)
        {
            CLIENT newClient = new CLIENT();
            newClient.name = textBox1.Text;
            newClient.fname = textBox2.Text;
            newClient.lname = textBox3.Text;

            OBJECT newObject = new OBJECT();
            if (textBox4.Text.Length != 0)
            {
                newObject.code = textBox4.Text.PadRight(10);
            }
            else
            {
                newObject.code = "";
            }
            newObject.code_type = comboBox1.Text;
            dataGridView1.DataSource = ObjectController.GetObjectsByCriteria(newClient, newObject);
        }

        private void onAddClick(object sender, EventArgs e)
        {
            var selectedObj = (ObjectAndClient)this.dataGridView1.CurrentRow.DataBoundItem;
            OBJECT obj = new OBJECT();
            obj.code = selectedObj.code;
            obj.code_type = selectedObj.code_type;
            obj.nr_obj = selectedObj.nr_obj;
            Form form;
            form = new RequestWindow(obj, null, manager);
            form.Show();
        }
    }
}
