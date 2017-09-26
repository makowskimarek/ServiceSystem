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
    public partial class ActivityListWindow : Form
    {
        ActivityController.SearchActivityByObject srchCriteria = new ActivityController.SearchActivityByObject();
        public ActivityListWindow(Mode mode)
        {
            InitializeComponent();
            this.mode = mode;

            if (this.mode == Mode.WORKER)
            {
                buttonClose.Text = "Logout";
                buttonDelete.Hide();
                groupClient.Hide();
                groupWorker.Hide();
                WorkerActivity wrk = new WorkerActivity();
                wrk.id_wrk = 1;
                dataGridView1.DataSource = WorkerActivityFacade.GetAllWorkerActivities(wrk);
            }
        }

        public static String[] GetAllActivityTypesNames()
        {
            return ActivityController.GetAllActivityTypesNames();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if(mode == Mode.MANAGER)
                this.Close();
            else if(mode == Mode.WORKER)
            {
                this.Close();
                Form form;
                form = new Login();
                form.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedActivity = (WorkerActivity)this.dataGridView1.CurrentRow.DataBoundItem;
                Form form;
                if (mode == Mode.MANAGER)
                    form = new ActivityWindow(Mode.MANAGER, selectedActivity);
                else
                    form = new ActivityWindow(Mode.WORKER, selectedActivity);
                form.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("You tried to edit non-selected row", "Dialog",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String objectType = comboBox1.Text;
            String objectName = textBox4.Text;
            String activityName = comboBox2.Text;
            int id_req = Int32.Parse(textBox5.Text);
            srchCriteria = new ActivityController.SearchActivityByObject();
            srchCriteria.act_type = ActivityController.getActivityByName(activityName);
            srchCriteria.id_req = id_req;
            srchCriteria.code_type = objectType;
            srchCriteria.name_type = objectName;
            dataGridView1.DataSource = ActivityController.GetActivityBySearchCriteria(srchCriteria);
        }
    }
}
