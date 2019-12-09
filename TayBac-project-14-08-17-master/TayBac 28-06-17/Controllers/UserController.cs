using System;
using System.Web.Mvc;
using TayBac_28_06_17.Models.BussinessModels;
using TayBac_28_06_17.AuthorizationAttributes;
using TayBac_28_06_17.Commons;
using System.Web;
using System.IO;
using System.Linq;
using System.Drawing;
using TayBac_28_06_17.Models.EntityModels;
using System.Drawing.Drawing2D;

namespace TayBac_28_06_17.Controllers
{
    public class UserController : Controller
    {

        [HttpPost]
        public ActionResult uploadImg(HttpPostedFileBase img, string idnd)
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
                        new UserModels().saveImg(idnd, x);
                        ViewBag.I = x;
                        return RedirectToAction("Details", new { id = idnd });

                    }
                    catch(Exception)
                    {

                    }
                    
                }

            }
            return RedirectToAction("Details", new { id = idnd });
        }

        // GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Delete(string id = "0")
        {
            if (new UserModels().delete(id))
            {
                return RedirectToAction("Alls");
            }

            return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
        }
        public ActionResult Alls()
        {
            var model = new UserModels().getAll();
            return View(model);
        }
        public ActionResult Details(string id)
        {
            var model = new UserModels().detail(id);
            if (model == null)
            {
                return RedirectToAction(actionName: "NotAuthorize", controllerName: "Login");
            }
            return View(model);
        }

        [Permission(Constants.G_ADMIN, Constants.G_MANAGER)]
        public ActionResult Create()
        {
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            ViewBag.getListRoles = new CommonModels().getListGroup();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Permission(Constants.G_ADMIN, Constants.G_MANAGER)]
        public ActionResult Create(user user)
        {
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            ViewBag.getListRoles = new CommonModels().getListGroup();

            // current = Constants.G_MANAGER;
            if ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_MANAGER)
            {
                if (user.idbv != (Session[Constants.SESSION_HOSPITAL_ID] as string).Trim() || user.kieuuser != Constants.G_STAFF)
                {
                    ModelState.AddModelError("", "Vượt quyền hoặc sai tuyến");
                    return View();
                }
            }
            // current = Constants.G_ADMIN;
            if ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_ADMIN)
            {
                if (user.kieuuser == Constants.G_ADMIN)
                {
                    ModelState.AddModelError("", "Không được phép");
                    return View();
                }
            }

            user.updatetime = DateTime.Today;
            if (ModelState.IsValid)
            {
                if (new UserModels().insert(user))
                {
                    ViewBag.Susscess = "Thêm người dùng thành công";
                    return View();
                }
                ModelState.AddModelError("", "Không thể thêm bản ghi");
                return View();
            }
            ModelState.AddModelError("", "Không thể thêm bản ghi");
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                id = Session[Constants.SESSION_ID].ToString().Trim();
            }

            var model = new UserModels().detail(id);
            if ((Session[Constants.SESSION_ID] as string).Trim() == model.idnd.Trim() // chinh nguoi dung
                    || (Session[Constants.SESSION_GROUPID] as string) == Constants.G_ADMIN      // neu la admim
                    || ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_MANAGER   // manager chinh sua tai khoan k la admin
                          && (Session[Constants.SESSION_HOSPITAL_ID] as string).Trim() == model.idbv.Trim()
                          && model.kieuuser != Constants.G_ADMIN
                        )
                    )
            {
                ViewBag.getListHospitals = new HospitalModels().getListHospitals();
                ViewBag.getListTinhs = new TinhModels().getListTinhs();
                ViewBag.getListXas = new XaModels().getListXas();
                ViewBag.getListHuyens = new HuyenModels().getListHuyens();
                ViewBag.getListRoles = new CommonModels().getListGroup();
                return View(model);
            }
            return RedirectToAction("NotAuthorize", "Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(user user)
        {
            user.updatetime = DateTime.Now;

            // Update chinh tai khoan cua minh
            if (user.idnd == Session[Constants.SESSION_ID].ToString().Trim())
            {
                if (new UserModels().update(user, 1) == 1)
                    return RedirectToAction("Details", "User", new { @id = user.idnd.Trim() });
            }

            // Update tai khoan k la admin
            if (user.kieuuser != Constants.G_ADMIN)
            {
                // admin update
                if (Session[Constants.SESSION_GROUPID].ToString() == Constants.G_ADMIN)
                {
                    if (new UserModels().update(user, 2) == 1)
                        return RedirectToAction("Details", "User", new { @id = user.idnd.Trim() });
                }

                // manager update
                if ((Session[Constants.SESSION_GROUPID] as string) == Constants.G_MANAGER
                    && Session[Constants.SESSION_HOSPITAL_ID].ToString().Trim() == user.idbv.Trim())
                {
                    if (new UserModels().update(user, 3) == 1)
                        return RedirectToAction("Details", "User", new { @id = user.idnd.Trim() });
                }
            }
            // Can check lai = -3, -2, -1, 0
            ViewBag.getListHospitals = new HospitalModels().getListHospitals();
            ViewBag.getListTinhs = new TinhModels().getListTinhs();
            ViewBag.getListXas = new XaModels().getListXas();
            ViewBag.getListHuyens = new HuyenModels().getListHuyens();
            ViewBag.getListRoles = new CommonModels().getListGroup();
            ViewBag.Err = "Kiểm tra lại các trường còn thiếu";
            var model = new UserModels().detail(user.idnd);
            return View(model);
        }

        public ActionResult ChangePass(string id)
        {
            if (!(Session[Constants.SESSION_ID].ToString().Trim() == id))
            {
                return RedirectToAction("NotAuthorize", "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ChangePass(string oldPass, string newPass1, string newPass2)
        {
            int r = new UserModels().changePass(Session[Constants.SESSION_ID] as string, oldPass, newPass1, newPass2);
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
    }
}