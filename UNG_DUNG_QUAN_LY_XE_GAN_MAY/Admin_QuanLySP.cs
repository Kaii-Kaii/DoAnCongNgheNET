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

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class Admin_QuanLySP : UserControl
    {
        public Admin_QuanLySP()
        {
            InitializeComponent();
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
                // File.Copy(uploadFileStream.FileName, destPath, true);  // 'true' để ghi đè nếu file đã tồn tại

                // Chỉ gán tên ảnh vào txt_Anh (không bao gồm đường dẫn)
                txt_Anh.Text = uploadFileStream.SafeFileName;
                picb_SanPham.Image = Image.FromFile(destPath);
            }
        }
    }
}