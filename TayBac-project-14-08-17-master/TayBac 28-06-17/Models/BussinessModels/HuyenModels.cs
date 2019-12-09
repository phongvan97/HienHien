using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class HuyenModels
    {
        private TayBacDBContext dbContext = null;
        public HuyenModels()
        {
            dbContext = new TayBacDBContext();
        }
        //public List<huyen> getListHuyens()
        //{
        //    return dbContext.huyens.ToList();
        //}
        public IEnumerable<SelectListItem> getListHuyens()
        {
            var model = dbContext.huyens.Select(h => new SelectListItem
            {
                Value = h.idhuyen,
                Text = h.tenhuyen
            });

            return model;
        }
        public object getList(string idtinh)
        {
            var list = dbContext.huyens.Where(h => h.idtinh.Trim() == idtinh).Select(h => new {
              id = h.idhuyen,
              name = h.tenhuyen,
            });
            return list;
        }
    }
}