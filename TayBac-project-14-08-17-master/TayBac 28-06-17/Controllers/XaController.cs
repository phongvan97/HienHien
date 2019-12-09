using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.BussinessModels;

namespace TayBac_28_06_17.Controllers
{
    public class XaController : Controller
    {
        // GET: Xa
        [HttpGet]
        // id : idhuyen
        public JsonResult ListXas(string id)
        {
            var list = new XaModels().getList(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}