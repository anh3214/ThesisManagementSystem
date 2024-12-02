
namespace ThesisManagementSystem.Forms
{
    partial class NopTaiLieuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbCotMoc;
        private System.Windows.Forms.TextBox txtDuongDanTaiLieu;
        private System.Windows.Forms.Button btnNop;
        private System.Windows.Forms.Label lblCotMoc;
        private System.Windows.Forms.Label lblDuongDanTaiLieu;

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
            cmbCotMoc = new ComboBox();
            txtDuongDanTaiLieu = new TextBox();
            btnNop = new Button();
            lblCotMoc = new Label();
            lblDuongDanTaiLieu = new Label();
            SuspendLayout();
            // 
            // cmbCotMoc
            // 
            cmbCotMoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCotMoc.FormattingEnabled = true;
            cmbCotMoc.Location = new Point(140, 35);
            cmbCotMoc.Margin = new Padding(4, 3, 4, 3);
            cmbCotMoc.Name = "cmbCotMoc";
            cmbCotMoc.Size = new Size(233, 23);
            cmbCotMoc.TabIndex = 0;
            // 
            // txtDuongDanTaiLieu
            // 
            txtDuongDanTaiLieu.Location = new Point(140, 81);
            txtDuongDanTaiLieu.Margin = new Padding(4, 3, 4, 3);
            txtDuongDanTaiLieu.Name = "txtDuongDanTaiLieu";
            txtDuongDanTaiLieu.Size = new Size(233, 23);
            txtDuongDanTaiLieu.TabIndex = 1;
            // 
            // btnNop
            // 
            btnNop.Location = new Point(140, 127);
            btnNop.Margin = new Padding(4, 3, 4, 3);
            btnNop.Name = "btnNop";
            btnNop.Size = new Size(88, 27);
            btnNop.TabIndex = 2;
            btnNop.Text = "Nộp";
            btnNop.UseVisualStyleBackColor = true;
            btnNop.Click += btnNop_Click;
            // 
            // lblCotMoc
            // 
            lblCotMoc.AutoSize = true;
            lblCotMoc.Location = new Point(35, 38);
            lblCotMoc.Margin = new Padding(4, 0, 4, 0);
            lblCotMoc.Name = "lblCotMoc";
            lblCotMoc.Size = new Size(56, 15);
            lblCotMoc.TabIndex = 3;
            lblCotMoc.Text = "Cột Mốc:";
            // 
            // lblDuongDanTaiLieu
            // 
            lblDuongDanTaiLieu.AutoSize = true;
            lblDuongDanTaiLieu.Location = new Point(19, 84);
            lblDuongDanTaiLieu.Margin = new Padding(4, 0, 4, 0);
            lblDuongDanTaiLieu.Name = "lblDuongDanTaiLieu";
            lblDuongDanTaiLieu.Size = new Size(113, 15);
            lblDuongDanTaiLieu.TabIndex = 4;
            lblDuongDanTaiLieu.Text = "Đường Dẫn Tài Liệu:";
            // 
            // NopTaiLieuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 185);
            Controls.Add(lblDuongDanTaiLieu);
            Controls.Add(lblCotMoc);
            Controls.Add(btnNop);
            Controls.Add(txtDuongDanTaiLieu);
            Controls.Add(cmbCotMoc);
            Margin = new Padding(4, 3, 4, 3);
            Name = "NopTaiLieuForm";
            Text = "Nộp Tài Liệu";
            Load += NopTaiLieuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}