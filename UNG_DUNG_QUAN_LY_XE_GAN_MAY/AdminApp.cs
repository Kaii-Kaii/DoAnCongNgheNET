﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class frm_AdminApp : Form
    {
        public frm_AdminApp()
        {
            InitializeComponent();
            //ThemNhanVien themNhanVien = new ThemNhanVien();
            //pn_bg3.Controls.Add(themNhanVien);
            //themNhanVien.Dock = DockStyle.Fill;
            //themNhanVien.BringToFront();
        }
        
        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            Admin_ThongKe thongKe = new Admin_ThongKe();
            pn_bg3.Controls.Clear();
            pn_bg3.Controls.Add(thongKe);
            thongKe.Dock = DockStyle.Fill;
            thongKe.BringToFront();
            this.Text = "THỐNG KÊ";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Admin_ThemNhanVien themNhanVien = new Admin_ThemNhanVien();
            pn_bg3.Controls.Add(themNhanVien);
            themNhanVien.Dock = DockStyle.Fill;
            themNhanVien.BringToFront();
            this.Text = "QUẢN LÝ NHÂN VIÊN";
        }

        private void btn_NCC_Click(object sender, EventArgs e)
        {
            Admin_NhaCungCap nhaCungCap = new Admin_NhaCungCap();
            pn_bg3.Controls.Add(nhaCungCap);
            nhaCungCap.Dock = DockStyle.Fill;
            nhaCungCap.BringToFront();
            this.Text = "QUẢN LÝ NHÀ CUNG CẤP";
        }

        private void btn_QLSP_Click(object sender, EventArgs e)
        {
            Admin_QuanLySP quanLySP = new Admin_QuanLySP();
            pn_bg3.Controls.Add(quanLySP);
            quanLySP.Dock = DockStyle.Fill;
            quanLySP.BringToFront();
            this.Text = "QUẢN LÝ SẢN PHẦM";
        }
    }
}
