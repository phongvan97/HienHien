
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.AuthorizationAttributes;
using TayBac_28_06_17.Commons;
using TayBac_28_06_17.Models.BussinessModels;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Controllers
{
    public class PatientController : Controller
    {
        [Permission(Constants.G_PATIENT)]
        public ActionResult Index()
        {
            return View();
        }
        [Permission(Constants.G_ADMIN, Constants.G_MANAGER, Constants.G_STAFF)]
        public ActionResult Create()
        {
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            ViewBag.id = new PatientModels().createPatienId();
            return View();
        }
        [HttpPost]
        public ActionResult uploadImg(HttpPostedFileBase img, string idbn)
        {
            string[] imgTypes = { ".jpg", ".png", ".jpeg", ".gif" };

            if (img != null)
            {
                if (imgTypes.Contains(Path.GetExtension(img.FileName).ToLower()))
                {

             
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
                        new PatientModels().saveImg(idbn, x);
                        ViewBag.I = x;
                        return RedirectToAction("Details", new { id = idbn });

                    }
                    catch (Exception)
                    {

                    }

                }

            }
            return RedirectToAction("Details", new { id = idbn });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_ADMIN, Constants.G_MANAGER, Constants.G_STAFF)]
        public ActionResult Create(benhnhan patient)
        {
            //patient.updatetime = DateTime.Today;
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            ViewBag.id = new PatientModels().createPatienId();

            if (ModelState.IsValid)
            {
                if (new PatientModels().insert(patient))
                {
                    ViewBag.Susscess = "Thêm người dùng thành công";
                    return View();
                }
                ModelState.AddModelError("", "Không thể thêm bản ghi");
                return View();
            }

            return View();
        }
        [Permission(Constants.G_ADMIN, Constants.G_MANAGER)]
        public ActionResult Delete(string id = "0")
        {
            new PatientModels().delete(id);
            return RedirectToAction("Alls");
        }
        public ActionResult Details(string id = "0")
        {
            var model = new PatientModels().detail(id);
            return View(model);
        }
        public ActionResult Alls()
        {
            var model = new PatientModels().getAll();
            return View(model);
        }
        [Permission(Constants.G_PATIENT)]
        public ActionResult ChangePass()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_PATIENT)]
        public ActionResult ChangePass(string oldPass, string newPass1, string newPass2)
        {
            int r = new PatientModels().changePass(Session[Constants.SESSION_ID] as string, oldPass, newPass1, newPass2);
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

        [Permission(Constants.G_ADMIN, Constants.G_PATIENT, Constants.G_STAFF, Constants.G_MANAGER)]
        public ActionResult Edit(string id = "0")
        {
            benhnhan model = new PatientModels().detail(id);
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();

            if (((Session[Constants.SESSION_GROUPID] as string) == Constants.G_MANAGER
                || (Session[Constants.SESSION_GROUPID] as string) == Constants.G_STAFF)
                && model.idbv.Trim() != (Session[Constants.SESSION_HOSPITAL_ID] as string).Trim())
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }
            if ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_PATIENT
            && model.idbn.Trim() != (Session[Constants.SESSION_ID] as string).Trim())
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }
            return View(model);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_ADMIN, Constants.G_PATIENT, Constants.G_STAFF, Constants.G_MANAGER)]
        public ActionResult Edit(benhnhan patient)
        {
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();

            if (
                ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_MANAGER
                || (Session[Constants.SESSION_GROUPID] as string) == Constants.G_STAFF)
                && patient.idbv.Trim() != (Session[Constants.SESSION_HOSPITAL_ID] as string).Trim())
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }
            if ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_PATIENT
            && patient.idbn.Trim() != (Session[Constants.SESSION_ID] as string).Trim())
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }
            if (new PatientModels().update(patient) == 1)
            {
                return RedirectToAction("Details", new { @id = patient.idbn.Trim() });
            }

            return View();
        }

    }
}