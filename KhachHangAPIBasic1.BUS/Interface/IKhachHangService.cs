using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhachHangAPIBasic1.DAL.Entities;
using KhachHangAPIBasic1.DAL.Model;

namespace KhachHangAPIBasic1.BUS.Interface
{
    public interface IKhachHangService
    {
        void Nhap(KhachHang khachHang, List<KhachHang> khachHangs);
        IEnumerable<KhachHang> Xuat(List<KhachHang> khachHang);
        string XoaKhachHang(string maKH, List<KhachHang> khachHangs);
        IEnumerable<KhachHang> XuatTheoTongChiPhi(double tuChiPhi, double denChiPhi, List<KhachHang> khachHang);
        KhachHang XuatKhachHangChiPhiCaoNhat(List<KhachHang> khachHangs);
        KhachHangVIP ThemKhachHangVIP(KhachHangVIP khachHangVIP, List<KhachHang> khachHangs);
    }
}
