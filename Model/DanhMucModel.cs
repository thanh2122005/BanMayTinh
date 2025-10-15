
namespace Model
{
    public class DanhMucModel
    {
        public int MaDanhMuc { get; set; }
        public int? MaDanhMucCha { get; set; }
        public string TenDanhMuc { get; set; }
        public int? STT { get; set; }
        public bool TrangThai { get; set; }
        DanhMucModel()
        {
            MaDanhMuc = 0;
            MaDanhMucCha = null;
            TenDanhMuc = string.Empty;
            STT = null;
            TrangThai = true;
        }
    }
}