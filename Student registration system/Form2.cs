using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Student_registration_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }
        int updateRow = 0;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();

        }
        private void clear()
        {
            txtName.Text = string.Empty;
            txtContact.Text = "";
            txtEmail.Clear();
            txtAddress.Text = string.Empty;
            cmbFaculty.SelectedIndex = -1;
            cmbGpa.SelectedIndex = -1;

            rdFemale.Checked = false;
            errorAddress.Checked = false;
            rdOthers.Checked = false;
        }

       

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(char.IsDigit(ch)==true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled= true;
            }
        }

        private void txtContact_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtContact.Text) == true)
            {
                txtContact.Focus();
                errorContact.SetError(this.txtContact, "Contact is required");
            }
            else
            {
                errorContact.Clear();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) == true)
            {
                txtName.Focus();
                errorName.SetError(this.txtName, "Full Name is required");
            }
            else
            {
                errorName.Clear();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                errorEmail.Clear();
            else
            {
                errorEmail.SetError(this.txtEmail, "Please enter valid email address");
                txtEmail.Focus();
            }

        }

        private void cmbFaculty_Leave(object sender, EventArgs e)
        {
            if(cmbFaculty.SelectedIndex == -1)
            {
                cmbFaculty.Focus();
                errorFaculty.SetError(this.cmbFaculty, "Select faculty");
            }
            else
            {
                errorFaculty.Clear();
            }
        }

        private void cmbGpa_Leave(object sender, EventArgs e)
        {
            if(cmbGpa.SelectedIndex == -1)
            {
                cmbGpa.Focus();
                errorGrade.SetError(this.cmbGpa, "Select grade");
            }
            else
            {
                errorGrade.Clear();
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAddress.Text) == true) 
            {
                txtAddress.Focus();
                erroradd.SetError(this.txtAddress, "Address is required");

            }
            else
            {
                erroradd.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string gender = string.Empty;

            if (errorAddress.Checked)
                gender = "Male";
            else if (rdFemale.Checked)
                gender = "Female";
            else
                gender = "Other";

            if (btnSave.Text == "Save")
            {

                dgv.Rows.Add(txtName.Text, txtContact.Text, txtEmail.Text, dtp.Text, cmbFaculty.Text, cmbGpa.Text, txtAddress.Text, gender);
                clear();
                MessageBox.Show("New registration is completed");
            }
            else if (btnSave.Text == "Update")
            {
                this.dgv.Rows.RemoveAt(updateRow);
                this.dgv.ClearSelection();
                dgv.Rows.Add(txtName.Text, txtContact.Text, txtEmail.Text, dtp.Text, cmbFaculty.Text, cmbGpa.Text, txtAddress.Text, gender);
                btnSave.Text = "Save";
                updateRow = 0;
                MessageBox.Show("Updated successfully");
            }

            btnClear.PerformClick();


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv.CurrentCell.ColumnIndex;
            string selectedColumnHeader = dgv.CurrentCell.OwningColumn.Name;
            int selectedRow = e.RowIndex;

            if (selectedColumnHeader == "Edit")
            {
                txtName.Text = dgv.Rows[selectedRow].Cells["StudentName"].Value.ToString();
                txtContact.Text = dgv.Rows[selectedRow].Cells["ContactNumber"].Value.ToString();
                txtEmail.Text = dgv.Rows[selectedRow].Cells["Email"].Value.ToString();
                dtp.Text = dgv.Rows[selectedRow].Cells["DOB"].Value.ToString();

                cmbFaculty.Text = dgv.Rows[selectedRow].Cells["Faculty"].Value.ToString();
                cmbGpa.Text = dgv.Rows[selectedRow].Cells["Grade"].Value.ToString();
                txtAddress.Text = dgv.Rows[selectedRow].Cells["Address"].Value.ToString();

                string gender = dgv.Rows[selectedRow].Cells["Gender"].Value.ToString();
                if (gender == "Male")
                    errorAddress.Checked = true;
                else if (gender == "Female")
                    rdFemale.Checked = true;
                else
                    rdOthers.Checked = true;

                btnSave.Text = "Update";
                updateRow = selectedRow;
            }
            else if (selectedColumnHeader.Equals("Delete"))
            {
                if (MessageBox.Show("Do you really want to delete?", "Confirmation !", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.dgv.Rows.RemoveAt(selectedRow);
                    this.dgv.ClearSelection();
                    MessageBox.Show("Deleted Successfully");
                }
            }
        }

        
    }
}

