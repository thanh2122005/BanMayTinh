using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public partial interface IDanhMucRepository
    {
        DanhMucModel GetDatabyID(int id);
        bool Create(DanhMucModel model);
        bool Update(DanhMucModel model);
        List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, int? MaDanhMuc, string TenDanhMuc, string option);
    }
}
