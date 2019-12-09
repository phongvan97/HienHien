using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.BussinessModels;
using TayBac_28_06_17.Models.EntityModels;
using TayBac_28_06_17.Commons;
using TayBac_28_06_17.AuthorizationAttributes;

namespace TayBac_28_06_17.Controllers
{
    [Permission(Constants.G_ADMIN)]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}