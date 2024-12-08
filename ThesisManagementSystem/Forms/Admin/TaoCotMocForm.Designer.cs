namespace ThesisManagementSystem.Forms
{
    partial class TaoCotMocForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.DateTimePicker dtpHanChot;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Button btnHuyBo;

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
            this.dtpHanChot = new System.Windows.Forms.DateTimePicker();
            this.btnDongY = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Set background color and image for the form
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = System.Drawing.Image.FromFile("path_to_your_image.jpg");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(12, 12);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(260, 20);
            this.txtTen.TabIndex = 0;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(12, 38);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(260, 60);
            this.txtMoTa.TabIndex = 1;
            // 
            // dtpHanChot
            // 
            this.dtpHanChot.Location = new System.Drawing.Point(12, 104);
            this.dtpHanChot.Name = "dtpHanChot";
            this.dtpHanChot.Size = new System.Drawing.Size(260, 20);
            this.dtpHanChot.TabIndex = 2;
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(116, 130);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 3;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(197, 130);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(75, 23);
            this.btnHuyBo.TabIndex = 4;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // TaoCotMocForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.dtpHanChot);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtTen);
            this.Name = "TaoCotMocForm";
            this.Text = "Tạo Cột Mốc";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
