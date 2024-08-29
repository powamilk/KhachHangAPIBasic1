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

        public IEnumerable<string> Xuat()
        {
            var khachHangs = _khachHangRepo.GetAll();

            if (!khachHangs.Any())
            {
                return new List<string> { "Hiện chưa có khách hàng" };
            }

            var sortedList = khachHangs
                .OrderBy(kh => kh.MaKH)
                .ThenByDescending(kh => kh.SoLuongDaMua)
                .ToList();

            return sortedList.Select(kh => kh.InThongTin()).ToList();
        }

        public string XoaKhachHang(string maKH)
        {
            var khachHang = _khachHangRepo.GetById(maKH);
            if (khachHang == null)
            {
                return $"Không thể tìm thấy khách hàng với mã {maKH}";
            }

            _khachHangRepo.Delete(maKH);
            return $"Khách hàng với mã {maKH} đã bị xóa.";
        }

        public IEnumerable<string> XuatTheoTongChiPhi(double tuChiPhi, double denChiPhi)
        {
            var khachHangs = _khachHangRepo.GetAll();

            var filteredList = khachHangs
                .Where(kh => kh.TinhTongChiPhi() >= tuChiPhi && kh.TinhTongChiPhi() <= denChiPhi)
                .OrderBy(kh => kh.TinhTongChiPhi())
                .ToList();

            if (!filteredList.Any())
            {
                return new List<string> { $"Không thể tìm thấy khách hàng trong khoảng [{tuChiPhi} ; {denChiPhi}]" };
            }

            return filteredList.Select(kh => kh.InThongTin()).ToList();
        }

        public string XuatKhachHangChiPhiCaoNhat()
        {
            var khachHangs = _khachHangRepo.GetAll();

            var khachHang = khachHangs
                .Where(kh => kh.LoaiSanPham == 1)
                .OrderByDescending(kh => kh.TinhTongChiPhi())
                .FirstOrDefault();

            if (khachHang == null)
            {
                return "Hiện chưa có khách hàng nào";
            }

            return khachHang.InThongTin();
        }

        public string ThemKhachHangVIP(KhachHangVIP khachHangVIP)
        {
            _khachHangRepo.Add(khachHangVIP);
            return khachHangVIP.InThongTin();
        }
    }
}
