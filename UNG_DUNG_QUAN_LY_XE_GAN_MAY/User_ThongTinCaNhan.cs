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
    public partial class User_ThongTinCaNhan : UserControl
    {
        private NhanVien CurrentNhanVien;
        private List<HoaDon> hoaDons = new List<HoaDon>();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        public User_ThongTinCaNhan(NhanVien currentNhanVien)
        {
            InitializeComponent();
            CurrentNhanVien = currentNhanVien;
        }
        public void LoadGioiTinh()
        {
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
            cb_GioiTinh.Items.Add("Khác");
            cb_GioiTinh.SelectedIndex = 0;
        }
        public void LoadInfor()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT NHANVIEN.CHUCVU,NHANVIEN.SDT_NV,NHANVIEN.TENNV,NHANVIEN.GIOITINH,NHANVIEN.NGAYSINH,NHANVIEN.DIACHI_NV" +
                                             " FROM NHANVIEN " +
                                             "WHERE MA_NV='" + CurrentNhanVien.Login + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CurrentNhanVien.MaNV = CurrentNhanVien.Login;
                CurrentNhanVien.TenNV = reader["TENNV"].ToString();
                CurrentNhanVien.SDT_NV = reader["SDT_NV"].ToString();
                CurrentNhanVien.ChucVu = reader["CHUCVU"].ToString();
                CurrentNhanVien.GioiTinh = reader["GIOITINH"].ToString();
                CurrentNhanVien.NgaySinh = reader["NGAYSINH"].ToString();
                CurrentNhanVien.DiaChi = reader["DIACHI_NV"].ToString();
            }
            conn.Close();
            conn.Open();
            SqlCommand cmd_HD = new SqlCommand("SELECT MAHD_XUAT,NGAYXUAT " +
                                                "FROM HD_XUAT_BAOHANH " +
                                                "WHERE MA_NV = '" + CurrentNhanVien.Login + "'", conn);
            SqlDataReader readerHD = cmd_HD.ExecuteReader();
            while (readerHD.Read())
            { 
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaHD = readerHD["MAHD_XUAT"].ToString();
                hoaDon.NgayXuat = Convert.ToDateTime(readerHD["NGAYXUAT"]).ToString("yyyy-MM-dd");
                hoaDons.Add(hoaDon);
            }
                conn.Close();
        }
        public void LoadHoaDonXuat() {
            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = hoaDons;
        }
        private void CustomizeGridView()
        {
            dataGridView1.Columns["MaHD"].HeaderText = "Mã Hoá Đơn";
            dataGridView1.Columns["NgayXuat"].HeaderText = "Ngày Xuất";
        }

        private void User_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadGioiTinh();
            LoadInfor();
            LoadHoaDonXuat();
            CustomizeGridView();
            //// Hiển thị thông tin cá nhân từ AppState
            txt_MaNV.Text = CurrentNhanVien.MaNV;
            txt_Pass.Text = CurrentNhanVien.Pass;
            txt_ChucVu.Text= CurrentNhanVien.ChucVu;
            txt_SDT.Text = CurrentNhanVien.SDT_NV;
            txt_TenNV.Text= CurrentNhanVien.TenNV;
            cb_GioiTinh.Text = CurrentNhanVien.GioiTinh;
            dt_NgaySinh.Value=DateTime.Parse(CurrentNhanVien.NgaySinh);
            txt_DiaChi.Text = CurrentNhanVien.DiaChi;
        }

        private void txt_Pass_TextChanged(object sender, EventArgs e)
        {
            txt_Pass.PasswordChar = '●';
        }

        private void chb_Show_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Show.Checked) txt_Pass.PasswordChar = '\0';
            else txt_Pass.PasswordChar = '●';
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            if (btn_ChinhSua.Text == "Chỉnh sửa")
            {

                btn_ChinhSua.Text = "Lưu";
                btn_ChinhSua.BackColor = Color.Red;
                btn_ChinhSua.ForeColor = Color.White;
                txt_Pass.Enabled = true;
                txt_SDT.Enabled = true;
                cb_GioiTinh.Enabled = true;
                txt_DiaChi.Enabled = true;
            }
            else
            {
                DialogResult r;
                r = MessageBox.Show("Bạn có muốn LƯU THÔNG TIN VỪA CHỈNH SỬA?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    return;
                }
                btn_ChinhSua.Text = "Chỉnh sửa";
                btn_ChinhSua.BackColor = Color.AliceBlue;
                btn_ChinhSua.ForeColor = Color.FromArgb(0, 0, 255);
                txt_Pass.Enabled = false;
                txt_SDT.Enabled = false;
                cb_GioiTinh.Enabled = false;
                txt_DiaChi.Enabled = false;
            }
        }
    }
}
