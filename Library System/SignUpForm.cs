using Library_System.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_System
{
    public partial class SignUpForm : Form
    {
        private LibraryContext _dbContext = new LibraryContext();

        public SignUpForm()
        {
            InitializeComponent();
            memberComb.Items.Add("Student");
            memberComb.Items.Add("Faculaty");
            memberComb.Items.Add("Community Member");
        }




        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == "Username")
            {
                txtUserName.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPhone_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPhone.Text == "Phone")
            {
                txtPhone.Clear();
            }

        }

        private void txtAddress_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtAddress.Text == "Address")
            {
                txtAddress.Clear();
            }

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Retrieve data from textboxes
            string name = txtUserName.Text;
            string password = txtPassword.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string memberShip = memberComb.SelectedItem.ToString();

            // Create new instance of Authontication
            Patron patron = new Patron
            {
                Name = name,
                Password = password,
                Address = address,
                Phone = phone,
                MembershipType = memberShip
            };

            // Save to database
            _dbContext.Patron.Add(patron);
            _dbContext.SaveChanges();

            MessageBox.Show("Patron signed up successfully!");
            this.Hide();
            SignIn signIn = new SignIn();
            signIn.ShowDialog();
            this.Close();

        }
       

       

        private void btnLogin2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signIn = new SignIn();
            signIn.ShowDialog();
            this.Close();

        }

        
    }
}
