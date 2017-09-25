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
    public partial class ObjectWindow : Form
    {
        CLIENT currClient;
        public ObjectWindow(CLIENT client)
        {
            InitializeComponent();
            if (client != null)
            {
                currClient = client;
                SetValues();
            }
        }

        public void SetValues()
        {
            label4.Text = currClient.name;
            label5.Text = currClient.fname;
            label6.Text = currClient.lname;
        }

        private void onSaveClick(object sender, EventArgs e)
        {
            OBJECT obj = new OBJECT();
            obj.id_cli = currClient.id_client;
            obj.code = textBox1.Text;
            obj.code_type = comboBox1.Text;
            Console.WriteLine(obj.id_cli);
            if (ObjectController.AddNewObject(obj))
            {
                this.Close();
            }
            else {
                MessageBox.Show("The new object has not been added. Try again...", "Operation result",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void onBackClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
