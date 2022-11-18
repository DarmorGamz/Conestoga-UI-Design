using System.Text.RegularExpressions;

namespace dmorrison_Exam1 {
    public partial class PlaneSeatReservation : Form {
        public PlaneSeatReservation() {
            InitializeComponent();
        }

        string tempSelectedButton = "";
        struct Passenger {
            public string firstName;
            public string lastName;
            public string postalCode;
            public string buttonName;

            public bool isSorting = false; // Dynamic Override ToString() var.
            public Passenger(string tfirstName, string tlastName, string tpostalCode, string tbutton) {
                this.lastName = tlastName;
                this.firstName = tfirstName;
                this.postalCode = tpostalCode;
                this.buttonName = tbutton;
            }
            public override string ToString() {
                if(isSorting) {
                    return lastName;
                }
                return lastName + ", " + firstName;
            }
        }

        /**
        *  Event Handler for when any seat button is clicked on to.
        *  @param object Sender (button)
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void buttonOnClick(object sender, EventArgs e) {
            // Store selected button
            Button btn = (Button)sender;

            // Iterates through and verifies if button is in list.
            int index = -1;
            foreach(var listBoxItem in lbxReserved.Items) {
                Passenger tmpPassenger = (Passenger)listBoxItem;
                if(tmpPassenger.buttonName == btn.Name) {
                    index = lbxReserved.Items.IndexOf(listBoxItem);
                    break;
                }
            }

            // Highlight list object if it exists.
            ShowBoxes();
            if(index != -1) lbxReserved.SelectedIndex = index;
            else lbxReserved.ClearSelected();
        }

        /**
        *  Event Handler for when any seat button is clicked on to.
        *  @param object Sender (button)
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void buttonEnter(object sender, EventArgs e) {
            // Init vars.
            Button btn = (Button)sender;

            updateBoxColors();
            ShowBoxes();
            // Update selected button.
            tempSelectedButton = btn.Name;

            // Cleanup.
            btn.BackColor = Color.Yellow;
        }

        /**
        *  Event Handler for when any seat button is clicked off of.
        *  @param object Sender (button)
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void buttonLeave(object sender, EventArgs e) {
            // Init vars.
            Button btn = (Button)sender;

            // Cleanup.
            if(lbxReserved.SelectedIndex == -1) {
                btn.BackColor = Color.PaleGreen;
            }
        }

        /**
        *  Event Handler for when btnReserveSeat's is clicked.
        *  @param object Sender btnReserveSeat
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void btnReserveSeat_Click(object sender, EventArgs e) {
            // Verify text entered is valid.
            if(err1.GetError(tbxFirstName) != "" || err1.GetError(tbxLastName) != ""
                || err1.GetError(tbxPostalCode) != "" || tbxFirstName.Text == "" || tbxLastName.Text == "" 
                || tbxPostalCode.Text == "") {
                err1.SetError(btnCancel, "Order is invalid");
                return;
            }
            // Create Passenger struct.
            Passenger tempPassenger = new Passenger(tbxFirstName.Text, tbxLastName.Text, tbxPostalCode.Text, tempSelectedButton);
            
            // Add new item to list.
            lbxReserved.Items.Add(tempPassenger);

            // Update values.
            updateBoxColors();
            HideBoxes();
            lbxReserved.ClearSelected();
            SortListBox();
        }

        /**
        *  Event Handler for when lbxReserved's Index is Changed. 
        *  @param object Sender lbxReserved
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void lbxReserved_SelectedIndexChanged(object sender, EventArgs e) {
            // Bail out if no items are left.
            if(lbxReserved.SelectedIndex == -1) {
                if(tempSelectedButton != "") return;
                HideBoxes();
                updateBoxColors();
                return;
            }

            // Update values.
            updateBoxColors();
            ShowBoxes();
            btnUpdate.Visible = true;
            btnCancelSeat.Visible = true;
            btnCancel.Visible = false;
            btnReserveSeat.Visible = false;

            // Update Passenger values into textboxes for viewing.
            Passenger tmpPassenger = (Passenger)lbxReserved.SelectedItem;
            tbxFirstName.Text = tmpPassenger.firstName;
            tbxLastName.Text = tmpPassenger.lastName;
            tbxPostalCode.Text = tmpPassenger.postalCode;

            // Find button attached to passenger
            Button tempButton = (Button)this.Controls.Find(tmpPassenger.buttonName, true)[0];

            // Update button values.
            tempSelectedButton = tempButton.Name;
            tempButton.BackColor = Color.Yellow;
        }

        /**
        *  Updates all the listbox item's colors.
        *  @return void No return
        */
        private void updateBoxColors() {
            // Iterates through list items and colors the buttons attached to red,
            foreach(var listBoxItem in lbxReserved.Items) {
                Passenger tmpPassenger = (Passenger)listBoxItem;
                Button tempButton = (Button)this.Controls.Find(tmpPassenger.buttonName, true)[0];
                tempButton.BackColor = Color.Tomato;
            }
        }

