using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    
    public partial class User_KhachHang : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        public User_KhachHang()
        {
            InitializeComponent();
        }
        private void User_KhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }
        private void LoadKhachHang()
        {
            try
            {
                // Mở kết nối
                conn.Open();

                // Truy vấn lấy danh sách khách hàng
                string query = "SELECT SDT_KH, TENKH, DIACHI_KH,MAIL FROM KHACHHANG";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                // Đổ dữ liệu vào DataTable
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gắn dữ liệu vào DataGridView
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối
                conn.Close();
            }
        }
        private void ClearTextBoxes()
        {
            txt_SDT.Clear();
            txt_TKH.Clear();
            txt_DiaChi.Clear();
            txt_Mail.Clear();
        }
        private bool IsNumber(string text)
        {
            return text.All(char.IsDigit); // Kiểm tra từng ký tự trong chuỗi có phải số không
        }

        public bool Notnumber(string number)
        {
            return number.All(u => !char.IsDigit(u));
        }
        public bool isemail(string number)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,}$";
            return Regex.IsMatch(number, pattern);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ các cột trong dòng đã click
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ các cột lên TextBox
                txt_SDT.Text = row.Cells["SDT_KH"].Value.ToString(); // Cột SDT_KH
                txt_TKH.Text = row.Cells["TENKH"].Value.ToString();  // Cột TENKH
                txt_DiaChi.Text = row.Cells["DIACHI_KH"].Value.ToString(); // Cột DIACHI_KH
                txt_Mail.Text = row.Cells["MAIL"].Value.ToString(); // Cột MAIL
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ThongTin.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Mở kết nối
                conn.Open();

                // Xác định cột cần tìm kiếm dựa vào giá trị ComboBox
                string column = "";
                switch (cb_KieuTimKiem.SelectedItem.ToString())
                {
                    case "Tên khách hàng":
                        column = "TENKH";
                        break;
                    case "Số điện thoại":
                        column = "SDT_KH";
                        break;
                    case "Email":
                        column = "MAIL";
                        break;
                    case "Địa chỉ":
                        column = "DIACHI_KH";
                        break;
                    default:
                        MessageBox.Show("Vui lòng chọn kiểu tìm kiếm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Truy vấn tìm kiếm
                string query = $"SELECT SDT_KH, TENKH, DIACHI_KH, MAIL FROM KHACHHANG WHERE {column} LIKE @SearchValue";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchValue", "%" + txt_ThongTin.Text.Trim() + "%");

                // Đổ dữ liệu vào DataTable
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gắn dữ liệu vào DataGridView
                dataGridView1.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối
                conn.Close();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đầu vào
                if (string.IsNullOrEmpty(txt_SDT.Text) || string.IsNullOrEmpty(txt_TKH.Text) ||
                    string.IsNullOrEmpty(txt_DiaChi.Text) || string.IsNullOrEmpty(txt_Mail.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Kiểm tra số điện thoại chỉ chứa chữ số
                if (!Regex.IsMatch(txt_SDT.Text, @"^\d+$")) // Chỉ cho phép các ký tự số
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Hàm kiểm tra chuỗi chỉ chứa chữ số

                // Kiểm tra số điện thoại không quá 10 số và chỉ chứa số
                if (!IsNumber(txt_SDT.Text) || txt_SDT.Text.Length != 10) // Điều kiện không hợp lệ
                {
                    MessageBox.Show("Vui lòng nhập đúng số điện thoại (10 chữ số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (!Notnumber(txt_TKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập dung thông tin ho ten!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!isemail(txt_Mail.Text))
                {
                    MessageBox.Show("Vui lòng nhập dung thông tin email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Tạo đối tượng KhachHang
                KhachHang kh = new KhachHang(
                    txt_SDT.Text.Trim(),
                    txt_TKH.Text.Trim(),
                    txt_DiaChi.Text.Trim(),
                    txt_Mail.Text.Trim()
                );

                // Mở kết nối
                conn.Open();

                // Kiểm tra xem số điện thoại đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM KHACHHANG WHERE SDT_KH = @SDT";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@SDT", kh.SDTKH);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Câu lệnh thêm
                string query = "INSERT INTO KHACHHANG (SDT_KH, TENKH, DIACHI_KH, MAIL) VALUES (@SDT, @TenKH, @DiaChi, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SDT", kh.SDTKH);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.Parameters.AddWithValue("@Email", kh.Mail);

                // Thực thi
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    ClearTextBoxes();
                    LoadKhachHang(); // Tải lại danh sách

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đầu vào
                if (string.IsNullOrEmpty(txt_SDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes) return;

                // Tạo đối tượng KhachHang từ dữ liệu nhập vào
                KhachHang khachHang = new KhachHang(txt_SDT.Text.Trim(), txt_TKH.Text.Trim(), txt_DiaChi.Text.Trim(), txt_Mail.Text.Trim());

                // Mở kết nối
                conn.Open();

                // Câu lệnh xóa
                string query = "DELETE FROM KHACHHANG WHERE SDT_KH = @SDT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SDT", khachHang.SDTKH);

                // Thực thi
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    ClearTextBoxes();
                    LoadKhachHang(); // Tải lại danh sách
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đầu vào
                if (string.IsNullOrEmpty(txt_SDT.Text) || string.IsNullOrEmpty(txt_TKH.Text) ||
                    string.IsNullOrEmpty(txt_DiaChi.Text) || string.IsNullOrEmpty(txt_Mail.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng KhachHang mới
                KhachHang kh = new KhachHang(
                    txt_SDT.Text.Trim(),
                    txt_TKH.Text.Trim(),
                    txt_DiaChi.Text.Trim(),
                    txt_Mail.Text.Trim()
                );

                // Mở kết nối
                conn.Open();

                // Câu lệnh sửa
                string query = "UPDATE KHACHHANG SET TENKH = @TENKH, DIACHI_KH = @DiaChi, MAIL = @Email WHERE SDT_KH = @SDT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SDT", kh.SDTKH);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.Parameters.AddWithValue("@Email", kh.Mail);

                // Thực thi
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    ClearTextBoxes();
                    LoadKhachHang(); // Tải lại danh sách

                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        
    }
}
