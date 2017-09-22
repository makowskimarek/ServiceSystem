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
    }
}
