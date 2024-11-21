using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class frm_UserApp : Form
    {

        private NhanVien CurrentNhanVien;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        private List<HoaDon> hoaDonXuats = new List<HoaDon>();
        private List<HoaDon> hoaDonNhaps = new List<HoaDon>();
        private List<SanPham> sanPhams = new List<SanPham>();
        private List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
        private List<KhachHang> khachHangs = new List<KhachHang>();

        public void LoadHDX()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM HD_XUAT_BAOHANH ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaHD = readerHD["MAHD_XUAT"].ToString();
                hoaDon.SDT_KH = readerHD["SDT_KH"].ToString();
                hoaDon.Ma_NV = readerHD["MA_NV"].ToString();
                hoaDon.TongBill= decimal.Parse(readerHD["TONGBILL_XUAT"].ToString());
                hoaDon.PhuongThucGiaoDich= readerHD["PHUONGTHUCGIAODICH"].ToString();
                hoaDon.Ngay = Convert.ToDateTime(readerHD["NGAYXUAT"]).ToString("dd-MM-yyyy");
                hoaDonXuats.Add(hoaDon);
            }
            conn.Close();
        }
        public void LoadHDN()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM HD_NHAP ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaHD = readerHD["MAHD_NHAP"].ToString();
                hoaDon.MA_NCC = readerHD["MA_NCC"].ToString();
                hoaDon.Ma_NV = readerHD["MA_NV"].ToString();
                hoaDon.TongBill = decimal.Parse(readerHD["TONGBILL_NHAP"].ToString());
                hoaDon.Ngay = Convert.ToDateTime(readerHD["NGAYNHAP"]).ToString("dd-MM-yyyy");
                hoaDonNhaps.Add(hoaDon);
            }
            conn.Close();
        }
        public void LoadSP()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM SANPHAM ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                SanPham sanPham = new SanPham();
                sanPham.MaSP = readerHD["MA_SP"].ToString();
                sanPham.TenSP = readerHD["TEN_SP"].ToString();
                sanPham.MoTa = readerHD["MOTA_SP"].ToString();
                sanPham.SoLuong = int.Parse(readerHD["SOLUONG_SP"].ToString());
                sanPham.GiaBan = decimal.Parse(readerHD["GIA_BAN"].ToString());
                sanPham.GiaNhap = decimal.Parse(readerHD["GIA_NHAP"].ToString());
                sanPham.TgBaoHanh = int.Parse(readerHD["TGBAOHANH"].ToString());
                sanPham.AnhSP = readerHD["ANH_SP"].ToString();
                sanPham.MaLoai = readerHD["MA_LOAI"].ToString();
                sanPhams.Add(sanPham);
            }
            conn.Close();
        }
        public void LoadNCC()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM NHACUNGCAP ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                NhaCungCap nhaCungCap = new NhaCungCap();
                nhaCungCap.MaNCC = readerHD["MA_NCC"].ToString();
                nhaCungCap.TenNCC = readerHD["TEN_NCC"].ToString();
                nhaCungCaps.Add(nhaCungCap);
            }
            conn.Close();
        }
        public void LoadKH()
        {
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT * " +
                                                "FROM KHACHHANG ", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            {
                KhachHang khachHang = new KhachHang();
                khachHang.SDTKH = readerHD["SDT_KH"].ToString();
                khachHang.TenKH = readerHD["TENKH"].ToString();
                khachHang.DiaChi = readerHD["DIACHI_KH"].ToString();
                khachHang.Mail = readerHD["MAIL"].ToString();  
                khachHangs.Add(khachHang);
            }
            conn.Close();
        }
        public frm_UserApp(NhanVien nhanVien)
        {
            InitializeComponent();
            CurrentNhanVien = nhanVien;
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
            User_NhapHang nhapHang = new User_NhapHang(CurrentNhanVien, hoaDonNhaps, sanPhams,nhaCungCaps);
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(nhapHang);
            nhapHang.Dock = DockStyle.Fill;
            nhapHang.BringToFront();
            this.Text = "NHẬP HÀNG";
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            User_HoaDon hoaDon=new User_HoaDon(CurrentNhanVien,hoaDonXuats, sanPhams, khachHangs);
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(hoaDon);
            hoaDon.Dock = DockStyle.Fill;
            hoaDon.BringToFront();
            this.Text = "HOÁ ĐƠN";
        }

        private void btn_TTNV_Click(object sender, EventArgs e)
        {
            User_ThongTinCaNhan ThongTinCaNhan = new User_ThongTinCaNhan(CurrentNhanVien);
            pn_bg2.Controls.Clear();
            pn_bg2.Controls.Add(ThongTinCaNhan);
            ThongTinCaNhan.Dock = DockStyle.Fill;
            ThongTinCaNhan.BringToFront() ;
            this.Text = "THÔNG TIN CÁ NHÂN";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r= MessageBox.Show("Bạn có muốn ĐĂNG XUẤT?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                return; 
            }
            // Xóa thông tin đăng nhập
            if (CurrentNhanVien != null)
            {
                CurrentNhanVien.Login = null;
                CurrentNhanVien.Pass = null;
            }

            // Quay lại form Login
            foreach (Form form in Application.OpenForms)
            {
                if (form is frm_Login loginForm)
                {
                    loginForm.Show(); // Hiển thị lại form Login
                    break;
                }
            }

            this.Close(); // Đóng form UserApp
        }

        private void frm_UserApp_Load(object sender, EventArgs e)
        {
            LoadHDX();
            LoadHDN();
            LoadSP();
            LoadKH();
        }
    }
}
