using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Admin_QuanLySP : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        //CREATE TABLE LOAISANPHAM(
        //MA_LOAI CHAR(7) PRIMARY KEY,  -- Mã loại sản phẩm(độ dài tối đa 10 ký tự)
        //TENLOAI NVARCHAR(100) NOT NULL     -- Tên loại sản phẩm(độ dài tối đa 100 ký tự)
        //);
        //    CREATE TABLE SANPHAM(
        //MA_SP CHAR(6) PRIMARY KEY,  -- Mã sản phẩm(độ dài tối đa 6 ký tự)
        //TEN_SP NVARCHAR(100) NOT NULL, -- Tên sản phẩm
        //MOTA_SP NVARCHAR(255),  -- Mô tả sản phẩm
        //SOLUONG_SP INT NOT NULL,  -- Số lượng sản phẩm
        //GIA_BAN DECIMAL(18,2) NOT NULL,  -- Giá bán
        //GIA_NHAP DECIMAL(18,2) NOT NULL,  -- Giá nhập
        //TGBAOHANH INT NOT NULL,  -- Thời gian bảo hành(tháng)
        //ANH_SP NVARCHAR(200),
        //MA_LOAI CHAR(7) NOT NULL,  -- Mã loại sản phẩm
        //);

        public Admin_QuanLySP()
        {
            InitializeComponent();
            Load_data();
            // load danh sách tên loại sản phẩm
            cob_Loai.Items.Clear();
            string query = "SELECT * FROM LOAISANPHAM";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cob_Loai.Items.Add(dr["TENLOAI"].ToString());
            }
        }

        private void btn_OpenPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadFileStream = new OpenFileDialog();
            uploadFileStream.InitialDirectory = "D:\\Ky_04_2024_2025\\CongNgheNet\\DoAnCongNgheNET\\UNG_DUNG_QUAN_LY_XE_GAN_MAY\\image_xe\\";
            uploadFileStream.Filter = "Image Files|*.png;*.jpg;*.jpeg";
            uploadFileStream.FilterIndex = 1;

            if (uploadFileStream.ShowDialog() == DialogResult.OK)
            {
                // Đường dẫn đến thư mục image_xe
                string imageXeDir = @"D:\Ky_04_2024_2025\CongNgheNet\DoAnCongNgheNET\UNG_DUNG_QUAN_LY_XE_GAN_MAY\image_xe";

                // Kiểm tra và tạo thư mục image_xe nếu chưa tồn tại
                if (!Directory.Exists(imageXeDir))
                {
                    Directory.CreateDirectory(imageXeDir);
                }

                // Đường dẫn đầy đủ của file đích
                string destPath = Path.Combine(imageXeDir, uploadFileStream.SafeFileName);

                // Sao chép file vào thư mục image_xe
                File.Copy(uploadFileStream.FileName, destPath, true);  // 'true' để ghi đè nếu file đã tồn tại

                // Chỉ gán tên ảnh vào txt_Anh (không bao gồm đường dẫn)
                txt_Anh.Text = uploadFileStream.SafeFileName;
                picb_SanPham.Image = Image.FromFile(destPath);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Load_data()
        {
            // load thông tin sản phẩm lên datagridview gồm cả tên loại sản phẩm
            string query = "SELECT SP.MA_SP, SP.TEN_SP, SP.MOTA_SP, SP.SOLUONG_SP, SP.GIA_BAN, SP.GIA_NHAP, SP.TGBAOHANH, LSP.TENLOAI, SP.ANH_SP FROM SANPHAM SP JOIN LOAISANPHAM LSP ON SP.MA_LOAI = LSP.MA_LOAI";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            // ẩn cột hình ảnh
            dataGridView.Columns[8].Visible = false;
        }

        private void Admin_QuanLySP_Load(object sender, EventArgs e)
        {
            // load danh sách sảm phẩm lên datagridview
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dữ liệu từ datagridview đưa lên textbox
            int i;
            i = dataGridView.CurrentRow.Index;
            SanPham sp = new SanPham();
            sp.MaSP = txt_MSP.Text = dataGridView.Rows[i].Cells[0].Value.ToString();
            sp.TenSP = txt_TenSP.Text = dataGridView.Rows[i].Cells[1].Value.ToString();
            cob_Loai.Text = dataGridView.Rows[i].Cells[7].Value.ToString();
            txt_TGBH.Text = dataGridView.Rows[i].Cells[6].Value.ToString();
            // bỏ số .00 ở cuối
            txt_GiaXuat.Text = dataGridView.Rows[i].Cells[4].Value.ToString().Split('.')[0];
            txt_GiaNhap.Text = dataGridView.Rows[i].Cells[5].Value.ToString().Split('.')[0];
            txt_Anh.Text = dataGridView.Rows[i].Cells[8].Value.ToString();
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(projectPath, "image_xe", dataGridView.Rows[i].Cells[8].Value.ToString());
            picb_SanPham.Image = Image.FromFile(imagePath);

        }

        // khi bấm esc thì clear các textbox
        private void Admin_QuanLySP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txt_MSP.Text = "";
                txt_TenSP.Text = "";
                cob_Loai.Text = "";
                txt_TGBH.Text = "";
                txt_GiaXuat.Text = "";
                txt_GiaNhap.Text = "";
                txt_Anh.Text = "";
                picb_SanPham.Image = null;
            }
        }
    }
}