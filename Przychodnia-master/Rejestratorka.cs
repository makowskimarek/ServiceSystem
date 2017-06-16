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

namespace Przychodnia
{
    public partial class frmRegistration : Form

    {

        Patient patientSearchCriteria;

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            // var result = RegistrationFacade.GetPatients(null);
 
            // budowa kryteriów
            patientSearchCriteria = new Patient();
            patientSearchCriteria.LName = textBox1.Text;

            // ładowanie obiektu dataGridView
            dataGridView1.Columns.Clear();
            // dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = RegistrationFacade.GetPatients(patientSearchCriteria);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Rejestratorka_Load(object sender, EventArgs e)
        {

           
        }
    }
}
