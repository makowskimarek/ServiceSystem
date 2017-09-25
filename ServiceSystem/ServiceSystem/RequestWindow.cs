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
    public partial class RequestWindow : Form
    {
        OBJECT currObject;
        public RequestWindow(OBJECT obj)
        {
            InitializeComponent();
            currObject = obj;
            InitializeObject();
        }

        public void InitializeObject()
        {
            label6.Text = currObject.code;
            label7.Text = currObject.code_type;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
