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

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Admin_NhaCungCap : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        public Admin_NhaCungCap()
        {
            InitializeComponent();
            load_data();
            // load danh sách tên nhà cung cấp
            cb_TNCC.Items.Clear();
            string query = "SELECT * FROM NHACUNGCAP";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cb_TNCC.Items.Add(dr["Ten_NCC"].ToString());
            }
            cb_TSP.Items.Clear();
            string query1 = "SELECT * FROM SANPHAM";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                cb_TSP.Items.Add(dr["Ten_SP"].ToString());
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO NHACUNGCAP VALUES(@Ma_NCC, @Ten_NCC)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Ma_NCC", txt_MNCC.Text);
            cmd.Parameters.AddWithValue("@Ten_NCC", txt_TNCC.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM NHACUNGCAP WHERE Ma_NCC = @Ma_NCC";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Ma_NCC", txt_MNCC.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE NHACUNGCAP SET Ten_NCC = @Ten_NCC WHERE Ma_NCC = @Ma_NCC";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Ma_NCC", txt_MNCC.Text);
            cmd.Parameters.AddWithValue("@Ten_NCC", txt_TNCC.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void load_data()
        {
            string query = "SELECT \r\n    NCC.MA_NCC,\r\n    NCC.TEN_NCC,\r\n    SP.TEN_SP,\r\n    CTHD.SL_NHAP,\r\n    CTHD.MA_SP,\r\n    CTHD.GIA_SP\r\nFROM \r\n    NHACUNGCAP NCC\r\nJOIN \r\n    HD_NHAP HD ON NCC.MA_NCC = HD.MA_NCC\r\nJOIN \r\n    CTHD_NHAP CTHD ON HD.MAHD_NHAP = CTHD.MAHD_NHAP\r\nJOIN \r\n    SANPHAM SP ON CTHD.MA_SP = SP.MA_SP;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dữ liệu từ datagridview đưa lên textbox
            int i;
            i = dataGridView1.CurrentRow.Index;
            txt_MNCC.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_TNCC.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            // Lọc dữ liệu theo tên nhà cung cấp
            if (cb_TNCC.Text == "" && cb_TSP.Text == "")
            {
                load_data();
            }
            if(cb_TNCC.Text != "" && cb_TSP.Text == "")
            {
                string query = "SELECT \r\n    NCC.MA_NCC,\r\n    NCC.TEN_NCC,\r\n    SP.TEN_SP,\r\n    CTHD.SL_NHAP,\r\n    CTHD.MA_SP,\r\n    CTHD.GIA_SP\r\nFROM \r\n    NHACUNGCAP NCC\r\nJOIN \r\n    HD_NHAP HD ON NCC.MA_NCC = HD.MA_NCC\r\nJOIN \r\n    CTHD_NHAP CTHD ON HD.MAHD_NHAP = CTHD.MAHD_NHAP\r\nJOIN \r\n    SANPHAM SP ON CTHD.MA_SP = SP.MA_SP\r\nWHERE NCC.TEN_NCC = @Ten_NCC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten_NCC", cb_TNCC.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            // Lọc dữ liệu theo tên sản phẩm
            if (cb_TNCC.Text == "" && cb_TSP.Text != "")
            {
                string query = "SELECT \r\n    NCC.MA_NCC,\r\n    NCC.TEN_NCC,\r\n    SP.TEN_SP,\r\n    CTHD.SL_NHAP,\r\n    CTHD.MA_SP,\r\n    CTHD.GIA_SP\r\nFROM \r\n    NHACUNGCAP NCC\r\nJOIN \r\n    HD_NHAP HD ON NCC.MA_NCC = HD.MA_NCC\r\nJOIN \r\n    CTHD_NHAP CTHD ON HD.MAHD_NHAP = CTHD.MAHD_NHAP\r\nJOIN \r\n    SANPHAM SP ON CTHD.MA_SP = SP.MA_SP\r\nWHERE SP.TEN_SP = @Ten_SP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten_SP", cb_TSP.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            // Lọc dữ liệu theo tên nhà cung cấp và tên sản phẩm
            if (cb_TNCC.Text != "" && cb_TSP.Text != "")
            {
                string query = "SELECT \r\n    NCC.MA_NCC,\r\n    NCC.TEN_NCC,\r\n    SP.TEN_SP,\r\n    CTHD.SL_NHAP,\r\n    CTHD.MA_SP,\r\n    CTHD.GIA_SP\r\nFROM \r\n    NHACUNGCAP NCC\r\nJOIN \r\n    HD_NHAP HD ON NCC.MA_NCC = HD.MA_NCC\r\nJOIN \r\n    CTHD_NHAP CTHD ON HD.MAHD_NHAP = CTHD.MAHD_NHAP\r\nJOIN \r\n    SANPHAM SP ON CTHD.MA_SP = SP.MA_SP\r\nWHERE NCC.TEN_NCC = @Ten_NCC AND SP.TEN_SP = @Ten_SP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten_NCC", cb_TNCC.Text);
                cmd.Parameters.AddWithValue("@Ten_SP", cb_TSP.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
