using KhachHangAPIBasic1.BUS.Interface;
using KhachHangAPIBasic1.DAL.Entities;
using KhachHangAPIBasic1.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace KhachHangAPIBasic1.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachHangsController : ControllerBase
    {
        private readonly IKhachHangService _khachHangService;
        static List<KhachHang> _khachHangs = new();
        public KhachHangsController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }

        [HttpPost("nhap")]
        public IActionResult Nhap([FromBody] KhachHang khachHang)
        {
           var result = _khachHangService.Nhap(khachHang, _khachHangs);
           return Ok(result); 
        }

        [HttpGet("xuat")]
        public IActionResult Xuat()
        {
            var result = _khachHangService.Xuat(_khachHangs);
            return Ok(result);
        }

        [HttpDelete("xoa-khach-hang/{maKH}")]
        public IActionResult XoaKhachHang(string maKH)
        {
            var result = _khachHangService.XoaKhachHang(maKH, _khachHangs);
            return Ok(result);
        }

        [HttpGet("xuat-theo-tong-chi-phi")]
        public IActionResult XuatTheoTongChiPhi(double tuChiPhi, double denChiPhi)
        {
            var result = _khachHangService.XuatTheoTongChiPhi(tuChiPhi, denChiPhi , _khachHangs);
            return Ok(result);
        }

        [HttpGet("xuat-chi-phi")]
        public IActionResult XuatKhachHangChiPhiCaoNhat()
        {
            var result = _khachHangService.XuatKhachHangChiPhiCaoNhat(_khachHangs);
            if(result == null)
            {
                return NotFound("Không có thông tin khách hàng có chi phí cáo nhất");
            }    
            else
            {
                return Ok(result);
            }    
        }

        [HttpPost("them-khang-hang-vip")]
        public IActionResult ThemKhachHangVIP([FromBody] KhachHangVIP khachHangVIP)
        {
            var result = _khachHangService.ThemKhachHangVIP(khachHangVIP, _khachHangs);
            return Ok(result);
        }
    }
}
