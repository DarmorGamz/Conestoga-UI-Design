using System.Text.RegularExpressions;

namespace Dmorrison_Assignment4 {
    
    public partial class OrderSystem : Form {
        public OrderSystem() {
            InitializeComponent();
        }
        public void ClearOrder() {
            // Clears all info entered.
            tbxCustomerName2.Text = string.Empty;
            tbxPhoneNumber2.Text = string.Empty;
            nmuProduct1Quantity.Value = 0;
            nmuProduct2Quantity.Value = 0;

            // Reset radio buttons
            rdbPickUp.Checked = false;
            rdbDelivery.Checked = true;

            // Reset datepicker and text box.
            dtp2.Visible = false;
            tbxPostalCode2.Visible = true;
            tbxPostalCode2.Text = string.Empty;

            tbxReceipt2.Text = string.Empty;

            btnNewOrder.Visible = false;
            btnCancel2.Visible = true;
            btnConfirm.Visible = true;
        }


        private void tbxCustomerName2_TextChanged(object sender, EventArgs e) {
            if(!Regex.IsMatch(tbxCustomerName2.Text, @"^[A-Za-z ]+$") && tbxCustomerName2.Text != "") {
                errName.SetError(tbxCustomerName2, "Only letters and whitespace");
            }
            else {
                errName.Clear();
            }
        }

        private void tbxPhoneNumber2_TextChanged(object sender, EventArgs e) {
            if(!Regex.IsMatch(tbxPhoneNumber2.Text, @"^[0-9]{10}$") && tbxPhoneNumber2.Text != "") {
                errPhoneNumber.SetError(tbxPhoneNumber2, "Only 10 digit format");
            }
            else {
                errPhoneNumber.Clear();
            }
        }

        private void tbxPostalCode2_TextChanged(object sender, EventArgs e) {
            if(!Regex.IsMatch(tbxPostalCode2.Text, @"^[a-zA-Z][0-9][a-zA-Z] [0-9][a-zA-Z][0-9]$") && tbxPostalCode2.Text != "") {
                errPostalCode.SetError(tbxPostalCode2, "LDL DLD format only");
                Console.WriteLine("here");
            }
            else {
                errPostalCode.Clear();
            }
        }

        private void tbxCustomerName2_KeyPress(object sender, KeyPressEventArgs e) {
            if(errName.GetError(tbxCustomerName2) == "" || e.KeyChar == (char)8) {
                return;
            }
            else {
                e.Handled = true;
            }
        }

        private void tbxPhoneNumber2_KeyPress(object sender, KeyPressEventArgs e) {
            if((e.KeyChar == (char)8) || Regex.IsMatch(tbxPhoneNumber2.Text, @"^[0-9]{0,9}$")) {
                return;
            }
            else {
                e.Handled = true;
            }
        }

        private void rdbDelivery_CheckedChanged(object sender, EventArgs e) {
            dtp2.Visible = false;
            tbxPostalCode2.Visible = true;
            lblPostalCode2.Text = "Postal Code";
        }

        private void rdbPickUp_CheckedChanged(object sender, EventArgs e) {
            tbxPostalCode2.Visible = false;
            lblPostalCode2.Text = "Pick-Up time";
            dtp2.Visible = true;
        }

        private void btnCancel2_Click(object sender, EventArgs e) {
            ClearOrder();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            if(errName.GetError(tbxCustomerName2) != "" || errOrder.GetError(tbxPhoneNumber2) != "" 
                || errPostalCode.GetError(tbxPostalCode2) != "" || tbxCustomerName2.Text == "" || tbxPhoneNumber2.Text == "") {
                errOrder.SetError(btnConfirm, "Order is invalid1");
                return; 
            }
            if(rdbDelivery.Checked && tbxPostalCode2.Text == "") {
                errOrder.SetError(btnConfirm, "Order is invalid2");
                return;
            }

            errOrder.Clear();
            btnNewOrder.Visible = true;
            btnCancel2.Visible = false;
            btnConfirm.Visible = false;
            if(rdbDelivery.Checked) {
                Order Delivery = new Delivery(tbxCustomerName2.Text, tbxPhoneNumber2.Text, (int)nmuProduct1Quantity.Value, (int)nmuProduct2Quantity.Value, tbxPostalCode2.Text);
                tbxReceipt2.Text = Delivery.PrintRecipt();
            } else if(rdbPickUp.Checked) {
                Order Pickup = new Pickup(tbxCustomerName2.Text, tbxPhoneNumber2.Text, (int)nmuProduct1Quantity.Value, (int)nmuProduct2Quantity.Value, dtp2.Value.ToString());
                tbxReceipt2.Text = Pickup.PrintRecipt();
            }

        }

        private void btnNewOrder_Click(object sender, EventArgs e) {
            ClearOrder();
        }
    }
}