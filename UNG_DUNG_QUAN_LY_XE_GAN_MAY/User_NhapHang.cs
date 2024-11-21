using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class User_NhapHang : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        private NhanVien CurrentNhanVien;
        private List<HoaDon> hoaDonNhaps = new List<HoaDon>();
        private List<SanPham> sanPhams = new List<SanPham>();
        private List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
        public User_NhapHang(NhanVien currentNhanVien, List<HoaDon> hoaDonNhap, List<SanPham> sanPham, List<NhaCungCap> nhaCungCap)
        {
            InitializeComponent();
            CurrentNhanVien = currentNhanVien;
            sanPhams = sanPham;
            hoaDonNhaps = hoaDonNhap;
            nhaCungCaps = nhaCungCap;
        }
        public string MaHDNew(List<HoaDon> hoaDons)
        {
            if (hoaDons == null || hoaDons.Count == 0)
            {

                return "HDN001";
            }
            string MaMax = hoaDons.OrderByDescending(hd => hd.MaHD).First().MaHD;
            int nextNumber = int.Parse(MaMax.Substring(3)) + 1;
            MaMax = $"HDN{nextNumber.ToString("D3")}";
            return MaMax;
        }
        public void LoadSanPham()
        {
            //LoadSP();
            //if (sanPhams == null || sanPhams.Count == 0)
            //{
            //    MessageBox.Show("Không có sản phẩm nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            dataGridView.DataSource = null;
            dataGridView.DataSource = sanPhams;
            dataGridView.Columns["TenSP"].HeaderText = "Tên SP";
            dataGridView.Columns["SoLuong"].HeaderText = "SL";
            dataGridView.Columns["MaSP"].Visible = false;
            dataGridView.Columns["MoTa"].Visible = false;
            dataGridView.Columns["GiaBan"].Visible = false;
            dataGridView.Columns["GiaNhap"].Visible = false;
            dataGridView.Columns["TgBaoHanh"].Visible = false;
            dataGridView.Columns["AnhSP"].Visible = false;
            dataGridView.Columns["MaLoai"].Visible = false;
        }
        public void LoadNCC()
        {
            foreach(NhaCungCap nha in nhaCungCaps)
            {
                cb_NCC.Items.Add(nha.TenNCC);
            }
            cb_NCC.SelectedIndex = 0;
        }

        private void User_NhapHang_Load(object sender, EventArgs e)
        {
            LoadSanPham();
        }

        private void btn_TaoPN_Click(object sender, EventArgs e)
        {
            string Mamoi = MaHDNew(hoaDonNhaps);
            txt_MaHD1.Text = Mamoi;
            btn_TaoPN.Text = "Tạo Hoá Đơn";
            LoadNCC();
            cb_NCC.Enabled = true;
            btn_TaoPN.BackColor = Color.DarkBlue;
            btn_TaoPN.ForeColor = Color.White;
        }
    }
}
