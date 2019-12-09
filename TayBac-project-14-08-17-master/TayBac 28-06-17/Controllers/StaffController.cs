using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.AuthorizationAttributes;
using TayBac_28_06_17.Commons;
using TayBac_28_06_17.Models.BussinessModels;

namespace TayBac_28_06_17.Controllers
{
    public class StaffController : Controller
    {
        [Permission(Constants.G_STAFF)]
        public ActionResult Index()
        {
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            return View();
        }
    }
}