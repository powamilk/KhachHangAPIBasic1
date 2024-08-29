using KhachHangAPIBasic1.BUS.Interface;
using KhachHangAPIBasic1.DAL.Entities;
using KhachHangAPIBasic1.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangAPIBasic1.BUS.Implement
{
    public class KhachHangService : IKhachHangService
    {
        public string Nhap(KhachHang khachHang, List<KhachHang> khachHangs)
        {
            if (string.IsNullOrEmpty(khachHang.HoTen) || string.IsNullOrEmpty(khachHang.MaKH))
            {
                throw new ArgumentException("Họ tên và mã khách hàng không được để trống.");
            }

            if (khachHang.LoaiSanPham < 1 || khachHang.LoaiSanPham > 3)
            {
                throw new ArgumentException("Loại sản phẩm chỉ được nhập 1, 2 hoặc 3.");
            }

            if (khachHang.SoLuongDaMua < 0)
            {
                throw new ArgumentException("Số lượng đã mua không được âm.");
            }

            khachHangs.Add(khachHang);
            return "Nhập khách hàng thành công";
        }

        public IEnumerable<KhachHang> Xuat(List<KhachHang> khachHangs)
        {     
           if (!khachHangs.Any())
            {
                return new List<KhachHang>();
            }

            var sortedList = khachHangs
                .OrderBy(kh => kh.MaKH)
                .ThenByDescending(kh => kh.SoLuongDaMua)
                .ToList();
            return sortedList;
        }

        public string XoaKhachHang(string maKH, List<KhachHang> khachHangs)
        {
            var khachHang = khachHangs.FirstOrDefault(kh => kh.MaKH == maKH);
            if (khachHang == null)
            {
                return $"Không thể tìm thấy khách hàng với mã {maKH}";
            }

            khachHangs.Remove(khachHang);
            return $"Khách hàng với mã {maKH} đã bị xóa.";
        }

        public IEnumerable<KhachHang> XuatTheoTongChiPhi(double tuChiPhi, double denChiPhi,List<KhachHang> khachHangs)
        {
            var filteredList = khachHangs
                .Where(kh => kh.TinhTongChiPhi() >= tuChiPhi && kh.TinhTongChiPhi() <= denChiPhi)
                .OrderBy(kh => kh.TinhTongChiPhi())
                .ToList();

            if (!filteredList.Any())
            {
                return new List<KhachHang>();
            }

            return filteredList;
        }

        public KhachHang XuatKhachHangChiPhiCaoNhat(List<KhachHang> khachHangs)
        {
            var khachHang = khachHangs
                .Where(kh => kh.LoaiSanPham == 1)
                .OrderByDescending(kh => kh.TinhTongChiPhi())
                .FirstOrDefault();

            return khachHang;
        }

        public KhachHangVIP ThemKhachHangVIP(KhachHangVIP khachHangVIP, List<KhachHang> khachHangs)
        {
            khachHangs.Add(khachHangVIP);
            return khachHangVIP;
        }
    }
}
