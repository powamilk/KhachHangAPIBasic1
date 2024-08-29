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
           

            public KhachHangRepo()
            {
                
            }

            public void Add(KhachHang khachHang, List<KhachHang> khachHangs)
            {
                khachHangs.Add(khachHang);
            }

            public void Delete(string maKH, List<KhachHang> khachHangs)
            {
                var khachHang = khachHangs.FirstOrDefault(kh => kh.MaKH == maKH);
                if (khachHang != null)
                {
                    khachHangs.Remove(khachHang);
                }
            }

            public KhachHang GetById(string maKH, List<KhachHang> khachHangs)
            {
                return khachHangs.FirstOrDefault(kh => kh.MaKH == maKH);
            }

            public IEnumerable<KhachHang> GetAll(List<KhachHang> khachHangs)
            {
                return khachHangs;
            }
        
        }
}
