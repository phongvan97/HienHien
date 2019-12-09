using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TayBac_28_06_17.Models.DBContext;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class XaModels
    {
        private TayBacDBContext dbContext = null;

        public XaModels()
        {
            dbContext = new TayBacDBContext();
        }
        //public List<xa> getListXas()
        //{
        //    return dbContext.xas.ToList();
        //}
        public IEnumerable<SelectListItem> getListXas()
        {
            var model = dbContext.xas.Select(h => new SelectListItem
            {
                Value = h.idxa,
                Text = h.tenxa
            });

            return model;
        }

        public object getList(string idhuyen)
        {
            var list = dbContext.xas.Where(x => x.idhuyen.Trim() == idhuyen).Select(xa => new {
                id = xa.idxa.Trim(),
                name = xa.tenxa,
            });
            return list;
        }
    }
}