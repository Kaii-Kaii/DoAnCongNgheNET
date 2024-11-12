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
    public partial class Admin_ThemNhanVien : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        public Admin_ThemNhanVien()
        {
            InitializeComponent();
        }
        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
            cb_GioiTinh.Items.Add("Khác");
            cb_GioiTinh.SelectedIndex = 0;
            cob_ChucVu.Items.Add("Quản lý");
            cob_ChucVu.Items.Add("Nhân viên bán hàng");
            cob_ChucVu.Items.Add("Nhân viên kỹ thuật");
            cob_ChucVu.SelectedIndex = 0;
            txt_SDT.KeyPress += new KeyPressEventHandler(txt_SDT_KeyPress);
            Load_Treeview();

        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool checkSoDienThoai(string sdt)
        {
            // số đầu tiên là số 0
            if (sdt[0] != '0')
            {
                return false;
            }
            if (sdt.Length != 10)
            {
                return false;
            }
            return true;
        }

        private bool checkNgaySinh(string ngaySinh)
        {
            // lơn hơn 18 tuổi
            DateTime now = DateTime.Now;
            DateTime date = DateTime.Parse(ngaySinh);
            if (now.Year - date.Year < 18)
            {
                return false;
            }
            return true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (txt_MaNV.Text == "" || txt_TenNV.Text == "" || txt_SDT.Text == "" || txt_DiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (checkSoDienThoai(txt_SDT.Text) == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNV = txt_MaNV.Text;
            nhanVien.TenNV = txt_TenNV.Text;
            nhanVien.GioiTinh = cb_GioiTinh.Text;
            nhanVien.ChucVu = cob_ChucVu.Text;
            nhanVien.SDT_NV = txt_SDT.Text;
            nhanVien.NgaySinh = dt_NgaySinh.Value.ToString("yyyy-MM-dd");
            nhanVien.DiaChi = txt_DiaChi.Text;
            if (!checkNgaySinh(nhanVien.NgaySinh))
            {
                MessageBox.Show("Nhân viên phải lớn hơn 18 tuổi");
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
            cb_GioiTinh.SelectedIndex = cob_ChucVu.SelectedIndex = 0;
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO TAIKHOAN_NV VALUES('" + nhanVien.MaNV + "', '" + nhanVien.MaNV + "')", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
            Load_Treeview();
        }

        private void btn_Chitiet_Click(object sender, EventArgs e)
        {
            string MaNV = txt_MaNV.Text;
            if (MaNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN WHERE MA_NV = '" + MaNV + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_TenNV.Text = dr["TENNV"].ToString();
                cb_GioiTinh.Text = dr["GIOITINH"].ToString();
                cob_ChucVu.Text = dr["CHUCVU"].ToString();
                txt_SDT.Text = dr["SDT_NV"].ToString();
                dt_NgaySinh.Value = DateTime.Parse(dr["NGAYSINH"].ToString());
                txt_DiaChi.Text = dr["DIACHI_NV"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên");
            }
            conn.Close();
        }

        private void Load_Treeview()
        {
            // load lên tree view nhân viên theo chức vụ
            string[] ChucVu = { "Quản lý", "Nhân viên bán hàng", "Nhân viên kỹ thuật" };
            trv_NV.Nodes.Clear();
            for (int i = 0; i < ChucVu.Length; i++)
            {
                TreeNode node = new TreeNode(ChucVu[i]);
                trv_NV.Nodes.Add(node);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN WHERE CHUCVU = N'" + ChucVu[i] + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TreeNode node1 = new TreeNode(dr["TENNV"].ToString());
                    node1.Nodes.Add("Mã nhân viên: " + dr["MA_NV"].ToString());
                    node1.Nodes.Add("Giới tính: " + dr["GIOITINH"].ToString());
                    node1.Nodes.Add("Số điện thoại: " + dr["SDT_NV"].ToString());
                    node1.Nodes.Add("Ngày sinh: " + dr["NGAYSINH"].ToString());
                    node1.Nodes.Add("Địa chỉ: " + dr["DIACHI_NV"].ToString());
                    node.Nodes.Add(node1);
                }
                conn.Close();
            }
        }

        private void txt_MaNV_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            // sửa thông tin nhân viên
            string MaNV = txt_MaNV.Text;
            if (MaNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên");
                return;
            }
            conn.Open();
            // cập nhật thông tin nhân viên
            SqlCommand cmd = new SqlCommand("UPDATE NHANVIEN SET TENNV = N'" + txt_TenNV.Text + "', GIOITINH = N'" + cb_GioiTinh.Text + "', CHUCVU = N'" + cob_ChucVu.Text + "', SDT_NV = '" + txt_SDT.Text + "', NGAYSINH = '" + dt_NgaySinh.Value.ToString("yyyy-MM-dd") + "', DIACHI_NV = N'" + txt_DiaChi.Text + "' WHERE MA_NV = '" + MaNV + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sửa thông tin nhân viên thành công");
            Load_Treeview();    
        }
    }
}
