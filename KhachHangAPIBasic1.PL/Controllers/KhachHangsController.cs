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

        public KhachHangsController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }

        [HttpPost("nhap")]
        public IActionResult Nhap([FromBody] KhachHang khachHang)
        {
            try
            {
                _khachHangService.Nhap(khachHang);
                return Ok("Nhập khách hàng thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("xuat")]
        public IActionResult Xuat()
        {
            _khachHangService.Xuat();
            return Ok("Xuất danh sách khách hàng thành công");
        }

        [HttpDelete("xoakhachhang/{maKH}")]
        public IActionResult XoaKhachHang(string maKH)
        {
            _khachHangService.XoaKhachHang(maKH);
            return Ok();
        }

        [HttpGet("xuattheotongchiphi")]
        public IActionResult XuatTheoTongChiPhi(double tuChiPhi, double denChiPhi)
        {
            _khachHangService.XuatTheoTongChiPhi(tuChiPhi, denChiPhi);
            return Ok();
        }

        [HttpGet("xuatchiphi")]
        public IActionResult XuatKhachHangChiPhiCaoNhat()
        {
            _khachHangService.XuatKhachHangChiPhiCaoNhat();
            return Ok();
        }

        [HttpPost("themkhanghangvip")]
        public IActionResult ThemKhachHangVIP([FromBody] KhachHangVIP khachHangVIP)
        {
            _khachHangService.ThemKhachHangVIP(khachHangVIP);
            return Ok("Thêm khách hàng VIP thành công");
        }
    }
}
