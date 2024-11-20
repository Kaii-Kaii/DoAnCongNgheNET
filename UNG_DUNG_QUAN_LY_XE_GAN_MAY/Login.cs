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
using System.Net.NetworkInformation;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{

    
    public partial class frm_Login : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        public frm_Login()
        {
            InitializeComponent();
        }
       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }
        


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Application.Exit();
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

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_TDN.Text == "" || txt_Pass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // kiểm tra tài khoản và mật khẩu
            if(txt_TDN.Text == "admin" && txt_Pass.Text == "admin")
            {
                frm_AdminApp frm = new frm_AdminApp();
                this.Hide();
                frm.ShowDialog();
                this.Show();
                return;
            }
            conn.Open();
            string query = "SELECT COUNT(*) FROM TAIKHOAN_NV WHERE MA_NV = @MANV AND PASS = @PASS";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MANV", txt_TDN.Text);
            cmd.Parameters.AddWithValue("@PASS", txt_Pass.Text);
            int result = (int)cmd.ExecuteScalar();
            conn.Close();
            if (result > 0)
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM TAIKHOAN_NV WHERE MA_NV = '" + txt_TDN.Text + "'", conn);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1["IS_ACTIVE"].ToString() == "False")
                {
                    MessageBox.Show("Tài khoản đã bị khóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else 
                {
                    NhanVien nhanVien = new NhanVien
                    {
                        Login = txt_TDN.Text,
                        Pass = txt_Pass.Text
                        // Thêm các thuộc tính khác nếu cần
                    };
                    txt_TDN.Clear();
                    txt_Pass.Clear();
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_UserApp frm = new frm_UserApp(nhanVien);
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                }

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // hello nhen
        // ụaaaa
    }
}
