using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.EntityModels;
using TayBac_28_06_17.Models.BussinessModels;

namespace TayBac_28_06_17.Controllers
{
    public class GiuongController : Controller
    {
        // GET: Giuong
        public ActionResult Index()
        {
            return View();
        }

        // GET: Giuong/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Giuong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Giuong/Create
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

        // GET: Giuong/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Giuong/Edit/5
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

        // GET: Giuong/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Giuong/Delete/5
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
        //get json based on khoa
        public ActionResult jsonLsGiuong(string idkhoa)
        {
            GiuongModels gi_model = new GiuongModels();
            
            return Json(gi_model.getListByIdKhoa(idkhoa), JsonRequestBehavior.AllowGet);
        }
    }
}
