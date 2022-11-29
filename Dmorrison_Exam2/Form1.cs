/*@file         Form1.cs
* @author	    Darren Morrison
* @date         2022-11-27
* @brief        User Interface Exam 2
* @details      Class to handle Form1.
*/
using System.Drawing.Printing;
using System.Media;

namespace MultipleForms {
    public partial class frm1 : Form {
        public frm1() {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {

        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e) {
            TabPage tabPage = new TabPage();

            Form2 frm = new Form2(this);

            frm.TopLevel = false;
            tabPage.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
            frm.FormBorderStyle = FormBorderStyle.None;
            int iCount = tabControl1.TabCount;
            
            tabPage.Text = "Untitled";
            tabControl1.TabPages.Insert(iCount, tabPage);
            tabControl1.SelectedIndex = iCount;
            this.Text = tabPage.Text;

            UpdateIsSaved(frm.getSaved());
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if(tabControl1.SelectedIndex != -1) {
                Form2 temp = (Form2)tabControl1.SelectedTab.Controls[0];
                UpdateIsSaved(temp.getSaved());
            } else {
                toolStripStatusLabel2.Text = "";
            }
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            if(tabControl1.SelectedIndex != -1) {
                Form2 temp = (Form2)tabControl1.SelectedTab.Controls[0];
                if(!temp.getSaved()) {
                    SystemSounds.Beep.Play();
                    DialogResult res = MessageBox.Show("You're about to close an unsaved file. Do you wish to continue?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if(res == DialogResult.OK) {
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    }
                } else {
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e) {
            if(tabControl1.SelectedIndex != -1) { // TODO This isn't complete. Need to loop through all TabPages and verify none of them are unsaved.
                SystemSounds.Beep.Play();
                DialogResult res = MessageBox.Show("You're about to close all files. Some may be unsaved. Do you wish to continue>", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if(res == DialogResult.OK) {
                    tabControl1.TabPages.Clear();
                }
            }
        }

        private void tabControl1_Click(object sender, EventArgs e) {
            TabPage tp = tabControl1.SelectedTab;
            this.Text = tp.Text;
        }

        private void tabPage1_Click(object sender, EventArgs e) {

        }

        private void tabPage1_DoubleClick(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) {
            if(tabControl1.SelectedIndex != -1) {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDoc = new PrintDocument();

                //PrintPage event to draw the textbox contents on page
                printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

                printDoc.DocumentName = tabControl1.SelectedTab.Text;

                printDialog.Document = printDoc;
                printDialog.AllowSelection = true;

                printDialog.AllowSomePages = true;

                if(printDialog.ShowDialog() == DialogResult.OK)
                    printDoc.Print();
            }
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e) {
            //Font
            Font f = new System.Drawing.Font("Arial", 10, FontStyle.Bold);

            //Brush
            Brush b = new SolidBrush(Color.Black);

            //Where to draw the string
            PointF p = new PointF(10, 10);

            //Draw some strings into the graphics
            Form2 temp = (Form2)tabControl1.SelectedTab.Controls[0];
            e.Graphics.DrawString(temp.getText(), f, b, p);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) {

        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "My open file dialog";
            if(openfile.ShowDialog() == DialogResult.OK) {
                TabPage tabPage = new TabPage();
                Form2 frm = new Form2(this);

                frm.TopLevel = false;
                tabPage.Controls.Add(frm);
                frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.FormBorderStyle = FormBorderStyle.None;
                int iCount = tabControl1.TabCount;
                
                tabPage.Text = openfile.SafeFileName;
                tabPage.Tag = true;
                toolStripStatusLabel2.Text = "Saved";
                tabControl1.TabPages.Insert(iCount, tabPage);
                tabControl1.SelectedIndex = iCount;
                this.Text = openfile.SafeFileName;
                using(StreamReader sr = new StreamReader(openfile.FileName)) {
                    frm.setText(sr.ReadToEnd()); // Sets textbox text.
                    sr.Close();
                }

                frm.setSaved(true); // Sets file to saved.
                UpdateIsSaved(frm.getSaved());
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            // Verify theres a tab selected.
            if(tabControl1.SelectedTab != null) {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Title = "Save file as..";
                savefile.FileName = "untitled";
                savefile.Filter = "Text (*.txt)|*.txt|Word Doc (*.doc)|*.doc"; 
                if(savefile.ShowDialog() == DialogResult.OK) {
                    StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                    Form2 temp = (Form2)tabControl1.SelectedTab.Controls[0];
                    tabControl1.SelectedTab.Text = Path.GetFileName(savefile.FileName); // SafeFilename
                    this.Text = Path.GetFileName(savefile.FileName);

                    txtoutput.Write(temp.getText()); // Gets TextBox text.
                    txtoutput.Close();

                    temp.setSaved(true); // Update to being a saved file.
                    UpdateIsSaved(temp.getSaved());
                }
            }
            
        }
        public void UpdateCharLength(int length) {
            // Updates the status bar. Gets char length from Form2.
            Form2 temp = (Form2)tabControl1.SelectedTab.Controls[0];
            UpdateIsSaved(temp.getSaved());
            toolStripStatusLabel1.Text = "Char Length: " + length;
        }

     
        public void UpdateIsSaved(bool isSaved) {
            // Updates the status bar.
            if(isSaved) {
                toolStripStatusLabel2.Text = "Saved";
            } else {
                toolStripStatusLabel2.Text = "Not Saved";
            }
        }
    }

    
}