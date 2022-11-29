/*@file         Form2.cs
* @author	    Darren Morrison
* @date         2022-11-27
* @brief        User Interface Exam 2
* @details      Class to handle Form2.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleForms {
    public partial class Form2 : Form {
        frm1 parent;
        bool isSaved = false;
        string prevText = "";
        public Form2(frm1 tOwner) {
            parent = tOwner;
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            if(textBox2.Text != prevText) {
                isSaved = false;
            } else {
                isSaved = true;
            }
            
            this.parent.UpdateCharLength(textBox2.TextLength);
        }

        public void setText(string input) {
            textBox2.Text = input;
            prevText = input;
        }

        public string getText() {
           return textBox2.Text;
        }

        public void setSaved(bool input) {
            isSaved = input;
            if(isSaved) prevText = textBox2.Text;
        }

        public bool getSaved() {
            return isSaved;
        }

        private int textBox2_TextLengthChanged(object sender, EventArgs e) {
            return textBox2.TextLength;
        }
    }
}
