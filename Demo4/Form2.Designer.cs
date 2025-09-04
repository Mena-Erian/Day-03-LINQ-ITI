namespace Demo4
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstBoxDept = new ListBox();
            lblDptdId = new Label();
            txtDptName = new TextBox();
            numUpDownCapacity = new NumericUpDown();
            chkStatus = new CheckBox();
            btnSave = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            btnLast = new Button();
            ((System.ComponentModel.ISupportInitialize)numUpDownCapacity).BeginInit();
            SuspendLayout();
            // 
            // lstBoxDept
            // 
            lstBoxDept.FormattingEnabled = true;
            lstBoxDept.Location = new Point(900, 23);
            lstBoxDept.Name = "lstBoxDept";
            lstBoxDept.Size = new Size(321, 404);
            lstBoxDept.TabIndex = 0;
            // 
            // lblDptdId
            // 
            lblDptdId.AutoSize = true;
            lblDptdId.Location = new Point(71, 49);
            lblDptdId.Name = "lblDptdId";
            lblDptdId.Size = new Size(112, 20);
            lblDptdId.TabIndex = 1;
            lblDptdId.Text = "Department ID ";
            lblDptdId.Click += label1_Click;
            // 
            // txtDptName
            // 
            txtDptName.Location = new Point(71, 102);
            txtDptName.Name = "txtDptName";
            txtDptName.Size = new Size(259, 27);
            txtDptName.TabIndex = 2;
            // 
            // numUpDownCapacity
            // 
            numUpDownCapacity.Location = new Point(71, 178);
            numUpDownCapacity.Name = "numUpDownCapacity";
            numUpDownCapacity.Size = new Size(200, 27);
            numUpDownCapacity.TabIndex = 3;
            // 
            // chkStatus
            // 
            chkStatus.AutoSize = true;
            chkStatus.Location = new Point(71, 267);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(71, 24);
            chkStatus.TabIndex = 4;
            chkStatus.Text = "Status";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(80, 337);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(170, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(89, 414);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 6;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += button1_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(236, 414);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 29);
            btnPrevious.TabIndex = 7;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnFirst
            // 
            btnFirst.BackgroundImageLayout = ImageLayout.Center;
            btnFirst.Location = new Point(378, 414);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(94, 29);
            btnFirst.TabIndex = 8;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(513, 414);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(94, 29);
            btnLast.TabIndex = 9;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 599);
            Controls.Add(btnLast);
            Controls.Add(btnFirst);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(btnSave);
            Controls.Add(chkStatus);
            Controls.Add(numUpDownCapacity);
            Controls.Add(txtDptName);
            Controls.Add(lblDptdId);
            Controls.Add(lstBoxDept);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)numUpDownCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstBoxDept;
        private Label lblDptdId;
        private TextBox txtDptName;
        private NumericUpDown numUpDownCapacity;
        private CheckBox chkStatus;
        private Button btnSave;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
        private Button btnLast;
    }
}