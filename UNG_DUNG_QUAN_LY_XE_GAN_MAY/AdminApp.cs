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
    public partial class frm_AdminApp : Form
    {
        public frm_AdminApp()
        {
            InitializeComponent();
            ThemNhanVien themNhanVien = new ThemNhanVien();
            pn_bg3.Controls.Add(themNhanVien);
            themNhanVien.Dock = DockStyle.Fill;
            themNhanVien.BringToFront();
        }

        private void picb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            ThongKe thongKe = new ThongKe();
            pn_bg3.Controls.Clear();
            pn_bg3.Controls.Add(thongKe);
            thongKe.Dock = DockStyle.Fill;
            thongKe.BringToFront();
        }

        private void themNhanVien1_Load(object sender, EventArgs e)
        {

        }

        private void pn_bg3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pn_bg2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ThemNhanVien themNhanVien = new ThemNhanVien();
            pn_bg3.Controls.Add(themNhanVien);
            themNhanVien.Dock = DockStyle.Fill;
            themNhanVien.BringToFront();
        }

        private void btn_NCC_Click(object sender, EventArgs e)
        {
            NhaCungCap nhaCungCap = new NhaCungCap();
            pn_bg3.Controls.Add(nhaCungCap);
            nhaCungCap.Dock = DockStyle.Fill;
            nhaCungCap.BringToFront();
        }
    }
}
