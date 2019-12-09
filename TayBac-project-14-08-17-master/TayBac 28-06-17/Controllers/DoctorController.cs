using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TayBac_28_06_17.Models.BussinessModels;
using TayBac_28_06_17.AuthorizationAttributes;
using TayBac_28_06_17.Commons;
using TayBac_28_06_17.Models.EntityModels;
using System.Web;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;

namespace TayBac_28_06_17.Controllers
{
    public class DoctorController : Controller
    {
        [HttpPost]
        public ActionResult uploadImg(HttpPostedFileBase img, string idbs)
        {
            string[] imgTypes = { ".jpg", ".png", ".jpeg", ".gif" };

            if (img != null)
            {
                if (imgTypes.Contains(Path.GetExtension(img.FileName).ToLower()))
                {

                    ViewBag.W = 0;
                    ViewBag.H = 0;
                    //byte[] x = new byte[img.ContentLength];
                    Image i = Image.FromStream(img.InputStream);
                    try
                    {
                        int oldWidth = i.Width;
                        int oldHeight = i.Height;
                        int resizeW = 400;
                        int resizeH = oldHeight * resizeW / oldWidth;
                        Bitmap b = new Bitmap(resizeW, resizeH);
                        Graphics g = Graphics.FromImage((Image)b);
                        g.InterpolationMode = InterpolationMode.Bicubic;
                        g.DrawImage(i, 0, 0, resizeW, resizeH);
                        g.Dispose();

                        MemoryStream ms = new MemoryStream();
                        b.Save(ms, i.RawFormat);
                        byte[] x = new byte[ms.Length];
                        x = ms.ToArray();
                        new DoctorModels().saveImg(idbs, x);
                        ViewBag.I = x;
                        return RedirectToAction("Details", new { id = idbs });

                    }
                    catch (Exception)
                    {

                    }

                }

            }
            return RedirectToAction("Details", new { id = idbs });
        }
        [Permission(Constants.G_DOCTOR)]
        public ActionResult Index()
        {
            return View();
        }

        [Permission(Constants.G_ADMIN, Constants.G_MANAGER)]
        public ActionResult Delete(string id = "0")
        {
            new DoctorModels().delete(id);
            return RedirectToAction("Alls");
        }

        [Permission(Constants.G_ADMIN, Constants.G_MANAGER)]
        public ActionResult Create()
        {
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            ViewBag.id = new DoctorModels().createDoctorId();
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_ADMIN, Constants.G_MANAGER)]
        public ActionResult Create(bacsy doctor)
        {
            doctor.updatetime = DateTime.Today;
            doctor.trangthai = true;
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            ViewBag.id = new DoctorModels().createDoctorId();

            if (ModelState.IsValid)
            {
                if (new DoctorModels().insert(doctor))
                {
                    ViewBag.Susscess = "Thêm người dùng thành công";
                    return View();
                }
                ModelState.AddModelError("", "Không thể thêm bản ghi");
                return View();
            }

            return View();
        }

        public ActionResult Alls()
        {
            var model = new DoctorModels().getAll();
            return View(model);
        }

        public ActionResult Details(string id = "0")
        {
            var model = new DoctorModels().detail(id);
            if (model == null)
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }
            return View(model);
        }

        [Permission(Constants.G_DOCTOR)]
        public ActionResult ChangePass(string id)
        {
            if (!(Session[Constants.SESSION_ID].ToString().Trim() == id))
            {
                return RedirectToAction("NotAuthorize", "Login");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_DOCTOR)]
        public ActionResult ChangePass(string oldPass, string newPass1, string newPass2)
        {
            int r = new DoctorModels().changePass(Session[Constants.SESSION_ID] as string, oldPass, newPass1, newPass2);
            if (r == -1)
            {
                ViewBag.Err1 = "Hãy nhập mật khẩu mới";
                return View();
            }
            if (r == -2)
            {
                ViewBag.Err2 = "Nhập lại không đúng";
                return View();
            }

            if (r == -3)
            {
                ViewBag.Err3 = "Sai mật khẩu";
                return View();
            }
            if (r == 0)
            {
                ViewBag.Err4 = "Hệ thống đang cập nhập, vui lòng quay lại sau";
                return View();
            }
            ViewBag.Success = "Cập nhật mật khẩu thành công";
            return View();
        }

        [HttpGet]
        [Permission(Constants.G_ADMIN, Constants.G_DOCTOR, Constants.G_MANAGER)]
        public ActionResult Edit(string id)
        {
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            var model = new DoctorModels().detail(id);
            // neu la manager, k cung benh vien vs doctor
            if ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_MANAGER 
                && model.idbv.Trim() != (Session[Constants.SESSION_HOSPITAL_ID] as string).Trim())
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }
            if ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_DOCTOR
            && model.idbsy.Trim() != (Session[Constants.SESSION_ID] as string).Trim())
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_ADMIN, Constants.G_DOCTOR, Constants.G_MANAGER)]
        public ActionResult Edit(bacsy doctor)
        {
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();

            if ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_MANAGER
            && doctor.idbv.Trim() != (Session[Constants.SESSION_HOSPITAL_ID] as string).Trim())
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }
            doctor.updatetime = DateTime.Now;
            if (new DoctorModels().update(doctor) == 1)
            {
                return RedirectToAction("Details", new { @id = doctor.idbsy.Trim() });
            }
            else
            {
                ViewBag.getListHospitals = new HospitalModels().getListHospitals();
                return View();
            }
        }

    }
}