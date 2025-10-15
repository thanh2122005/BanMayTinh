using DAL.Helper;
using Microsoft.VisualBasic.FileIO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonHangRepository:IDonHangRepository
    {
        private IDatabaseHelper _dbHelper;
        public DonHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(DonHangModel model)
        {
            string msgError = "";
            try
            {
                var xxx = model.objectjson_khach != null ? MessageConvert.SerializeObject(model.objectjson_khach) : null;
                var xyyy = model.listjson_chitiet != null ? MessageConvert.SerializeObject(model.listjson_chitiet) : null;
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_donhang_create",
                "@khach", model.objectjson_khach != null ? MessageConvert.SerializeObject(model.objectjson_khach) : null,
                "@listchitiet", model.listjson_chitiet != null ? MessageConvert.SerializeObject(model.listjson_chitiet) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DonHangModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_donhang_get_by_id",
                     "@MaDonHang", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DonHangModel> Search(int pageIndex, int pageSize, out long total, string TenKhachHang, string SoDienThoai, string Email, DateTime? fr_NgayDat, DateTime? to_NgayDat)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_donhang_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenKhachHang", TenKhachHang,
                    "@SoDienThoai", SoDienThoai,
                    "@Email", Email,
                    "@fr_NgayDat", fr_NgayDat,
                    "@to_NgayDat", to_NgayDat);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
