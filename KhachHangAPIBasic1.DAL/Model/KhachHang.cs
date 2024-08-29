using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangAPIBasic1.DAL.Entities
{
    public class KhachHang
    {
        // Các thuộc tính
        private string hoTen;
        private string maKH;
        private int loaiSanPham;
        private double soLuongDaMua;

        // Constructor không tham số
        public KhachHang() { }

        // Constructor có tham số
        public KhachHang(string hoTen, string maKH, int loaiSanPham, double soLuongDaMua)
        {
            this.hoTen = hoTen;
            this.maKH = maKH;
            this.loaiSanPham = loaiSanPham;
            this.soLuongDaMua = soLuongDaMua;
        }

        // Getter & Setter
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
        public virtual void InThongTin()
        {
            double tongChiPhi = TinhTongChiPhi();
            double donGia = loaiSanPham switch
            {
                1 => 50000,
                2 => 70000,
                3 => 100000,
                _ => 0
            };

            Console.WriteLine($"Họ tên: {hoTen}");
            Console.WriteLine($"Mã KH: {maKH}");
            Console.WriteLine($"Loại sản phẩm: {loaiSanPham}");
            Console.WriteLine($"Số lượng đã mua: {soLuongDaMua}");
            Console.WriteLine($"Đơn giá: {donGia}");
            Console.WriteLine($"Tổng chi phí: {tongChiPhi}");
        }
    }
}
