using KhachHangAPIBasic1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangAPIBasic1.DAL.Model
{
    public class KhachHangVIP : KhachHang
    {
        public float PhanTramGiamGia { get; set; }

        // Constructor không tham số
        public KhachHangVIP() { }

        // Constructor có tham số
        public KhachHangVIP(string hoTen, string maKH, int loaiSanPham, double soLuongDaMua, float phanTramGiamGia)
            : base(hoTen, maKH, loaiSanPham, soLuongDaMua)
        {
            this.PhanTramGiamGia = phanTramGiamGia;
        }
        public override double TinhTongChiPhi()
        {
            double tongChiPhi = base.TinhTongChiPhi();
            return tongChiPhi * (1 - PhanTramGiamGia / 100);
        }
        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($"Phần trăm giảm giá: {PhanTramGiamGia}%");
        }
    }
}
