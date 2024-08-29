using KhachHangAPIBasic1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangAPIBasic1.DAL.Repositories.Interface
{
    public interface IKhachHangRepo
    {
        void Add(KhachHang khachHang, List<KhachHang> khachHangs);
        void Delete(string maKH, List<KhachHang> khachHangs);
        KhachHang GetById(string maKH, List<KhachHang> khachHangs   );
        IEnumerable<KhachHang> GetAll(List<KhachHang> khachHangs);
    }
}
