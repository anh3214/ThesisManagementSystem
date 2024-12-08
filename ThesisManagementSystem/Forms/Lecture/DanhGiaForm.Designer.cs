namespace ThesisManagementSystem.Forms
{
    partial class DanhGiaForm
    {
        /// <summary>
        /// Yêu cầu thiết kế giao diện - không thay đổi.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Khai báo các thành phần giao diện người dùng
        private System.Windows.Forms.Label lblTenMocThoiGian;
        private System.Windows.Forms.Label lblTenNhom;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Label lblNhanXet;
        private System.Windows.Forms.TextBox txtNhanXet;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuyBo;

        /// <summary>
        /// Dọn dẹp tài nguyên được sử dụng.
        /// </summary>
        /// <param name="disposing">true nếu các tài nguyên cần được giải phóng; ngược lại, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Mã do Windows Form Designer tạo

        /// <summary>
        /// Phương thức yêu cầu để hỗ trợ thiết kế giao diện - không chỉnh sửa 
        /// nội dung của phương thức này bằng trình chỉnh sửa mã.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTenMocThoiGian = new System.Windows.Forms.Label();
            this.lblTenNhom = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.lblNhanXet = new System.Windows.Forms.Label();
            this.txtNhanXet = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Set background color and image for the form
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = System.Drawing.Image.FromFile("path_to_your_image.jpg");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            // 
            // lblTenMocThoiGian
            // 
            this.lblTenMocThoiGian.AutoSize = true;
            this.lblTenMocThoiGian.Location = new System.Drawing.Point(25, 20);
            this.lblTenMocThoiGian.Name = "lblTenMocThoiGian";
            this.lblTenMocThoiGian.Size = new System.Drawing.Size(109, 17);
            this.lblTenMocThoiGian.TabIndex = 0;
            this.lblTenMocThoiGian.Text = "Mốc thời gian: ...";

            // 
            // lblTenNhom
            // 
            this.lblTenNhom.AutoSize = true;
            this.lblTenNhom.Location = new System.Drawing.Point(25, 60);
            this.lblTenNhom.Name = "lblTenNhom";
            this.lblTenNhom.Size = new System.Drawing.Size(67, 17);
            this.lblTenNhom.TabIndex = 1;
            this.lblTenNhom.Text = "Nhóm: ...";

            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Location = new System.Drawing.Point(25, 100);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(47, 17);
            this.lblDiem.TabIndex = 2;
            this.lblDiem.Text = "Điểm:";

            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(120, 97);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(100, 22);
            this.txtDiem.TabIndex = 3;

            // 
            // lblNhanXet
            // 
            this.lblNhanXet.AutoSize = true;
            this.lblNhanXet.Location = new System.Drawing.Point(25, 140);
            this.lblNhanXet.Name = "lblNhanXet";
            this.lblNhanXet.Size = new System.Drawing.Size(69, 17);
            this.lblNhanXet.TabIndex = 4;
            this.lblNhanXet.Text = "Nhận xét:";

            // 
            // txtNhanXet
            // 
            this.txtNhanXet.Location = new System.Drawing.Point(120, 137);
            this.txtNhanXet.Multiline = true;
            this.txtNhanXet.Name = "txtNhanXet";
            this.txtNhanXet.Size = new System.Drawing.Size(200, 60);
            this.txtNhanXet.TabIndex = 5;

            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(120, 210);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 30);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(225, 210);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 30);
            this.btnHuyBo.TabIndex = 7;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);

            // 
            // DanhGiaForm
            // 
            this.AcceptButton = this.btnXacNhan;
            this.CancelButton = this.btnHuyBo;
            this.ClientSize = new System.Drawing.Size(350, 260);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtNhanXet);
            this.Controls.Add(this.lblNhanXet);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.lblDiem);
            this.Controls.Add(this.lblTenNhom);
            this.Controls.Add(this.lblTenMocThoiGian);
            this.Name = "DanhGiaForm";
            this.Text = "Đánh giá mốc thời gian";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion
    }
}
