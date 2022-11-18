using System.Drawing.Printing;

namespace textboxDialog {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            System.IO.StreamWriter sw = System.IO.File.CreateText("Temp");
            sw.Write(textBox1.Text);
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            PrintDialog PD = new PrintDialog();
            PrintDocument PDoc = new PrintDocument();
            PD.Document = PDoc;

            PDoc.PrintPage += new PrintPageEventHandler(PDoc_PrintPage);

            DialogResult result = PD.ShowDialog();

            if(result == DialogResult.OK) {
                PDoc.Print();
            }
        }
        void PDoc_PrintPage(object sender, PrintPageEventArgs e) {
            Graphics graph = e.Graphics;
            graph.DrawString(textBox1.Text,
                new Font("Arial", 12), new SolidBrush(Color.Black), 10, 10);
        }
    }
}