using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNG_DUNG_QUAN_LY_XE_GAN_MAY
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set;}
        public string MoTa { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }
        public decimal Gia { get; set; }
        public int TgBaoHanh { get; set; }
        public string AnhSP { get; set; }
        public string MaLoai { get; set; }
        public int Tongtt => (int)(SoLuong * Gia);
    }
}
