using System.ComponentModel;

namespace CustomListApp
{
    public partial class Form1 : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<Customer> Customers { get; set; }
        public Form1()
        {
            InitializeComponent();
            Customers = new BindingList<Customer>
            {
                AllowNew = true,
                AllowRemove = true,
                AllowEdit = false,
            };
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            var newCustomerForm = new CustomerForm();
            if (newCustomerForm.ShowDialog() == DialogResult.OK)
            {
                //code to extract the customer from the form
                //add customer to the list of customers
                Customers.Add(newCustomerForm.GetCustomer());
                //dgvCustomers.DataSource = null;
                //dgvCustomers.DataSource = Customers;

            }

        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            var customerform = new CustomerForm();

            var selectedCustomer = dgvCustomers.CurrentRow?.DataBoundItem as Customer;
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to edit.");
                return;
            }
            customerform.LoadCustomer(selectedCustomer);

            if (customerform.ShowDialog() == DialogResult.OK)
            {
                //update the customer list
                var updatedCustomer = customerform.GetCustomer();
                selectedCustomer.FirstName = updatedCustomer.FirstName;
                selectedCustomer.LastName = updatedCustomer.LastName;
                selectedCustomer.Email = updatedCustomer.Email;
                selectedCustomer.Phone = updatedCustomer.Phone;
                dgvCustomers.Refresh();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = Customers;
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            var isValidSelection = dgvCustomers.CurrentRow?.DataBoundItem is Customer;
            if (isValidSelection)
            {
                btnEditCustomer.Enabled = true;
            }
            else
            {
                btnEditCustomer.Enabled = false;
            }
            //check if the selected item is valid
            //if valid, enable the edit button
            //if not, disable
        }
    }
}
