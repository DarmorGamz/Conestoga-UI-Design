namespace TestProject221101 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lbxItems = new System.Windows.Forms.ListBox();
            this.tbxCount = new System.Windows.Forms.TextBox();
            this.tbxSelected = new System.Windows.Forms.TextBox();
            this.tbxEnter = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxItems
            // 
            this.lbxItems.FormattingEnabled = true;
            this.lbxItems.ItemHeight = 15;
            this.lbxItems.Location = new System.Drawing.Point(23, 37);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxItems.Size = new System.Drawing.Size(228, 139);
            this.lbxItems.TabIndex = 0;
            this.lbxItems.SelectedIndexChanged += new System.EventHandler(this.lbxItems_SelectedIndexChanged);
            // 
            // tbxCount
            // 
            this.tbxCount.Location = new System.Drawing.Point(125, 182);
            this.tbxCount.Name = "tbxCount";
            this.tbxCount.PlaceholderText = "0";
            this.tbxCount.ReadOnly = true;
            this.tbxCount.Size = new System.Drawing.Size(100, 23);
            this.tbxCount.TabIndex = 1;
            this.tbxCount.TextChanged += new System.EventHandler(this.tbxCount_TextChanged);
            // 
            // tbxSelected
            // 
            this.tbxSelected.Location = new System.Drawing.Point(475, 95);
            this.tbxSelected.Multiline = true;
            this.tbxSelected.Name = "tbxSelected";
            this.tbxSelected.PlaceholderText = "Selected Item(s)";
            this.tbxSelected.ReadOnly = true;
            this.tbxSelected.Size = new System.Drawing.Size(131, 110);
            this.tbxSelected.TabIndex = 2;
            this.tbxSelected.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tbxEnter
            // 
            this.tbxEnter.Location = new System.Drawing.Point(475, 37);
            this.tbxEnter.Name = "tbxEnter";
            this.tbxEnter.PlaceholderText = "Item for ListBox";
            this.tbxEnter.Size = new System.Drawing.Size(131, 23);
            this.tbxEnter.TabIndex = 3;
            this.tbxEnter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxEnter_KeyUp);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(257, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(257, 66);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(257, 95);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(257, 124);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 7;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(257, 153);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Item Count";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Enter Item";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected Item";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbxEnter);
            this.Controls.Add(this.tbxSelected);
            this.Controls.Add(this.tbxCount);
            this.Controls.Add(this.lbxItems);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbxItems;
        private TextBox tbxCount;
        private TextBox tbxSelected;
        private TextBox tbxEnter;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnInsert;
        private Button btnSort;
        private Button btnClear;
        private Label label2;
        private Label label3;
        private Label label1;
    }
}