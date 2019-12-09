using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.BussinessModels;

namespace TayBac_28_06_17.Controllers
{
    public class HuyenController : Controller
    {
        // id : idtinh
        public JsonResult ListHuyens(string id)
        {
            var list = new HuyenModels().getList(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}