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
    public partial class ActivityWindow : Form
    {

        OBJECT currentObj;
        REQUEST currentReq;
        ACTIVITY currentActivity;
        public ActivityWindow(Mode mode, ACTIVITY activity, OBJECT obj, REQUEST req)
        {
            InitializeComponent();
            if(mode == Mode.WORKER)
            {
                comboBox1.Enabled = false;
                editSequence.Enabled = false;
            }
            if (obj != null)
            {
                currentObj = obj;
                InitializeObjectDetails();
            }
            if (activity != null)
            {
                currentActivity = activity;
            }
            currentReq = req;
            InitializeRequestDetails();

            List<PERSONEL> workers = PersonelController.GetWorkers();
            comboBox1.DataSource = workers;

        }

        public void InitializeObjectDetails()
        {
            label6.Text = currentObj.code;
            label7.Text = currentObj.code_type;
        }

        public void InitializeRequestDetails()
        {
            label2.Text = currentReq.id_req.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            string lastname = ((PERSONEL)e.ListItem).lname;
            string firstname = ((PERSONEL)e.ListItem).fname;
            e.Value = firstname + " " + lastname;
        }

        private void ActivityWindow_Load(object sender, EventArgs e)
        {

        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            ACTIVITY activity = new ACTIVITY();
            activity.id_req = currentReq.id_req;
            PERSONEL pers = (PERSONEL)comboBox1.SelectedItem;
            activity.id_wrk = pers.id_pers;
            switch (comboBox3.Text)
            {
                case "REPAIR":
                    activity.act_type = "REP";
                    break;

                case "DIAGNOSE":
                    activity.act_type = "DIAG";
                    break;
            }
            activity.descr = richTextBox1.Text;
            activity.result = richTextBox2.Text;
            activity.seq_no = int.Parse(editSequence.Text);
            switch (comboBox2.Text)
            {
                case "OPENED":
                    activity.status = "OPEN";
                    break;
                case "PROGRESS":
                    activity.status = "PROG";
                    break;
                case "FINISHED":
                    activity.status = "FIN";
                    break;
                case "CANCELLED":
                    activity.status = "CANC";
                    break;
            }
            activity.dt_req = dateTimePicker1.Value;
            activity.dt_fin_cancel = dateTimePicker2.Value;

            if (ActivityController.AddNewActivity(activity))
            {
                this.Close();
            }
        }
    }
}
