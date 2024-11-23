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
using System.IO;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public partial class User_NhapHang : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        private NhanVien CurrentNhanVien;
        private List<HoaDon> hoaDonNhaps = new List<HoaDon>();
        private List<SanPham> sanPhams = new List<SanPham>();
        private List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
        private HoaDon hoaDon = new HoaDon();
        public User_NhapHang(NhanVien currentNhanVien, List<HoaDon> hoaDonNhap, List<SanPham> sanPham, List<NhaCungCap> nhaCungCap)
        {
            InitializeComponent();
            CurrentNhanVien = currentNhanVien;
            sanPhams = sanPham;
            hoaDonNhaps = hoaDonNhap;
            nhaCungCaps = nhaCungCap;
        }
        public string MaHDNew(List<HoaDon> hoaDons)
        {
            if (hoaDons == null || hoaDons.Count == 0)
            {

                return "HDN001";
            }
            string MaMax = hoaDons.OrderByDescending(hd => hd.MaHD).First().MaHD;
            int nextNumber = int.Parse(MaMax.Substring(3)) + 1;
            MaMax = $"HDN{nextNumber.ToString("D3")}";
            return MaMax;
        }
        public void LoadSanPham(List<SanPham> sp)
        {
            //LoadSP();
            //if (sanPhams == null || sanPhams.Count == 0)
            //{
            //    MessageBox.Show("Không có sản phẩm nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            dataGridView.DataSource = null;
            dataGridView.DataSource = sp;
            dataGridView.Columns["TenSP"].HeaderText = "Tên SP";
            dataGridView.Columns["SoLuong"].HeaderText = "SL";
            dataGridView.Columns["MaSP"].Visible = false;
            dataGridView.Columns["MoTa"].Visible = false;
            dataGridView.Columns["GiaBan"].Visible = false;
            dataGridView.Columns["GiaNhap"].Visible = false;
            dataGridView.Columns["TgBaoHanh"].Visible = false;
            dataGridView.Columns["AnhSP"].Visible = false;
            dataGridView.Columns["MaLoai"].Visible = false;
        }
        public void LoadNCC()
        {

            foreach (NhaCungCap nha in nhaCungCaps)
            {
                cb_NCC.Items.Add(nha.TenNCC);
            }
            cb_NCC.SelectedIndex = 0;
        }
        public void LoadCB_SP()
        {
            cb_TenHang.Items.Add("");
            foreach (SanPham sanPham in sanPhams)
            {
                cb_TenHang.Items.Add(sanPham.TenSP);
            }
            cb_TenHang.SelectedIndex = 0;
        }
        private void User_NhapHang_Load(object sender, EventArgs e)
        {
            LoadCB_SP();
            LoadSanPham(sanPhams);
            
        }

        private void btn_TaoPN_Click(object sender, EventArgs e)
        {
            if(btn_TaoPN.BackColor == Color.AliceBlue)
            {
                string Mamoi = MaHDNew(hoaDonNhaps);
                txt_MaHD1.Text = Mamoi;
                btn_TaoPN.Text = "Tạo Hoá Đơn";
                LoadNCC();
                cb_NCC.Enabled = true;
                btn_TaoPN.BackColor = Color.DarkBlue;
                btn_TaoPN.ForeColor = Color.White;
            }
            else
            {
                if(cb_NCC==null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult r;
                r = MessageBox.Show($"Bạn có muốn tạo hoá đơn với Nhà Cung Cấp {cb_NCC.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No)
                {
                    return;
                }
                
                hoaDon.MaHD = txt_MaHD1.Text;
                var selectedNCC = nhaCungCaps.FirstOrDefault(t => t.TenNCC == cb_NCC.Text);
                if (selectedNCC != null)
                {
                    hoaDon.MA_NCC = selectedNCC.MaNCC;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btn_TaoPN.BackColor = Color.AliceBlue;
                btn_TaoPN.ForeColor = Color.FromArgb(0, 120, 215);
                txt_MaHD2.Text = hoaDon.MaHD;
                txt_MaHD1.Clear();
                cb_NCC.Text = ""; 
                cb_NCC.Enabled = false;
                LoadCB_SP();
                cb_TenHang.Enabled = true;
                txt_SoLuong.Enabled= true;
            }
           
        }

        private void cb_TenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sanPham = sanPhams.FirstOrDefault(t => t.TenSP == cb_TenHang.Text);
            if (sanPham != null)
            {
                LoadSanPham(sanPhams.Where(t => t.TenSP == sanPham.TenSP).ToList());
                string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagePath = Path.Combine(projectPath, "image_xe", sanPham.AnhSP);

                // Kiểm tra file ảnh tồn tại
                if (File.Exists(imagePath))
                {
                    picb_SanPham.Image = Image.FromFile(imagePath);
                }
                else
                {
                    picb_SanPham.Image = null; // Reset ảnh nếu không tìm thấy
                    MessageBox.Show("Không tìm thấy file ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                picb_SanPham.Image = null; // Reset ảnh nếu không tìm thấy sản phẩm
                LoadSanPham(sanPhams);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SanPham sanPham = new SanPham();
            int i;
            i = dataGridView.CurrentCell.RowIndex;
            sanPham = sanPhams.FirstOrDefault(t => t.MaSP == dataGridView.Rows[i].Cells[0].Value.ToString());
            cb_TenHang.Text = sanPham.TenSP;
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(projectPath, "image_xe", sanPham.AnhSP);
            picb_SanPham.Image = Image.FromFile(imagePath);
        }
    }
}
