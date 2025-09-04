namespace Demo4
{
    partial class Form3
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
            gvStudents = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)gvStudents).BeginInit();
            SuspendLayout();
            // 
            // gvStudents
            // 
            gvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvStudents.Location = new Point(12, 0);
            gvStudents.Name = "gvStudents";
            gvStudents.RowHeadersWidth = 51;
            gvStudents.Size = new Size(1350, 481);
            gvStudents.TabIndex = 0;
            gvStudents.CellContentClick += gvStudents_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(328, 543);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1391, 687);
            Controls.Add(button1);
            Controls.Add(gvStudents);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)gvStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gvStudents;
        private Button button1;
    }
}