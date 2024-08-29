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
        public KhachHangVIP() { }

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
        public override string InThongTin()
        {
            return base.InThongTin() + $"\nPhần trăm giảm giá: {PhanTramGiamGia}%";
        }
    }
}
