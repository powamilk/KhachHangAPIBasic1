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
        void Nhap(KhachHang khachHang);
        void Xuat();
        void XoaKhachHang(string maKH);
        void XuatTheoTongChiPhi(double tuChiPhi, double denChiPhi);
        void XuatKhachHangChiPhiCaoNhat();
        void ThemKhachHangVIP(KhachHangVIP khachHangVIP);
    }
}
