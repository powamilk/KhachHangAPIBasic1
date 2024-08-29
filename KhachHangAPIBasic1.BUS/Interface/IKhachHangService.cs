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
        IEnumerable<string> Xuat();
        string XoaKhachHang(string maKH);
        IEnumerable<string> XuatTheoTongChiPhi(double tuChiPhi, double denChiPhi);
        string XuatKhachHangChiPhiCaoNhat();
        string ThemKhachHangVIP(KhachHangVIP khachHangVIP);
    }
}
