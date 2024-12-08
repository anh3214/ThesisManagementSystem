using System.Windows.Forms;

namespace ThesisManagementSystem.Forms
{
    partial class ChinhSuaTaiLieuForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTaiLieuHienTai;
        private TextBox txtTaiLieuHienTai;
        private Label lblTaiLieuMoi;
        private TextBox txtTaiLieuMoi;
        private Button btnLuu;
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
            lblTaiLieuHienTai = new Label();
            txtTaiLieuHienTai = new TextBox();
            lblTaiLieuMoi = new Label();
            txtTaiLieuMoi = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();

            SuspendLayout();

            // Set background color and image for the form
            this.BackColor = System.Drawing.Color.LightYellow;
            this.BackgroundImage = System.Drawing.Image.FromFile("path_to_your_image.jpg");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            // 
            // lblTaiLieuHienTai
            // 
            lblTaiLieuHienTai.AutoSize = true;
            lblTaiLieuHienTai.Location = new Point(12, 15);
            lblTaiLieuHienTai.Name = "lblTaiLieuHienTai";
            lblTaiLieuHienTai.Size = new Size(107, 15);
            lblTaiLieuHienTai.TabIndex = 0;
            lblTaiLieuHienTai.Text = "Tài liệu hiện tại:";

            // 
            // txtTaiLieuHienTai
            // 
            txtTaiLieuHienTai.Location = new Point(125, 12);
            txtTaiLieuHienTai.Name = "txtTaiLieuHienTai";
            txtTaiLieuHienTai.ReadOnly = true;
            txtTaiLieuHienTai.Size = new Size(300, 23);
            txtTaiLieuHienTai.TabIndex = 1;

            // 
            // lblTaiLieuMoi
            // 
            lblTaiLieuMoi.AutoSize = true;
            lblTaiLieuMoi.Location = new Point(12, 50);
            lblTaiLieuMoi.Name = "lblTaiLieuMoi";
            lblTaiLieuMoi.Size = new Size(87, 15);
            lblTaiLieuMoi.TabIndex = 3;
            lblTaiLieuMoi.Text = "Tài liệu mới URL:";

            // 
            // txtTaiLieuMoi
            // 
            txtTaiLieuMoi.Location = new Point(125, 47);
            txtTaiLieuMoi.Name = "txtTaiLieuMoi";
            txtTaiLieuMoi.Size = new Size(300, 23);
            txtTaiLieuMoi.TabIndex = 4;

            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(125, 85);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 23);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;

            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(206, 85);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(75, 23);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;

            // 
            // ChinhSuaTaiLieuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 120);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtTaiLieuMoi);
            Controls.Add(lblTaiLieuMoi);
            Controls.Add(txtTaiLieuHienTai);
            Controls.Add(lblTaiLieuHienTai);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChinhSuaTaiLieuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chỉnh sửa tài liệu";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
