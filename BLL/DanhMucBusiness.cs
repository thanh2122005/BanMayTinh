using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhMucBusiness: IDanhMucBusiness
    {
        private IDanhMucRepository _res;
        public DanhMucBusiness(IDanhMucRepository res)
        {
            _res = res;
        }
        public DanhMucModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(DanhMucModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DanhMucModel model)
        {
            return _res.Update(model);
        }
        public  List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, int? MaDanhMuc, string TenDanhMuc, string option)
        {
            return _res.Search(pageIndex, pageSize, out total, MaDanhMuc , TenDanhMuc, option);
        }
    }

}
