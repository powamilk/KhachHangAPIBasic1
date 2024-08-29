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
        void Add(KhachHang khachHang);
        void Delete(string maKH);
        KhachHang GetById(string maKH);
        IEnumerable<KhachHang> GetAll();
    }
}
