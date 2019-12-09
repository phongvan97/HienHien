using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class GiuongModels
    {
        private TayBacDBContext dbContext = null;
        public GiuongModels()
        {
            dbContext = new TayBacDBContext();
        }
        public List<giuong> getListByIdKhoa(string idkhoa)
        {
            return dbContext.giuongs.Where(k => k.idkhoa == idkhoa).ToList();
        }
    }
}