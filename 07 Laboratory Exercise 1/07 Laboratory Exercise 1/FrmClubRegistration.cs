using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_Laboratory_Exercise_1
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubregistrationquery = new ClubRegistrationQuery();
        private int ID, Age, Count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentID;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUpdateMember fum = new FrmUpdateMember();
            fum.ShowDialog();
        }

        private void btnReguister_Click(object sender, EventArgs e)
        {
            ID = RegistrationID();
            StudentID = Convert.ToInt64(tbStudID.Text);
            FirstName = tbFirst.Text;
            MiddleName = tbMiddle.Text;
            LastName = tbLast.Text;
            Age = Convert.ToInt32(tbAge.Text);
            Gender = cbGender.Text;
            Program = cbProgram.Text;

            clubregistrationquery.RegisterStudent(ID, StudentID, FirstName,
            MiddleName, LastName, Age, Gender, Program);
        }

        private void RefreshListOfClubMembers()
        {
            clubregistrationquery.DisplayList();
            dataGridView1.DataSource = clubregistrationquery.bindingSource;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        public int RegistrationID()
        {
            return Count++;
        }
        
        public FrmClubRegistration()
        {
            InitializeComponent();
        }

    }
}
