using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Reflection;

namespace WebAPI.Controllers
{
    [Route("api/danhmuc")]
    public class DanhMucController : ControllerBase
    {
        private IDanhMucBusiness _danhmucBusiness;
        public DanhMucController(IDanhMucBusiness danhmucBusiness)
        {
            _danhmucBusiness = danhmucBusiness;
        }

        //[Route("delete-danhmuc")]
        //[HttpDelete]
        //public IActionResult Delete(int MaDanhMuc)
        //{
        //    _danhmucBusiness.Delete(MaDanhMuc);
        //    return Ok(new { data = "OK" });
        //}

        [Route("update-danhmuc")]
        [HttpPost]
        public DanhMucModel Update([FromBody] DanhMucModel model)
        {
            _danhmucBusiness.Update(model);
            return model;
        }

        [Route("create-danhmuc")]
        [HttpPost]
        public DanhMucModel Create([FromBody] DanhMucModel model)
        {
            _danhmucBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public DanhMucModel GetDatabyID(int id)
        {
            return _danhmucBusiness.GetDatabyID(id);
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
                int? MaDanhMuc = null;
                if (formData.Keys.Contains("MaDanhMuc") && !string.IsNullOrEmpty(Convert.ToString(formData["MaDanhMuc"]))) { MaDanhMuc = Convert.ToInt32(formData["MaDanhMuc"]); }
                string TenDanhMuc = "";
                if (formData.Keys.Contains("TenDanhMuc") && !string.IsNullOrEmpty(Convert.ToString(formData["TenDanhMuc"]))) { TenDanhMuc = Convert.ToString(formData["TenDanhMuc"]); }
                string option = "";
                if (formData.Keys.Contains("option") && !string.IsNullOrEmpty(Convert.ToString(formData["option"]))) { option = Convert.ToString(formData["option"]); }
                long total = 0;
                var data = _danhmucBusiness.Search(page, pageSize, out total, MaDanhMuc, TenDanhMuc, option);
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