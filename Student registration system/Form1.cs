using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_registration_system
{
    public partial class Form1 : Form
    {
        public static Form1 newform; 
        public Form1()
        {
            InitializeComponent();
            newform = this;
           // Application.Run(new Form2());
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                errorProvider1.SetError(txtUsername, "Username Is Rewuired");
                txtUsername.Focus();
            }
            else
            {
                errorProvider1.SetError(txtUsername, string.Empty);
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider2.SetError(txtPassword, "Password Is Required");
                txtPassword.Focus();
            }
            else
            {
                errorProvider2.SetError(txtPassword, string.Empty);
            }

            if (txtUsername.Text == "Student" && txtPassword.Text == "student")
            {
                //MessageBox.Show("Login successful");
                Form2 form = new Form2();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("please enter valid username and password");
            }
        }
              

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtUsername.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtUsername.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtUsername.Paste();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                btnLogin.BackColor = cd.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnLogin.ForeColor = cd.Color;
            }
        }

        private void fontStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                btnLogin.Font = fd.Font;
            }
        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cmsClear_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnClear.BackColor = cd.Color;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                btnClear.Font = fd.Font;
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnClear.ForeColor = cd.Color;
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        
    }
}
