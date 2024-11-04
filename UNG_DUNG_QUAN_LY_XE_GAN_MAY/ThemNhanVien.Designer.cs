namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    partial class ThemNhanVien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_GioiTinh = new System.Windows.Forms.ComboBox();
            this.lb_GioiTinh = new System.Windows.Forms.Label();
            this.btn_Chitiet = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.dt_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cob_ChucVu = new System.Windows.Forms.ComboBox();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.txt_TenNV = new System.Windows.Forms.TextBox();
            this.trv_NV = new System.Windows.Forms.TreeView();
            this.lb_NV = new System.Windows.Forms.Label();
            this.grb_ShowNV = new System.Windows.Forms.GroupBox();
            this.txt_MaNV = new System.Windows.Forms.TextBox();
            this.lb_Diachi = new System.Windows.Forms.Label();
            this.lb_Ngaysinh = new System.Windows.Forms.Label();
            this.lb_SDT = new System.Windows.Forms.Label();
            this.lb_Chucvu = new System.Windows.Forms.Label();
            this.lb_TenNV = new System.Windows.Forms.Label();
            this.lb_MaNV = new System.Windows.Forms.Label();
            this.grb_Nhanvien = new System.Windows.Forms.GroupBox();
            this.lb_TTK = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lb_MK = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grb_ShowNV.SuspendLayout();
            this.grb_Nhanvien.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_GioiTinh
            // 
            this.cb_GioiTinh.FormattingEnabled = true;
            this.cb_GioiTinh.Location = new System.Drawing.Point(179, 346);
            this.cb_GioiTinh.Name = "cb_GioiTinh";
            this.cb_GioiTinh.Size = new System.Drawing.Size(137, 24);
            this.cb_GioiTinh.TabIndex = 18;
            this.cb_GioiTinh.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lb_GioiTinh
            // 
            this.lb_GioiTinh.AutoSize = true;
            this.lb_GioiTinh.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.lb_GioiTinh.Location = new System.Drawing.Point(205, 312);
            this.lb_GioiTinh.Name = "lb_GioiTinh";
            this.lb_GioiTinh.Size = new System.Drawing.Size(91, 20);
            this.lb_GioiTinh.TabIndex = 17;
            this.lb_GioiTinh.Text = "Giới tính";
            // 
            // btn_Chitiet
            // 
            this.btn_Chitiet.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Chitiet.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Chitiet.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Chitiet.Location = new System.Drawing.Point(241, 607);
            this.btn_Chitiet.Name = "btn_Chitiet";
            this.btn_Chitiet.Size = new System.Drawing.Size(119, 35);
            this.btn_Chitiet.TabIndex = 16;
            this.btn_Chitiet.Text = "Chi Tiết";
            this.btn_Chitiet.UseVisualStyleBackColor = false;
            this.btn_Chitiet.Click += new System.EventHandler(this.btn_Chitiet_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Sua.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Sua.Location = new System.Drawing.Point(19, 607);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(119, 35);
            this.btn_Sua.TabIndex = 15;
            this.btn_Sua.Text = "Sữa";
            this.btn_Sua.UseVisualStyleBackColor = false;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Xoa.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Xoa.Location = new System.Drawing.Point(241, 551);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(119, 35);
            this.btn_Xoa.TabIndex = 14;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Them.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Them.Location = new System.Drawing.Point(19, 551);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(119, 35);
            this.btn_Them.TabIndex = 13;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // dt_NgaySinh
            // 
            this.dt_NgaySinh.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dt_NgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dt_NgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_NgaySinh.Location = new System.Drawing.Point(19, 346);
            this.dt_NgaySinh.Name = "dt_NgaySinh";
            this.dt_NgaySinh.Size = new System.Drawing.Size(147, 24);
            this.dt_NgaySinh.TabIndex = 12;
            // 
            // cob_ChucVu
            // 
            this.cob_ChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cob_ChucVu.FormattingEnabled = true;
            this.cob_ChucVu.Location = new System.Drawing.Point(20, 197);
            this.cob_ChucVu.Name = "cob_ChucVu";
            this.cob_ChucVu.Size = new System.Drawing.Size(352, 26);
            this.cob_ChucVu.TabIndex = 11;
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DiaChi.Location = new System.Drawing.Point(19, 417);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(353, 24);
            this.txt_DiaChi.TabIndex = 10;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SDT.Location = new System.Drawing.Point(20, 260);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(352, 24);
            this.txt_SDT.TabIndex = 8;
            // 
            // txt_TenNV
            // 
            this.txt_TenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenNV.Location = new System.Drawing.Point(19, 125);
            this.txt_TenNV.Name = "txt_TenNV";
            this.txt_TenNV.Size = new System.Drawing.Size(353, 24);
            this.txt_TenNV.TabIndex = 7;
            // 
            // trv_NV
            // 
            this.trv_NV.Location = new System.Drawing.Point(31, 52);
            this.trv_NV.Name = "trv_NV";
            this.trv_NV.Size = new System.Drawing.Size(504, 590);
            this.trv_NV.TabIndex = 2;
            // 
            // lb_NV
            // 
            this.lb_NV.AutoSize = true;
            this.lb_NV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NV.Location = new System.Drawing.Point(27, 18);
            this.lb_NV.Name = "lb_NV";
            this.lb_NV.Size = new System.Drawing.Size(106, 24);
            this.lb_NV.TabIndex = 1;
            this.lb_NV.Text = "Nhân Viên";
            // 
            // grb_ShowNV
            // 
            this.grb_ShowNV.Controls.Add(this.trv_NV);
            this.grb_ShowNV.Controls.Add(this.lb_NV);
            this.grb_ShowNV.Location = new System.Drawing.Point(442, 18);
            this.grb_ShowNV.Name = "grb_ShowNV";
            this.grb_ShowNV.Size = new System.Drawing.Size(569, 662);
            this.grb_ShowNV.TabIndex = 3;
            this.grb_ShowNV.TabStop = false;
            // 
            // txt_MaNV
            // 
            this.txt_MaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaNV.Location = new System.Drawing.Point(19, 52);
            this.txt_MaNV.Name = "txt_MaNV";
            this.txt_MaNV.Size = new System.Drawing.Size(353, 24);
            this.txt_MaNV.TabIndex = 6;
            this.txt_MaNV.Enter += new System.EventHandler(this.txt_MaNV_Enter);
            // 
            // lb_Diachi
            // 
            this.lb_Diachi.AutoSize = true;
            this.lb_Diachi.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.lb_Diachi.Location = new System.Drawing.Point(16, 384);
            this.lb_Diachi.Name = "lb_Diachi";
            this.lb_Diachi.Size = new System.Drawing.Size(76, 20);
            this.lb_Diachi.TabIndex = 5;
            this.lb_Diachi.Text = "Địa Chỉ";
            // 
            // lb_Ngaysinh
            // 
            this.lb_Ngaysinh.AutoSize = true;
            this.lb_Ngaysinh.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.lb_Ngaysinh.Location = new System.Drawing.Point(16, 312);
            this.lb_Ngaysinh.Name = "lb_Ngaysinh";
            this.lb_Ngaysinh.Size = new System.Drawing.Size(103, 20);
            this.lb_Ngaysinh.TabIndex = 4;
            this.lb_Ngaysinh.Text = "Ngày sinh";
            // 
            // lb_SDT
            // 
            this.lb_SDT.AutoSize = true;
            this.lb_SDT.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.lb_SDT.Location = new System.Drawing.Point(16, 237);
            this.lb_SDT.Name = "lb_SDT";
            this.lb_SDT.Size = new System.Drawing.Size(150, 20);
            this.lb_SDT.TabIndex = 3;
            this.lb_SDT.Text = "SĐT Nhân Viên";
            // 
            // lb_Chucvu
            // 
            this.lb_Chucvu.AutoSize = true;
            this.lb_Chucvu.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Chucvu.Location = new System.Drawing.Point(16, 161);
            this.lb_Chucvu.Name = "lb_Chucvu";
            this.lb_Chucvu.Size = new System.Drawing.Size(85, 20);
            this.lb_Chucvu.TabIndex = 2;
            this.lb_Chucvu.Text = "Chức vụ";
            // 
            // lb_TenNV
            // 
            this.lb_TenNV.AutoSize = true;
            this.lb_TenNV.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.lb_TenNV.Location = new System.Drawing.Point(16, 92);
            this.lb_TenNV.Name = "lb_TenNV";
            this.lb_TenNV.Size = new System.Drawing.Size(143, 20);
            this.lb_TenNV.TabIndex = 1;
            this.lb_TenNV.Text = "Tên nhân viên";
            // 
            // lb_MaNV
            // 
            this.lb_MaNV.AutoSize = true;
            this.lb_MaNV.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.lb_MaNV.Location = new System.Drawing.Point(16, 19);
            this.lb_MaNV.Name = "lb_MaNV";
            this.lb_MaNV.Size = new System.Drawing.Size(135, 20);
            this.lb_MaNV.TabIndex = 0;
            this.lb_MaNV.Text = "Mã nhân viên";
            // 
            // grb_Nhanvien
            // 
            this.grb_Nhanvien.Controls.Add(this.cb_GioiTinh);
            this.grb_Nhanvien.Controls.Add(this.lb_GioiTinh);
            this.grb_Nhanvien.Controls.Add(this.btn_Chitiet);
            this.grb_Nhanvien.Controls.Add(this.btn_Sua);
            this.grb_Nhanvien.Controls.Add(this.btn_Xoa);
            this.grb_Nhanvien.Controls.Add(this.btn_Them);
            this.grb_Nhanvien.Controls.Add(this.dt_NgaySinh);
            this.grb_Nhanvien.Controls.Add(this.cob_ChucVu);
            this.grb_Nhanvien.Controls.Add(this.txt_DiaChi);
            this.grb_Nhanvien.Controls.Add(this.txt_SDT);
            this.grb_Nhanvien.Controls.Add(this.txt_TenNV);
            this.grb_Nhanvien.Controls.Add(this.txt_MaNV);
            this.grb_Nhanvien.Controls.Add(this.lb_Diachi);
            this.grb_Nhanvien.Controls.Add(this.lb_Ngaysinh);
            this.grb_Nhanvien.Controls.Add(this.lb_SDT);
            this.grb_Nhanvien.Controls.Add(this.lb_Chucvu);
            this.grb_Nhanvien.Controls.Add(this.lb_TenNV);
            this.grb_Nhanvien.Controls.Add(this.lb_MaNV);
            this.grb_Nhanvien.Location = new System.Drawing.Point(18, 18);
            this.grb_Nhanvien.Name = "grb_Nhanvien";
            this.grb_Nhanvien.Size = new System.Drawing.Size(396, 662);
            this.grb_Nhanvien.TabIndex = 2;
            this.grb_Nhanvien.TabStop = false;
            // 
            // lb_TTK
            // 
            this.lb_TTK.AutoSize = true;
            this.lb_TTK.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TTK.Location = new System.Drawing.Point(15, 458);
            this.lb_TTK.Name = "lb_TTK";
            this.lb_TTK.Size = new System.Drawing.Size(140, 22);
            this.lb_TTK.TabIndex = 19;
            this.lb_TTK.Text = "Tên Tài Khoản";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(181, 458);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 24);
            this.textBox1.TabIndex = 20;
            // 
            // lb_MK
            // 
            this.lb_MK.AutoSize = true;
            this.lb_MK.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold);
            this.lb_MK.Location = new System.Drawing.Point(16, 500);
            this.lb_MK.Name = "lb_MK";
            this.lb_MK.Size = new System.Drawing.Size(97, 22);
            this.lb_MK.TabIndex = 21;
            this.lb_MK.Text = "Mật Khẩu";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(181, 500);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(191, 24);
            this.textBox2.TabIndex = 22;
            // 
            // ThemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grb_ShowNV);
            this.Controls.Add(this.grb_Nhanvien);
            this.Name = "ThemNhanVien";
            this.Size = new System.Drawing.Size(980, 617);
            this.Load += new System.EventHandler(this.ThemNhanVien_Load);
            this.grb_ShowNV.ResumeLayout(false);
            this.grb_ShowNV.PerformLayout();
            this.grb_Nhanvien.ResumeLayout(false);
            this.grb_Nhanvien.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_GioiTinh;
        private System.Windows.Forms.Label lb_GioiTinh;
        private System.Windows.Forms.Button btn_Chitiet;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Them;
        internal System.Windows.Forms.DateTimePicker dt_NgaySinh;
        private System.Windows.Forms.ComboBox cob_ChucVu;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.TextBox txt_TenNV;
        private System.Windows.Forms.TreeView trv_NV;
        private System.Windows.Forms.Label lb_NV;
        private System.Windows.Forms.GroupBox grb_ShowNV;
        private System.Windows.Forms.TextBox txt_MaNV;
        private System.Windows.Forms.Label lb_Diachi;
        private System.Windows.Forms.Label lb_Ngaysinh;
        private System.Windows.Forms.Label lb_SDT;
        private System.Windows.Forms.Label lb_Chucvu;
        private System.Windows.Forms.Label lb_TenNV;
        private System.Windows.Forms.Label lb_MaNV;
        private System.Windows.Forms.GroupBox grb_Nhanvien;
        private System.Windows.Forms.Label lb_TTK;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lb_MK;
    }
}