        /**
        *  Event Handler for when btnCancel's is clicked. Hides the editable boxes and recolors and deselectes.
        *  @param object Sender btnCancel
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void btnCancel_Click(object sender, EventArgs e) {
            // Update Values.
            updateBoxColors();
            HideBoxes();
            lbxReserved.ClearSelected();
        }

        /**
        *  Sort listbox. bool in struct allows dynamic override ToString() to return (Last name) vs (Last + , + FirstName)
        *  @return void No return
        */
        private void SortListBox() {
            // Iterate through Passenger list 0 -> Size. Set isSorting bool to true in struct.
            int iCount = 0;
            while(iCount < lbxReserved.Items.Count) {
                Passenger tmpPassenger = (Passenger)lbxReserved.Items[iCount];
                tmpPassenger.isSorting = true;
                lbxReserved.Items[iCount] = tmpPassenger;
                iCount++;
            }
            // Set false and true to force sort.
            lbxReserved.Sorted = false;
            lbxReserved.Sorted = true;

            // Iterate through Passenger list 0 -> Size. Set isSorting bool to false in struct.
            iCount = 0;
            while(iCount < lbxReserved.Items.Count) {
                Passenger tmpPassenger = (Passenger)lbxReserved.Items[iCount];
                tmpPassenger.isSorting = false;
                lbxReserved.Items[iCount] = tmpPassenger;
                iCount++;
            }
        }

        /**
        *  Hide the boxes,
        *  @return void No return
        */
        private void HideBoxes() {
            // Update values.
            tbxFirstName.Text = "";
            tbxLastName.Text = "";
            tbxPostalCode.Text = "";
            tempSelectedButton = "";

            tbxFirstName.Visible = false;
            tbxLastName.Visible = false;
            tbxPostalCode.Visible = false;
            lblFirstName.Visible = false;
            lblLastName.Visible = false;
            lblPostalCode.Visible = false;
            btnReserveSeat.Visible = false;
            btnCancel.Visible = false;
            btnCancelSeat.Visible = false;
            btnUpdate.Visible = false;

            err1.Clear();
        }

        /**
        *  Show the boxes,
        *  @return void No return
        */
        private void ShowBoxes() {
            // Update values
            tbxFirstName.Text = "";
            tbxLastName.Text = "";
            tbxPostalCode.Text = "";

            tbxFirstName.Visible = true;
            tbxLastName.Visible = true;
            tbxPostalCode.Visible = true;
            lblFirstName.Visible = true;
            lblLastName.Visible = true;
            lblPostalCode.Visible = true;
            btnReserveSeat.Visible = true;
            btnCancel.Visible = true;
            btnCancelSeat.Visible = false;
            btnUpdate.Visible = false;
        }

