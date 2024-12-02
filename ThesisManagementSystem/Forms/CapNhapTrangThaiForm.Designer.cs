namespace ThesisManagementSystem.Forms
{
    partial class CapNhatTrangThaiForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbTrangThai;
        private Label lblTrangThai;
        private Button btnXacNhan;
        private Button btnHuy;

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
            this.cmbTrangThai = new ComboBox();
            this.lblTrangThai = new Label();
            this.btnXacNhan = new Button();
            this.btnHuy = new Button();
            this.SuspendLayout();

            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Location = new Point(100, 20);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new Size(200, 23);
            this.cmbTrangThai.TabIndex = 0;

            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new Point(20, 23);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new Size(68, 15);
            this.lblTrangThai.TabIndex = 1;
            this.lblTrangThai.Text = "Trạng thái:";

            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new Point(124, 60);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new Size(75, 30);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new EventHandler(this.btnXacNhan_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.Location = new Point(205, 60);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(75, 30);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new EventHandler(this.btnHuy_Click);

            // 
            // CapNhatTrangThaiForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(320, 110);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cmbTrangThai);
            this.Name = "CapNhatTrangThaiForm";
            this.Text = "Cập nhật trạng thái đăng ký";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
