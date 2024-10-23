using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class frm_Login : Form
    {
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
            txt_Pass.PasswordChar = '*';
        }

        private void chb_Show_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Show.Checked) txt_Pass.PasswordChar = '\0';
            else txt_Pass.PasswordChar = '*';
        }
        // hello nhen
        // ụaaaa
    }
}
