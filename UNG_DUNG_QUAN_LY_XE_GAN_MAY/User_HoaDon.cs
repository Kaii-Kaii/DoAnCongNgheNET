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
    public partial class User_HoaDon : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        private NhanVien CurrentNhanVien;
        private List<HoaDon> hoaDonXuats = new List<HoaDon>();
        private List<SanPham> sanPhams = new List<SanPham>();
        private List<KhachHang> khachHangs = new List<KhachHang>();

        public User_HoaDon(NhanVien currentNhanVien, List<HoaDon> hoaDonXuat, List<SanPham> sanPham, List<KhachHang> khachHang)
        {
            InitializeComponent();
            CurrentNhanVien = currentNhanVien;
            sanPhams=sanPham;
            hoaDonXuats = hoaDonXuat;
            khachHangs=khachHang;
        }
       
        //public void LoadHDX()
        //{
        //    conn.Open();
        //    SqlCommand cmd_HD = new SqlCommand("SELECT MAHD_XUAT,NGAYXUAT " +
        //                                        "FROM HD_XUAT_BAOHANH " +
        //                                        "WHERE MA_NV = '" + CurrentNhanVien.Login + "'", conn);
        //    SqlDataReader readerHD = cmd_HD.ExecuteReader();
        //    while (readerHD.Read())
        //    {
        //        HoaDon hoaDon = new HoaDon();
        //        hoaDon.MaHD = readerHD["MAHD_XUAT"].ToString();
        //        hoaDon.Ngay = Convert.ToDateTime(readerHD["NGAYXUAT"]).ToString("dd-MM-yyyy");
        //        hoaDonXuats.Add(hoaDon);
        //    }
        //    conn.Close();
        //}
        public string MaHDNew(List<HoaDon> hoaDons)
        {
            if (hoaDons == null || hoaDons.Count == 0)
            {
                
                return "HDX001";
            }
            string MaMax = hoaDons.OrderByDescending(hd => hd.MaHD).First().MaHD;
            int nextNumber = int.Parse(MaMax.Substring(3)) + 1; 
            MaMax = $"HDX{nextNumber.ToString("D3")}"; 
            return MaMax;
        }
        //public void LoadSP()
        //{
        //    conn.Open();
        //    SqlCommand cmd_HD = new SqlCommand("SELECT * " +
        //                                        "FROM SANPHAM ", conn);
        //    SqlDataReader readerHD = cmd_HD.ExecuteReader();
        //    while (readerHD.Read())
        //    {
        //        SanPham sanPham = new SanPham();
        //        sanPham.MaSP = readerHD["MA_SP"].ToString();
        //        sanPham.TenSP = readerHD["TEN_SP"].ToString();
        //        sanPham.MoTa = readerHD["MOTA_SP"].ToString();
        //        sanPham.SoLuong = int.Parse(readerHD["SOLUONG_SP"].ToString());
        //        sanPham.GiaBan = decimal.Parse(readerHD["GIA_BAN"].ToString());
        //        sanPham.GiaNhap = decimal.Parse(readerHD["GIA_NHAP"].ToString());
        //        sanPham.TgBaoHanh = int.Parse(readerHD["TGBAOHANH"].ToString());
        //        sanPham.AnhSP = readerHD["ANH_SP"].ToString();
        //        sanPham.MaLoai = readerHD["MA_LOAI"].ToString();
        //        sanPhams.Add(sanPham);
        //    }
        //    conn.Close();
        //}
        public void LoadSanPham()
        {
            //LoadSP();
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
        public void LoadKH()
        {
            foreach (KhachHang khach in khachHangs)
            {
                cb_SDTKH.Items.Add(khach.SDTKH);
            }
            cb_SDTKH.SelectedIndex = 0;
        }
        private void User_HoaDon_Load(object sender, EventArgs e)
        {
            //LoadHDX();
            LoadSanPham();
        }

        private void btn_TaoHD_Click(object sender, EventArgs e)
        {
            string Mamoi = MaHDNew(hoaDonXuats);
            txt_MaHD1.Text = Mamoi;
            btn_TaoHD.Text = "Tạo Hoá Đơn";
            LoadKH();
            cb_SDTKH.Enabled = true;
            btn_TaoHD.BackColor = Color.DarkBlue;
            btn_TaoHD.ForeColor = Color.White;
        }
    }
}
