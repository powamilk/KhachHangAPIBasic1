using KhachHangAPIBasic1.DAL.Entities;
using KhachHangAPIBasic1.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachHangAPIBasic1.DAL.Repositories.Implement
{
        public class KhachHangRepo : IKhachHangRepo
        {
            private readonly List<KhachHang> _khachHangs;

            public KhachHangRepo()
            {
                _khachHangs = new List<KhachHang>();
            }

            public void Add(KhachHang khachHang)
            {
                _khachHangs.Add(khachHang);
            }

            public void Delete(string maKH)
            {
                var khachHang = _khachHangs.FirstOrDefault(kh => kh.MaKH == maKH);
                if (khachHang != null)
                {
                    _khachHangs.Remove(khachHang);
                }
            }

            public KhachHang GetById(string maKH)
            {
                return _khachHangs.FirstOrDefault(kh => kh.MaKH == maKH);
            }

            public IEnumerable<KhachHang> GetAll()
            {
                return _khachHangs;
            }
        
        }
}
