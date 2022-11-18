namespace FirstGUI {

    public partial class Form1 : Form {
        static int counter;
        public Form1() {
            InitializeComponent();
            counter = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            
        }

        private void btnShowMessage_Click(object sender, EventArgs e) {
            counter++;
            textBox2.Text += "Message Showed\r\n";
            textBox1.BackColor = Color.Green;
            numericUpDown1.Value = counter;
        }

        private void button1_Click(object sender, EventArgs e) {
            counter++;
            textBox2.Text += "Message Showed\r\n";
            textBox1.BackColor = Color.Red;
            numericUpDown1.Value = counter;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            textBox3.Text = "Radio Button 2 selected";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            textBox3.Text = "Radio Button 1 selected";
        }
    }
}