namespace Demo4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstBoxDepartments = new ListBox();
            txtDptName = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lstBoxDepartments
            // 
            lstBoxDepartments.FormattingEnabled = true;
            lstBoxDepartments.Location = new Point(606, 25);
            lstBoxDepartments.Name = "lstBoxDepartments";
            lstBoxDepartments.Size = new Size(150, 404);
            lstBoxDepartments.TabIndex = 0;
            lstBoxDepartments.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // txtDptName
            // 
            txtDptName.Location = new Point(132, 111);
            txtDptName.Name = "txtDptName";
            txtDptName.Size = new Size(231, 27);
            txtDptName.TabIndex = 1;
            txtDptName.TextChanged += textBox1_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(148, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(125, 35);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Department Name";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(txtDptName);
            Controls.Add(lstBoxDepartments);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstBoxDepartments;
        private TextBox txtDptName;
        private Button btnSave;
    }
}
