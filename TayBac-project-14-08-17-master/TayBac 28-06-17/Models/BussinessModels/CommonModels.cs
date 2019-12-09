using System.Collections.Generic;
using System.Web.Mvc;
using TayBac_28_06_17.Commons;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class CommonModels
    {
        public List<SelectListItem> getListGroup()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = Constants.G_MANAGER, Value = Constants.G_MANAGER });
            li.Add(new SelectListItem { Text = Constants.G_STAFF, Value = Constants.G_STAFF });
            return li;
        }
    }
}