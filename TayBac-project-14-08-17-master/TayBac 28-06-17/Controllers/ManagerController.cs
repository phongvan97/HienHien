using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.AuthorizationAttributes;
using TayBac_28_06_17.Commons;

namespace TayBac_28_06_17.Controllers
{
    public class ManagerController : Controller
    {
        [Permission(Constants.G_MANAGER)]
        public ActionResult Index()
        {
            return View();
        }
    }
}