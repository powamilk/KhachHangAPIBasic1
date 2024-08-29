using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangAPIBasic1.DAL.Entities
{
    public class KhachHang
    {
        private string hoTen;
        private string maKH;
        private int loaiSanPham;
        private double soLuongDaMua;
        public KhachHang() { }
        public KhachHang(string hoTen, string maKH, int loaiSanPham, double soLuongDaMua)
        {
            this.hoTen = hoTen;
            this.maKH = maKH;
            this.loaiSanPham = loaiSanPham;
            this.soLuongDaMua = soLuongDaMua;
        }
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public int LoaiSanPham
        {
            get { return loaiSanPham; }
            set { loaiSanPham = value; }
        }

        public double SoLuongDaMua
        {
            get { return soLuongDaMua; }
            set { soLuongDaMua = value; }
        }
        public virtual double TinhTongChiPhi()
        {
            double donGia = loaiSanPham switch
            {
                1 => 50000,
                2 => 70000,
                3 => 100000,
                _ => 0
            };

            return soLuongDaMua * donGia;
        }
        public virtual string InThongTin()
        {
            double tongChiPhi = TinhTongChiPhi();
            double donGia = loaiSanPham switch
            {
                1 => 50000,
                2 => 70000,
                3 => 100000,
                _ => 0
            };

            return $"Họ tên: {hoTen}\nMã KH: {maKH}\nLoại sản phẩm: {loaiSanPham}\nSố lượng đã mua: {soLuongDaMua}\nĐơn giá: {donGia}\nTổng chi phí: {tongChiPhi}";
        }
    }
}
