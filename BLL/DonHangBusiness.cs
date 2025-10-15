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
    public class DonHangBusiness : IDonHangBusiness
    {
        private IDonHangRepository _res;
        public DonHangBusiness(IDonHangRepository res)
        {
            _res = res;
        }
        public DonHangModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(DonHangModel model)
        {
            return _res.Create(model);
        }
        public List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string TenKhachHang, string SoDienThoai, string Email, DateTime? fr_NgayDat, DateTime? to_NgayDat)
        {
            return _res.Search(pageIndex, pageSize, out total, TenKhachHang, SoDienThoai, Email, fr_NgayDat, to_NgayDat);
        }
    }
}
