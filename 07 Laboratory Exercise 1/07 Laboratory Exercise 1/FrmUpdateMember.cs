using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_Laboratory_Exercise_1
{
    public partial class FrmUpdateMember : Form
    {
        private ClubRegistrationQuery clubregistrationquery;
        private int Age;
        private string Program;
        private long StudentId;
        private int count = 0;
        private string FirstName, MiddleName, LastName, Gender;

        private void cbStudentid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStudentid.SelectedItem != null)
            {
                long selectedStudentID = Convert.ToInt64(cbStudentid.SelectedItem);
                clubregistrationquery.GetStudData(selectedStudentID);
                cbStudentid.Text = clubregistrationquery._StudID.ToString();
                tbLast.Text = clubregistrationquery._LastName;
                tbFirst.Text = clubregistrationquery._FirstName;
                tbMiddle.Text = clubregistrationquery._MiddleName;
                tbAge.Text = clubregistrationquery._Age.ToString();
                cbGender.Text = clubregistrationquery._Gender;
                cbProgram.Text = clubregistrationquery._Program;
            }
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            clubregistrationquery = new ClubRegistrationQuery();
            clubregistrationquery.DisplayStudID(cbStudentid);
        }

        private void btnReguister_Click(object sender, EventArgs e)
        {
            StudentId = Convert.ToInt64(cbStudentid.Text);
            LastName = tbLast.Text;
            FirstName = tbFirst.Text;
            MiddleName = tbMiddle.Text;
            Age = Convert.ToInt32(tbAge.Text);
            Program = cbProgram.Text;
            Gender = cbGender.Text;
            clubregistrationquery.UpdateStudData(StudentId, LastName, FirstName, MiddleName, Age, Program, Gender);
        }

        public FrmUpdateMember()
        {
            InitializeComponent();

        }
    }
}
