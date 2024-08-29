using KhachHangAPIBasic1.BUS.Interface;
using KhachHangAPIBasic1.DAL.Entities;
using KhachHangAPIBasic1.DAL.Model;
using KhachHangAPIBasic1.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangAPIBasic1.BUS.Implement
{
    public class KhachHangService : IKhachHangService
    {
        private readonly IKhachHangRepo _khachHangRepo;

        public KhachHangService(IKhachHangRepo khachHangRepo)
        {
            _khachHangRepo = khachHangRepo;
        }

        public void Nhap(KhachHang khachHang)
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

            _khachHangRepo.Add(khachHang);
        }

        public void Xuat()
        {
            var khachHangs = _khachHangRepo.GetAll();

            if (!khachHangs.Any())
            {
                Console.WriteLine("Hiện chưa có khách hàng");
                return;
            }

            var sortedList = khachHangs
                .OrderBy(kh => kh.MaKH)
                .ThenByDescending(kh => kh.SoLuongDaMua)
                .ToList();

            foreach (var khachHang in sortedList)
            {
                khachHang.InThongTin();
                Console.WriteLine();
            }
        }

        public void XoaKhachHang(string maKH)
        {
            var khachHang = _khachHangRepo.GetById(maKH);
            if (khachHang == null)
            {
                Console.WriteLine($"Không thể tìm thấy khách hàng với mã {maKH}");
                return;
            }

            _khachHangRepo.Delete(maKH);
            Console.WriteLine($"Khách hàng với mã {maKH} đã bị xóa.");
        }

        public void XuatTheoTongChiPhi(double tuChiPhi, double denChiPhi)
        {
            var khachHangs = _khachHangRepo.GetAll();

            var filteredList = khachHangs
                .Where(kh => kh.TinhTongChiPhi() >= tuChiPhi && kh.TinhTongChiPhi() <= denChiPhi)
                .OrderBy(kh => kh.TinhTongChiPhi())
                .ToList();

            if (!filteredList.Any())
            {
                Console.WriteLine($"Không thể tìm thấy khách hàng trong khoảng [{tuChiPhi} ; {denChiPhi}]");
                return;
            }

            foreach (var khachHang in filteredList)
            {
                khachHang.InThongTin();
                Console.WriteLine();
            }
        }

        public void XuatKhachHangChiPhiCaoNhat()
        {
            var khachHangs = _khachHangRepo.GetAll();

            var khachHang = khachHangs
                .Where(kh => kh.LoaiSanPham == 1)
                .OrderByDescending(kh => kh.TinhTongChiPhi())
                .FirstOrDefault();

            if (khachHang == null)
            {
                Console.WriteLine("Hiện chưa có khách hàng nào");
                return;
            }

            khachHang.InThongTin();
        }

        public void ThemKhachHangVIP(KhachHangVIP khachHangVIP)
        {
            _khachHangRepo.Add(khachHangVIP);
            khachHangVIP.InThongTin();
        }
    }
}
