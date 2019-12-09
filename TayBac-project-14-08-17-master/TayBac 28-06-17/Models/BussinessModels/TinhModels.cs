using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class TinhModels
    {
        private TayBacDBContext dbContext = null;
        public TinhModels()
        {
            dbContext = new TayBacDBContext();
        }
        //public List<tinh> getListTinhs()
        //{
        //    return dbContext.tinhs.ToList();
        //}
        public IEnumerable<SelectListItem> getListTinhs()
        {
            var model = dbContext.tinhs.Select(t => new SelectListItem
            {
                Value = t.idtinh,
                Text = t.tentinh
            });

            return model;
        }

    }
}