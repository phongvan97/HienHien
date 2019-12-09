using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class KhoaModels
    {
        private TayBacDBContext dbContext = null;
        public KhoaModels()
        {
            dbContext = new TayBacDBContext();
        }
        public List<khoa> getListByIdBV(string idbv)
        {
            return dbContext.khoas.Where(k => k.idbv == idbv).ToList();
        }
    }

}