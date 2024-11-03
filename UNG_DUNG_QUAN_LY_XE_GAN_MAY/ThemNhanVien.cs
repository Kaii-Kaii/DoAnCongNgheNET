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
using System.Security.Cryptography.Xml;
using System.Windows.Input;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class ThemNhanVien : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        public ThemNhanVien()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
            cb_GioiTinh.Items.Add("Khác");
            cb_GioiTinh.SelectedIndex = 0;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNV = txt_MaNV.Text;
            nhanVien.TenNV = txt_TenNV.Text;
            nhanVien.GioiTinh = cb_GioiTinh.Text;
            nhanVien.ChucVu = cob_ChucVu.Text;
            nhanVien.SDT_NV = txt_SDT.Text;
            nhanVien.NgaySinh = dt_NgaySinh.Value.ToString("yyyy-MM-dd");
            nhanVien.DiaChi = txt_DiaChi.Text;
            if(nhanVien.MaNV == "" || nhanVien.TenNV == "" || nhanVien.SDT_NV == "" || nhanVien.DiaChi == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN WHERE MA_NV = '" + nhanVien.MaNV + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
                conn.Close();
                return;
            }
            conn.Close();
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO NHANVIEN VALUES('" + nhanVien.MaNV + "', N'" + nhanVien.TenNV + "', N'" + nhanVien.GioiTinh + "', N'" + nhanVien.ChucVu + "', '" + nhanVien.SDT_NV + "', '" + nhanVien.NgaySinh + "', N'" + nhanVien.DiaChi + "')", conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Thêm nhân viên thành công");
            txt_MaNV.Text = txt_DiaChi.Text = txt_SDT.Text = txt_TenNV.Text = "";
            cb_GioiTinh.SelectedIndex = cb_GioiTinh.SelectedIndex = 0;
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO TAIKHOAN_NV VALUES('" + nhanVien.MaNV + "', '" + nhanVien.MaNV + "')", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }

        private void btn_Chitiet_Click(object sender, EventArgs e)
        {
            // load lên tree view nhân viên
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            trv_NV.Nodes.Clear();
            //CREATE TABLE NHANVIEN(
            //MA_NV CHAR(6) PRIMARY KEY, --Mã nhân viên(độ dài tối đa 6 ký tự)
            //TENNV NVARCHAR(100) NOT NULL, --Tên nhân viên

            //GIOITINH NVARCHAR(3) NOT NULL, --Giới tính nhân viên
            //CHUCVU NVARCHAR(50), --Chức vụ
            //SDT_NV CHAR(10), --Số điện thoại nhân viên
            //NGAYSINH DATE, --Ngày sinh
            //DIACHI_NV NVARCHAR(255)-- Địa chỉ nhân viên
            while (dr.Read())
            {
                TreeNode node = new TreeNode(dr["MA_NV"].ToString());
                node.Nodes.Add("Tên nhân viên: " + dr["TENNV"].ToString());
                node.Nodes.Add("Giới tính: " + dr["GIOITINH"].ToString());
                node.Nodes.Add("Chức vụ: " + dr["CHUCVU"].ToString());
                node.Nodes.Add("Số điện thoại: " + dr["SDT_NV"].ToString());
                node.Nodes.Add("Ngày sinh: " + dr["NGAYSINH"].ToString());
                node.Nodes.Add("Địa chỉ: " + dr["DIACHI_NV"].ToString());
                trv_NV.Nodes.Add(node);
            }
            conn.Close();

        }
    }
}
