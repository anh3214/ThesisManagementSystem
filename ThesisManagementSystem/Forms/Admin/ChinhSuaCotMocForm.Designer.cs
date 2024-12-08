namespace ThesisManagementSystem.Forms
{
    partial class ChinhSuaMocThoiGianForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.DateTimePicker dtpHanNop;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;

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
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.dtpHanNop = new System.Windows.Forms.DateTimePicker();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(12, 12);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(260, 20);
            this.txtTen.TabIndex = 0;
            this.txtTen.BackColor = System.Drawing.Color.LightYellow;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(12, 38);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(260, 60);
            this.txtMoTa.TabIndex = 1;
            this.txtMoTa.BackColor = System.Drawing.Color.LightCyan;
            // 
            // dtpHanNop
            // 
            this.dtpHanNop.Location = new System.Drawing.Point(12, 104);
            this.dtpHanNop.Name = "dtpHanNop";
            this.dtpHanNop.Size = new System.Drawing.Size(260, 20);
            this.dtpHanNop.TabIndex = 2;
            this.dtpHanNop.CalendarMonthBackground = System.Drawing.Color.LightPink;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(116, 130);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 23);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            this.btnXacNhan.BackColor = System.Drawing.Color.LightGreen;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(197, 130);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnHuy.BackColor = System.Drawing.Color.LightCoral;
            // 
            // ChinhSuaMocThoiGianForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dtpHanNop);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtTen);
            this.Name = "ChinhSuaMocThoiGianForm";
            this.Text = "Chỉnh sửa mốc thời gian";
            this.BackColor = System.Drawing.Color.LightGray;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
