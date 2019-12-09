using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.AuthorizationAttributes;
using TayBac_28_06_17.Commons;
using TayBac_28_06_17.Models.BussinessModels;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Controllers
{

    public class HospitalController : Controller
    {
        public ActionResult Index()
        {
            return View("Alls");
        }

        public ActionResult Alls()
        {
            var model = new HospitalModels().getAll();
            return View(model);
        }

        public ActionResult Details(string id)
        {
            var model = new HospitalModels().details(id);
            return View(model);
        }
        [Permission(Constants.G_ADMIN)]
        public ActionResult Create()
        {
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_ADMIN)]
        public ActionResult Create(benhvien hopital)
        {
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            hopital.trangthai = true;
            if (ModelState.IsValid)
            {
                if (new HospitalModels().insert(hopital))
                {
                    ViewBag.Susscess = "Thêm bệnh viện thành công";
                    return RedirectToAction("Alls");
                }
                ModelState.AddModelError("", "Không thể thêm bản ghi");
                return View();
            }

            return View("Create");
        }

        [Permission(Constants.G_ADMIN)]
        public ActionResult Edit(string id)
        {
            var model = new HospitalModels().details(id);
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_ADMIN)]
        public ActionResult Edit(benhvien hospital)
        {
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            if (new HospitalModels().update(hospital) == 1)
            {
                return RedirectToAction("Alls");
            }
            return View();
        }

        [Permission(Constants.G_ADMIN)]
        public ActionResult Delete(string id = "0")
        {
            if (new HospitalModels().delete(id))
            {
                return RedirectToAction("Alls");
            }
            return View();
        }
    }
}
