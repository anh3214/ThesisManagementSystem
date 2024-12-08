namespace ThesisManagementSystem.Forms
{
    partial class TaoChinhSuaDeTaiForm
    {
        /// <summary>
        /// Yêu cầu thiết kế giao diện.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Khai báo các thành phần giao diện
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblGiangVien;
        private System.Windows.Forms.ComboBox cmbGiangVien;
        private System.Windows.Forms.Label lblHienThiGiangVien;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Button btnHuyBo;

        /// <summary>
        /// Dọn dẹp các tài nguyên đang sử dụng.
        /// </summary>
        /// <param name="disposing">true nếu các tài nguyên nên được dispose; ngược lại, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Mã hỗ trợ thiết kế giao diện Windows Form

        /// <summary>
        /// Phương thức bắt buộc để hỗ trợ thiết kế giao diện.
        /// Không sửa đổi nội dung phương thức này bằng trình chỉnh sửa mã.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblGiangVien = new System.Windows.Forms.Label();
            this.cmbGiangVien = new System.Windows.Forms.ComboBox();
            this.lblHienThiGiangVien = new System.Windows.Forms.Label();
            this.btnDongY = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(25, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(58, 17);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Tiêu đề:";
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Location = new System.Drawing.Point(150, 17);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(300, 22);
            this.txtTieuDe.TabIndex = 1;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(25, 60);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(45, 17);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(150, 57);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(300, 100);
            this.txtMoTa.TabIndex = 3;
            // 
            // lblGiangVien
            // 
            this.lblGiangVien.AutoSize = true;
            this.lblGiangVien.Location = new System.Drawing.Point(25, 180);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Size = new System.Drawing.Size(138, 17);
            this.lblGiangVien.TabIndex = 4;
            this.lblGiangVien.Text = "Giảng viên phụ trách:";
            // 
            // cmbGiangVien
            // 
            this.cmbGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGiangVien.FormattingEnabled = true;
            this.cmbGiangVien.Location = new System.Drawing.Point(169, 177);
            this.cmbGiangVien.Name = "cmbGiangVien";
            this.cmbGiangVien.Size = new System.Drawing.Size(251, 24);
            this.cmbGiangVien.TabIndex = 5;
            // 
            // lblHienThiGiangVien
            // 
            this.lblHienThiGiangVien.AutoSize = true;
            this.lblHienThiGiangVien.Location = new System.Drawing.Point(25, 180);
            this.lblHienThiGiangVien.Name = "lblHienThiGiangVien";
            this.lblHienThiGiangVien.Size = new System.Drawing.Size(138, 17);
            this.lblHienThiGiangVien.TabIndex = 6;
            this.lblHienThiGiangVien.Text = "Giảng viên phụ trách:";
            this.lblHienThiGiangVien.Visible = false; // Ẩn mặc định
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(150, 220);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(100, 30);
            this.btnDongY.TabIndex = 7;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(350, 220);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(100, 30);
            this.btnHuyBo.TabIndex = 8;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // TaoChinhSuaDeTaiForm
            // 
            this.AcceptButton = this.btnDongY;
            this.CancelButton = this.btnHuyBo;
            this.ClientSize = new System.Drawing.Size(480, 270);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.lblHienThiGiangVien);
            this.Controls.Add(this.cmbGiangVien);
            this.Controls.Add(this.lblGiangVien);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtTieuDe);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "TaoChinhSuaDeTaiForm";
            this.Text = "Thêm/Sửa Đề Tài";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
