using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    partial class XoaGiangVienForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox lstGiangVien;
        private Button btnXoaGiangVien;
        private Button btnHuy;
        private Label lblGiangVienChon;

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
            this.lstGiangVien = new ListBox();
            this.btnXoaGiangVien = new Button();
            this.btnHuy = new Button();
            this.lblGiangVienChon = new Label();
            this.SuspendLayout();

            // 
            // lblGiangVienChon
            // 
            this.lblGiangVienChon.AutoSize = true;
            this.lblGiangVienChon.Location = new Point(20, 20);
            this.lblGiangVienChon.Name = "lblGiangVienChon";
            this.lblGiangVienChon.Size = new Size(141, 15);
            this.lblGiangVienChon.TabIndex = 0;
            this.lblGiangVienChon.Text = "Giảng Viên Đã Chọn:";

            // 
            // lstGiangVien
            // 
            this.lstGiangVien.FormattingEnabled = true;
            this.lstGiangVien.ItemHeight = 15;
            this.lstGiangVien.Location = new Point(20, 50);
            this.lstGiangVien.Name = "lstGiangVien";
            this.lstGiangVien.SelectionMode = SelectionMode.MultiExtended;
            this.lstGiangVien.Size = new Size(250, 130);
            this.lstGiangVien.TabIndex = 1;

            // 
            // btnXoaGiangVien
            // 
            this.btnXoaGiangVien.Location = new Point(20, 200);
            this.btnXoaGiangVien.Name = "btnXoaGiangVien";
            this.btnXoaGiangVien.Size = new Size(100, 30);
            this.btnXoaGiangVien.TabIndex = 2;
            this.btnXoaGiangVien.Text = "Xóa Giảng Viên";
            this.btnXoaGiangVien.UseVisualStyleBackColor = true;
            this.btnXoaGiangVien.Click += new EventHandler(this.btnXoaGiangVien_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.Location = new Point(170, 200);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(75, 30);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new EventHandler(this.btnHuy_Click);

            // 
            // XoaGiangVienForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 250);
            this.Controls.Add(this.lblGiangVienChon);
            this.Controls.Add(this.lstGiangVien);
            this.Controls.Add(this.btnXoaGiangVien);
            this.Controls.Add(this.btnHuy);
            this.Name = "XoaGiangVienForm";
            this.Text = "Xóa Giảng Viên";
            this.Load += new EventHandler(this.XoaGiangVienForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
