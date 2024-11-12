using System;
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
    public partial class frm_UserApp : Form
    {
        public frm_UserApp()
        {
            InitializeComponent();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            User_KhachHang khachHang = new User_KhachHang();
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(khachHang);
            khachHang.Dock = DockStyle.Fill;
            khachHang.BringToFront();
            this.Text = "KHÁCH HÀNG";
        }

        private void btn_NhapHang_Click(object sender, EventArgs e)
        {
            User_NhapHang nhapHang = new User_NhapHang();
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(nhapHang);
            nhapHang.Dock = DockStyle.Fill;
            nhapHang.BringToFront();
            this.Text = "NHẬP HÀNG";
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            User_HoaDon hoaDon=new User_HoaDon();
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(hoaDon);
            hoaDon.Dock = DockStyle.Fill;
            hoaDon.BringToFront();
            this.Text = "HOÁ ĐƠN";
        }
    }
}
