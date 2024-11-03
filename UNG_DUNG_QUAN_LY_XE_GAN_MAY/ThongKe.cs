using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Configuration;
using System.Data.SqlClient;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class ThongKe : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            //CREATE TABLE NHANVIEN(
            //MA_NV CHAR(6) PRIMARY KEY, --Mã nhân viên(độ dài tối đa 6 ký tự)
            //TENNV NVARCHAR(100) NOT NULL, --Tên nhân viên
            //GIOITINH NVARCHAR(3) NOT NULL, --Giới tính nhân viên
            //CHUCVU NVARCHAR(50), --Chức vụ
            //SDT_NV CHAR(10), --Số điện thoại nhân viên
            //NGAYSINH DATE, --Ngày sinh
            //DIACHI_NV NVARCHAR(255)-- Địa chỉ nhân viên
            //);
            // lấy tổng số nhân viên
            SqlCommand cmd = new SqlCommand("SELECT COUNT(MA_NV) FROM NHANVIEN", conn);
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(SDT_KH) FROM KHACHHANG", conn);
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(MA_NCC) FROM NHACUNGCAP", conn);
            conn.Open();
            int tongNV = (int)cmd.ExecuteScalar();
            int tongKH = (int)cmd1.ExecuteScalar();
            int tongNCC = (int)cmd2.ExecuteScalar();
            conn.Close();
            lb_slNV.Text = tongNV.ToString();
            lb_slKH.Text = tongKH.ToString();
            lb_slNCC.Text = tongNCC.ToString();

        }

        private void lb_slNCC_Click(object sender, EventArgs e)
        {

        }

        private void lb_Tienchi_Click(object sender, EventArgs e)
        {

        }

        private void lb_Doanhso_Click(object sender, EventArgs e)
        {

        }

        private void lb_slKH_Click(object sender, EventArgs e)
        {

        }

        private void grb_Nguoi_Enter(object sender, EventArgs e)
        {

        }
    }
}
