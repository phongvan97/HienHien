using System.Web.Mvc;
using TayBac_28_06_17.Models.BussinessModels;
using TayBac_28_06_17.Models.EntityModels;
using TayBac_28_06_17.Commons;


namespace TayBac_28_06_17.Controllers.Login_OutControllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string pass, string group)
        {
           
            if (ModelState.IsValid)
            {
                var account = new LoginModels().CheckAccount(username, pass, group);
               
                if (account != null)
                {
                    if (group == Constants.G_ADMIN)
                    {
                        user user = account as user;
                        Session[Constants.SESSION_ID] = user.idnd;
                        Session[Constants.SESSION_GROUPID] = Constants.G_ADMIN;
                        Session[Constants.SESSION_NAME] = user.tennd;
                        Session[Constants.SESSION_HOSPITAL_ID] = user.idbv;
                        Session[Constants.SESSION_HOSPITAL_NAME] = user.benhvien.tenbv;
                        return RedirectToAction("Index", "Admin");
                    }
                    if (group == Constants.G_MANAGER)
                    {
                        user user = account as user;
                        if (user.trangthai == false || user.trangthai == null)
                        {
                            ViewBag.Err1 = "Tài Khoản đang bị khóa";
                            return View("Index");
                        }
                        Session[Constants.SESSION_ID] = user.idnd;
                        Session[Constants.SESSION_GROUPID] = Constants.G_MANAGER;
                        Session[Constants.SESSION_NAME] = user.tennd;
                        Session[Constants.SESSION_HOSPITAL_ID] = user.idbv;
                        Session[Constants.SESSION_HOSPITAL_NAME] = user.benhvien.tenbv;
                        return RedirectToAction("Index", "Manager");
                    }
                    if (group == Constants.G_STAFF)
                    {
                        user user = account as user;
                        if (user.trangthai == false || user.trangthai == null)
                        {
                            ViewBag.Err1 = "Tài Khoản đang bị khóa";
                            return View("Index");
                        }
                        Session[Constants.SESSION_ID] = user.idnd;
                        Session[Constants.SESSION_GROUPID] = Constants.G_STAFF;
                        Session[Constants.SESSION_NAME] = user.tennd;
                        Session[Constants.SESSION_HOSPITAL_ID] = user.idbv;
                        Session[Constants.SESSION_HOSPITAL_NAME] = user.benhvien.tenbv;
                        return RedirectToAction("Index", "Staff");
                    }
                    if (group == Constants.G_PATIENT)
                    {
                        benhnhan patient = account as benhnhan;
                        if (patient.trangthai == false || patient.trangthai == null)
                        {
                            ViewBag.Err1 = "Tài Khoản đang bị khóa";
                            return View("Index");
                        }
                        Session[Constants.SESSION_ID] = patient.idbn;
                        Session[Constants.SESSION_GROUPID] = Constants.G_PATIENT;
                        Session[Constants.SESSION_NAME] = patient.tenbn;
                        Session[Constants.SESSION_HOSPITAL_NAME] = patient.benhvien.tenbv;
                        return RedirectToAction("Index", "Patient");
                    }
                    if (group == Constants.G_DOCTOR)
                    {
                        bacsy doctor = account as bacsy;
                        if (doctor.trangthai == false || doctor.trangthai == null)
                        {
                            ViewBag.Err1 = "Tài Khoản đang bị khóa";
                            return View("Index");
                        }
                        Session[Constants.SESSION_ID] = doctor.idbsy;
                        Session[Constants.SESSION_GROUPID] = Constants.G_DOCTOR;
                        Session[Constants.SESSION_NAME] = doctor.tenbs;
                        Session[Constants.SESSION_HOSPITAL_ID] = doctor.idbv;
                        Session[Constants.SESSION_HOSPITAL_NAME] = doctor.benhvien.tenbv;
                        return RedirectToAction("Index", "Doctor");
                    }

                }
            }
            ViewBag.Err1 = "Sai mật khẩu hoặc tài khoản";
            ViewBag.Err2 = "Kiểm tra quyền người dùng";
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View("Index");
        }
        public ActionResult NotAuthorize()
        {
            return View();
        }
    }
}