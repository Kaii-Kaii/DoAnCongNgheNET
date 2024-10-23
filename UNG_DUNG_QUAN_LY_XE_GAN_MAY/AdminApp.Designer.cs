namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    partial class frm_AdminApp
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
            this.pn_bg2 = new System.Windows.Forms.Panel();
            this.picb_exit = new System.Windows.Forms.PictureBox();
            this.lb_br2 = new System.Windows.Forms.Label();
            this.pn_bg1 = new System.Windows.Forms.Panel();
            this.btn_DeXuat = new System.Windows.Forms.Button();
            this.btn_ThongKe = new System.Windows.Forms.Button();
            this.lb_br3 = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.pn_bg3 = new System.Windows.Forms.Panel();
            this.pn_bg2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_exit)).BeginInit();
            this.pn_bg1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_bg2
            // 
            this.pn_bg2.BackColor = System.Drawing.Color.Navy;
            this.pn_bg2.Controls.Add(this.picb_exit);
            this.pn_bg2.Controls.Add(this.lb_br2);
            this.pn_bg2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_bg2.Location = new System.Drawing.Point(0, 0);
            this.pn_bg2.Name = "pn_bg2";
            this.pn_bg2.Size = new System.Drawing.Size(1200, 43);
            this.pn_bg2.TabIndex = 2;
            this.pn_bg2.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_bg2_Paint);
            // 
            // picb_exit
            // 
            this.picb_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picb_exit.Image = global::UNG_DUNG_QUAN_LY_XE_GAN_MAY.Properties.Resources.Cancel;
            this.picb_exit.Location = new System.Drawing.Point(1163, 7);
            this.picb_exit.Name = "picb_exit";
            this.picb_exit.Size = new System.Drawing.Size(34, 27);
            this.picb_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picb_exit.TabIndex = 16;
            this.picb_exit.TabStop = false;
            this.picb_exit.Click += new System.EventHandler(this.picb_exit_Click);
            // 
            // lb_br2
            // 
            this.lb_br2.AutoSize = true;
            this.lb_br2.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_br2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_br2.Location = new System.Drawing.Point(45, 7);
            this.lb_br2.Name = "lb_br2";
            this.lb_br2.Size = new System.Drawing.Size(133, 27);
            this.lb_br2.TabIndex = 5;
            this.lb_br2.Text = "CHÀO MỪNG";
            // 
            // pn_bg1
            // 
            this.pn_bg1.BackColor = System.Drawing.Color.DarkBlue;
            this.pn_bg1.Controls.Add(this.btn_DeXuat);
            this.pn_bg1.Controls.Add(this.btn_ThongKe);
            this.pn_bg1.Controls.Add(this.lb_br3);
            this.pn_bg1.Controls.Add(this.btn_Them);
            this.pn_bg1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_bg1.Location = new System.Drawing.Point(0, 43);
            this.pn_bg1.Name = "pn_bg1";
            this.pn_bg1.Size = new System.Drawing.Size(220, 617);
            this.pn_bg1.TabIndex = 3;
            // 
            // btn_DeXuat
            // 
            this.btn_DeXuat.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_DeXuat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_DeXuat.Location = new System.Drawing.Point(12, 256);
            this.btn_DeXuat.Name = "btn_DeXuat";
            this.btn_DeXuat.Size = new System.Drawing.Size(180, 37);
            this.btn_DeXuat.TabIndex = 8;
            this.btn_DeXuat.Text = "Đề Xuất";
            this.btn_DeXuat.UseVisualStyleBackColor = false;
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_ThongKe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ThongKe.Location = new System.Drawing.Point(12, 164);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(180, 37);
            this.btn_ThongKe.TabIndex = 7;
            this.btn_ThongKe.Text = "Thống kê";
            this.btn_ThongKe.UseVisualStyleBackColor = false;
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // lb_br3
            // 
            this.lb_br3.AutoSize = true;
            this.lb_br3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_br3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_br3.Location = new System.Drawing.Point(68, 16);
            this.lb_br3.Name = "lb_br3";
            this.lb_br3.Size = new System.Drawing.Size(71, 22);
            this.lb_br3.TabIndex = 6;
            this.lb_br3.Text = "ADMIN";
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Them.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Them.Location = new System.Drawing.Point(12, 72);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(180, 37);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm nhân viên";
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // pn_bg3
            // 
            this.pn_bg3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_bg3.Location = new System.Drawing.Point(220, 43);
            this.pn_bg3.Name = "pn_bg3";
            this.pn_bg3.Size = new System.Drawing.Size(980, 617);
            this.pn_bg3.TabIndex = 4;
            this.pn_bg3.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_bg3_Paint);
            // 
            // frm_AdminApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 660);
            this.Controls.Add(this.pn_bg3);
            this.Controls.Add(this.pn_bg1);
            this.Controls.Add(this.pn_bg2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "frm_AdminApp";
            this.Text = "AdminApp";
            this.pn_bg2.ResumeLayout(false);
            this.pn_bg2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_exit)).EndInit();
            this.pn_bg1.ResumeLayout(false);
            this.pn_bg1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_bg2;
        private System.Windows.Forms.Label lb_br2;
        private System.Windows.Forms.Panel pn_bg1;
        private System.Windows.Forms.Button btn_DeXuat;
        private System.Windows.Forms.Button btn_ThongKe;
        private System.Windows.Forms.Label lb_br3;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.PictureBox picb_exit;
        private System.Windows.Forms.Panel pn_bg3;
    }
}