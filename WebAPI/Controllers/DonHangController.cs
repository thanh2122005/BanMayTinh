using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Reflection;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]     
    public class DonHangController : ControllerBase
    {
        private IDonHangBusiness _donhangBusiness;
        public DonHangController(IDonHangBusiness donhangBusiness)
        {
            _donhangBusiness = donhangBusiness;
        }
        [Route("create-donhang")]
        [HttpPost]
        public DonHangModel Create([FromBody] DonHangModel model)
        {
            _donhangBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public DonHangModel GetDatabyID(int id)
        {
            return _donhangBusiness.GetDatabyID(id);
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenKhachHang = "";
                if (formData.Keys.Contains("TenKhachHang") && !string.IsNullOrEmpty(Convert.ToString(formData["TenKhachHang"]))) { TenKhachHang = Convert.ToString(formData["TenKhachHang"]); }
                string SoDienThoai = "";
                if (formData.Keys.Contains("SoDienThoai") && !string.IsNullOrEmpty(Convert.ToString(formData["SoDienThoai"]))) { SoDienThoai = Convert.ToString(formData["SoDienThoai"]); }
                string Email = "";
                if (formData.Keys.Contains("Email") && !string.IsNullOrEmpty(Convert.ToString(formData["Email"]))) { Email = Convert.ToString(formData["Email"]); }

                DateTime? fr_NgayDat = null;
                if (formData.Keys.Contains("fr_NgayDat") && formData["fr_NgayDat"] != null && formData["fr_NgayDat"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayDat"].ToString());
                    fr_NgayDat = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_NgayDat = null;
                if (formData.Keys.Contains("to_NgayDat") && formData["to_NgayDat"] != null && formData["to_NgayDat"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_NgayDat"].ToString());
                    to_NgayDat = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                } 
                long total = 0;
                var data = _donhangBusiness.Search(page, pageSize, out total, TenKhachHang, SoDienThoai, Email, fr_NgayDat, to_NgayDat);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}