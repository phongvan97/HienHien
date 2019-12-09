using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.BussinessModels;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Controllers
{
    public class KhoaController : Controller
    {
        // GET: Khoa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Khoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Khoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Khoa/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Khoa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Khoa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Khoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Khoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult jsonLsKhoa(string id)
        {
            KhoaModels kh_model = new KhoaModels();
            List<khoa> kh = kh_model.getListByIdBV(id);
            return Json(kh, JsonRequestBehavior.AllowGet);
        }
    }
}
