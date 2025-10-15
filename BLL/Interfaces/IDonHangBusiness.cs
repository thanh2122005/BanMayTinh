using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IDonHangBusiness
    {
        bool Create(DonHangModel model);
        DonHangModel GetDatabyID(int id);
        List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string TenKhachHang, string SoDienThoai, string Email, DateTime? fr_NgayDat, DateTime? to_NgayDat);
    }
}
