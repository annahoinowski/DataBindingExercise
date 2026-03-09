using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomListApp
{
    public partial class CustomerForm : Form
    {
        private Customer _customer;
        //public CustomerForm(Customer data)
        //{
        //    InitializeComponent();
        //    _customer = data;
        //}

        public CustomerForm()
        {
            InitializeComponent();
            _customer = new Customer();
        }

        public void LoadCustomer(Customer customer)
        {
            _customer = customer;
        }

        public Customer GetCustomer()
        {
            return _customer;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            txtFirstName.DataBindings.Add("Text", _customer, "FirstName");
            txtLastName.DataBindings.Add("Text", _customer, "LastName");
            txtEmail.DataBindings.Add("Text", _customer, "Email");
            txtPhone.DataBindings.Add("Text", _customer, "Phone");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validate logic here
            //does the form has first name, last name, etc
            //should have at least phone number or email
            if (Validators.ContainsValue(txtFirstName.Text) == false) 
            {
                MessageBox.Show("Please enter a first name.")
                return;
            }
            if (Validators.ContainsValue(txtLastName.Text) == false)
            {
                MessageBox.Show("Please enter a last name.")
                return;
            }
            if (Validators.ContainsValue(txtEmail.Text) == false && 
                Validators.ContainsValue(txtPhone.Text == false)
            {
                MessageBox.Show("Please enter an email or a password.")
                return;
            }
            if(Validators.ContainsValue(txtEmail.Text) &&
                Validators.IsValidEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Please enter a valid email address.")
                return;
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
