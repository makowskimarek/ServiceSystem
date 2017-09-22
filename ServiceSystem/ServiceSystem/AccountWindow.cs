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
    public partial class AccountWindow : Form
    {
        public AccountWindow()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AccountController.Account new_account = new AccountController.Account();
            new_account.first_name = textBox3.Text;
            new_account.last_name = textBox4.Text;
            new_account.username = textBox1.Text;
            new_account.password = textBox2.Text;
            new_account.retire_date = dateTimePicker1.Value;
            new_account.role = comboBox2.SelectedItem.ToString();
            if (comboBox2.SelectedIndex == 0)
            {
                new_account.role = "adm";
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                new_account.role = "man";
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                new_account.role = "wrk";
            }

            if (AccountController.NewAccount(new_account))
            {
                MessageBox.Show("New account has been registered", "Account registration",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBox.Show("New account has not been registered. Try again...", "Account registration",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            
        }
    }
}
