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

        public ActivityWindow(Mode mode, WorkerActivity workerActivity)
        {
            InitializeComponent();
            if(mode == Mode.WORKER)
            {
                comboBoxType.Enabled = false;
                editFirstName.Enabled = false;
                editLastName.Enabled = false;
                editSequence.Enabled = false;
                label2.Text = workerActivity.id_req.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