        /**
        *  Event Handler for when PlaneSeatReservation's is loaded. Ensures edit boxes are hidden. *Not needed.
        *  @param object Sender PlaneSeatReservation
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void PlaneSeatReservation_Load(object sender, EventArgs e) {
            HideBoxes();
        }

        /**
        *  Event Handler for when btnUpdate's is clicked. Updates passenger selected in list.
        *  @param object Sender btnUpdate
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void btnUpdate_Click(object sender, EventArgs e) {
            // Verify textbox values are valid.
            if(err1.GetError(tbxFirstName) != "" || err1.GetError(tbxLastName) != ""
               || err1.GetError(tbxPostalCode) != "" || tbxFirstName.Text == "" || tbxLastName.Text == ""
               || tbxPostalCode.Text == "") {
                err1.SetError(btnCancelSeat, "Order is invalid");
                return;
            }

            // Update Passenger
            Passenger tempPassenger = new Passenger(tbxFirstName.Text, tbxLastName.Text, tbxPostalCode.Text, tempSelectedButton);
            lbxReserved.Items[lbxReserved.SelectedIndex] = tempPassenger;

            // Cleanup
            updateBoxColors();
            HideBoxes();
            lbxReserved.ClearSelected();
            SortListBox();
        }

        /**
        *  Event Handler for when btnCancelSeat's is clicked. Removes passenger from list.
        *  @param object Sender btnCancelSeat
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void btnCancelSeat_Click(object sender, EventArgs e) {
            // Skip if nothing selected, SHOULD NEVER HAPPEN
            if(lbxReserved.SelectedIndex == -1) return;

            // Get Passenger struct from selected item.
            Passenger tmpPassenger = (Passenger)lbxReserved.SelectedItem;

            // Find the button
            Button tempButton = (Button)this.Controls.Find(tmpPassenger.buttonName, true)[0];

            // Set color and remove index.
            tempButton.BackColor = Color.PaleGreen;
            lbxReserved.Items.RemoveAt(lbxReserved.SelectedIndex);

            // Cleanup
            tempSelectedButton = "";
            updateBoxColors();
            HideBoxes();
            lbxReserved.ClearSelected();
        }

        /**
        *  Event Handler for when tbxFirstName's text changes. Sets an error if it doesn't match the REGEX.
        *  @param object Sender tbxFirstName
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void tbxFirstName_TextChanged(object sender, EventArgs e) {
            // Letters only.
            if(!Regex.IsMatch(tbxFirstName.Text, @"^[A-Za-z]+$") && tbxFirstName.Text != "") {
                err1.SetError(tbxFirstName, "Only letters"); // Set Error.
            } else {
                err1.SetError(tbxFirstName, ""); // Clear error.
            }
        }

        /**
        *  Event Handler for when tbxLastName's text changes. Sets an error if it doesn't match the REGEX.
        *  @param object Sender tbxFirstName
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void tbxLastName_TextChanged(object sender, EventArgs e) {
            // Letters only.
            if(!Regex.IsMatch(tbxLastName.Text, @"^[A-Za-z]+$") && tbxLastName.Text != "") {
                err1.SetError(tbxLastName, "Only letters"); // Set Error.
            } else {
                err1.SetError(tbxLastName, ""); // Clear error.
            }
        }

        /**
        *  Event Handler for when tbxPostalCode's text changes. Sets an error if it doesn't match the REGEX.
        *  @param object Sender tbxFirstName
        *  @param EventArgs e Arguments for function call passed with sender.
        *  @return void No return
        */
        private void tbxPostalCode_TextChanged(object sender, EventArgs e) {
            // LDL DLD format
            if(!Regex.IsMatch(tbxPostalCode.Text, @"^[a-zA-Z][0-9][a-zA-Z] [0-9][a-zA-Z][0-9]$") && tbxPostalCode.Text != "") {
                err1.SetError(tbxPostalCode, "LDL DLD format only"); // Set Error.
            }else {
                err1.SetError(tbxPostalCode, ""); // Clear error.
            }
        }
    }
}