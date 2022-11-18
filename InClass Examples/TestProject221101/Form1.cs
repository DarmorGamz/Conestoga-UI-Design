namespace TestProject221101 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if(tbxEnter.Text != "") {
                lbxItems.Items.Add(tbxEnter.Text);
                tbxCount.Text = lbxItems.Items.Count.ToString();
                tbxEnter.Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {
            lbxItems.Items.Clear();
            tbxCount.Text = lbxItems.Items.Count.ToString();
            tbxSelected.Clear();
        }

        private void tbxCount_TextChanged(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void lbxItems_SelectedIndexChanged(object sender, EventArgs e) {
            tbxSelected.Clear();
            if(lbxItems.SelectedItems.Count > 0) {
                foreach(object item in lbxItems.SelectedItems) {
                    tbxSelected.Text += item.ToString() + "\r\n";
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e) {
            lbxItems.Sorted = true;
            lbxItems.Sorted = false;
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            while(lbxItems.SelectedItems.Count > 0) {
                lbxItems.Items.Remove(lbxItems.Items[lbxItems.SelectedIndex]);
            }
            tbxCount.Text = lbxItems.Items.Count.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e) {
            if(lbxItems.SelectedIndex != -1 && lbxItems.Items.Count != 0) {
                lbxItems.Items.Insert(lbxItems.SelectedIndex+1, tbxEnter.Text);
                int selected = lbxItems.SelectedIndex + 1;
                lbxItems.SelectedIndex = -1;
                lbxItems.SelectedIndex = selected;
                tbxCount.Text = lbxItems.Items.Count.ToString();
                tbxEnter.Clear();
            }
        }

        private void tbxEnter_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter && tbxEnter.Text != "") {
                System.Media.SystemSounds.Asterisk.Play();
                lbxItems.Items.Add(tbxEnter.Text);
                tbxCount.Text = lbxItems.Items.Count.ToString();
                tbxEnter.Clear();
            }
        }
    }
}