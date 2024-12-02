namespace ThesisManagementSystem.Forms
{
    partial class RemoveLecturerForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox lstLecturers;
        private Button btnRemove;
        private Button btnCancel;
        private Label lblLecturers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstLecturers = new ListBox();
            this.btnRemove = new Button();
            this.btnCancel = new Button();
            this.lblLecturers = new Label();
            this.SuspendLayout();

            // 
            // lblLecturers
            // 
            this.lblLecturers.AutoSize = true;
            this.lblLecturers.Location = new Point(20, 20);
            this.lblLecturers.Name = "lblLecturers";
            this.lblLecturers.Size = new Size(84, 15);
            this.lblLecturers.TabIndex = 0;
            this.lblLecturers.Text = "Selected Lecturers:";

            // 
            // lstLecturers
            // 
            this.lstLecturers.FormattingEnabled = true;
            this.lstLecturers.ItemHeight = 15;
            this.lstLecturers.Location = new Point(20, 50);
            this.lstLecturers.Name = "lstLecturers";
            this.lstLecturers.SelectionMode = SelectionMode.MultiExtended;
            this.lstLecturers.Size = new Size(250, 130);
            this.lstLecturers.TabIndex = 1;

            // 
            // btnRemove
            // 
            this.btnRemove.Location = new Point(20, 200);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new Size(75, 30);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new EventHandler(this.btnRemove_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(195, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // 
            // RemoveLecturerForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 250);
            this.Controls.Add(this.lblLecturers);
            this.Controls.Add(this.lstLecturers);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCancel);
            this.Name = "RemoveLecturerForm";
            this.Text = "Remove Lecturer";
            this.Load += new EventHandler(this.RemoveLecturerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
