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
using System.Security.Cryptography.Xml;

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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(MA_NV) FROM NHANVIEN", conn);
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(SDT_KH) FROM KHACHHANG", conn);
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(MA_NCC) FROM NHACUNGCAP", conn);
            SqlCommand cmd3 = new SqlCommand("SELECT SUM(TONGBILL_XUAT) FROM HD_XUAT_BAOHANH", conn);
            conn.Open();
            int tongNV = (int)cmd.ExecuteScalar();
            int tongKH = (int)cmd1.ExecuteScalar();
            int tongNCC = (int)cmd2.ExecuteScalar();
            decimal tongTienChi = (decimal)cmd3.ExecuteScalar();
            conn.Close();
            lb_slNV.Text = tongNV.ToString();
            lb_slKH.Text = tongKH.ToString();
            lb_slNCC.Text = tongNCC.ToString();
            lb_Tienchi.Text = tongTienChi.ToString();

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
