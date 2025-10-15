using Model;

namespace BLL
{
    public interface IDanhMucBusiness
    {
        DanhMucModel GetDatabyID(int id);
        bool Create(DanhMucModel model);
        bool Update(DanhMucModel model);
        List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, int? MaDanhMuc, string TenDanhMuc, string option);
    }
}