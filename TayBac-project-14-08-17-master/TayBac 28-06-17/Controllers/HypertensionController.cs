using System;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;
using TayBac_28_06_17.Models.BussinessModels;
using ExcelDataReader;
using TayBac_28_06_17.Commons;
using TayBac_28_06_17.AuthorizationAttributes;

namespace TayBac_28_06_17.Controllers
{
    public class HypertensionController : Controller
    {
        //
        // GET: /Hypertension/
        public ActionResult Index()
        {
            TayBacDBContext dbContext = new TayBacDBContext();
            var bn_huyetapp = (from ha in dbContext.huyetaps
                               join bs in dbContext.benhsus on ha.idbs equals bs.idbs
                               join bn in dbContext.benhnhans on bs.idbn equals bn.idbn
                               select new HuyetapViewModel
                               {
                                   idbn = bn.idbn,
                                   tenbn = bn.tenbn,
                                   idbs = bs.idbs,
                                   gioitinh = bn.gioitinh,
                                   ngaysinh = bn.ngaysinh,
                                   dantoc = bn.dantoc,
                                   idhuyetap = ha.idhuyetap,
                                   HA_I = ha.HA_I,
                                   HA_II_A = ha.HA_II_A
                               }).ToList();

            return View(bn_huyetapp);
        }

        //
        // GET: /Hypertension/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Hypertension/Create
        public ActionResult Create()
        {
            TayBacDBContext dbContext = new TayBacDBContext();
            List<object> ls = new List<object>();
            HospitalModels hp_model = new HospitalModels();
            huyetap ha = new huyetap();
            benhnhan pa = new benhnhan();
            KhoaModels kh_model = new KhoaModels();
            GiuongModels gi_model = new GiuongModels();
            List<benhvien> lsbv = hp_model.getAll();
            List<khoa> lskhoa = new List<khoa>();
            if (lsbv.Count() > 0)
            {
                lskhoa = kh_model.getListByIdBV(lsbv.First().idbv);
            }
            List<giuong> lsgiuong = new List<giuong>();

            if (lskhoa.Count() > 0)
            {
                lsgiuong = gi_model.getListByIdKhoa(lskhoa.First().idkhoa);
            }

            ls.Add(lsbv);
            ls.Add(ha);
            ls.Add(pa);
            ls.Add(lskhoa);
            ls.Add(lsgiuong);

            return View(ls);
        }

        //
        // POST: /Hypertension/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(benhnhan pa, huyetap ha)
        {

            try
            {
                PatientModels pa_model = new PatientModels();
                pa.idbn = StandString.generateBNID(8);
                pa_model.create(pa);
                benhsu bes = new benhsu();
                bes.idbn = pa.idbn;
                bes.idbs = StandString.generateBESID(8);
                BenhsuModels bes_model = new BenhsuModels();
                bes_model.insert(bes);
                HuyetapModels ha_model = new HuyetapModels();
                ha.idhuyetap = bes.idbs;
                ha.idbs = bes.idbs;
                ha_model.insert(ha);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Bloodpressure/Edit/5
        public ActionResult Edit(string id)
        {
            TayBacDBContext dbContext = new TayBacDBContext();
            List<object> ls = new List<object>();
            HospitalModels hp_model = new HospitalModels();
            HuyetapModels ha_model = new HuyetapModels();
            huyetap ha = ha_model.getByID(id);
            
            

            benhnhan pa = new benhnhan();
            KhoaModels kh_model = new KhoaModels();
            GiuongModels gi_model = new GiuongModels();
            List<benhvien> lsbv = hp_model.getAll();
            List<khoa> lskhoa = new List<khoa>();
            if (lsbv.Count() > 0)
            {
                lskhoa = kh_model.getListByIdBV(lsbv.First().idbv);
            }
            List<giuong> lsgiuong = new List<giuong>();
            if (lskhoa.Count() > 0)
            {
                lsgiuong = gi_model.getListByIdKhoa(lskhoa.First().idkhoa);
            }

            //
            BenhsuModels bs_model = new BenhsuModels();
            benhsu bs_data = bs_model.getByID(ha.idbs);
            PatientModels pa_model = new PatientModels();
            benhnhan pa_data = pa_model.detail(bs_data.idbn);
            benhvien bv_data = hp_model.details(pa_data.idbv);

            pa_data.benhvien = bv_data;
            bs_data.benhnhan = pa_data;
            ha.benhsu = bs_data;
            //

            ls.Add(lsbv);
            ls.Add(ha);
            ls.Add(pa);
            ls.Add(lskhoa);
            ls.Add(lsgiuong);

            return View(ls);
        }

        //
        // POST: /Bloodpressure/Edit/5
        [HttpPost]
        public ActionResult Edit(huyetap ha)
        {
            try
            {
                // TODO: Add update logic here
                PatientModels pa_model = new PatientModels();
                pa_model.update(ha.benhsu.benhnhan);
                HuyetapModels ha_model = new HuyetapModels();
                ha_model.update(ha);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Bloodpressure/Delete/5
        public ActionResult Delete(string id)
        {
            HuyetapModels ha_model = new HuyetapModels();
            huyetap ha = ha_model.getByID(id);
            ha_model.delete(ha);
            return RedirectToAction("Index");
        }

        //
        // POST: /Bloodpressure/Delete/5
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

        //Apis

        //get json list huyet ap
        // GET: /Hypertension/lshuyetap
        public ActionResult lshuyetap()
        {
            TayBacDBContext dbContext = new TayBacDBContext();
            var bn_huyetapp = from ha in dbContext.huyetaps
                              join bs in dbContext.benhsus on ha.idbs equals bs.idbs
                              join bn in dbContext.benhnhans on bs.idbn equals bn.idbn
                              select new
                              {
                                  bn_ten = bn.tenbn,
                                  bn_ns = bn.ngaysinh,
                                  bn_gioitinh = bn.gioitinh,
                                  bn_nghenghiep = bn.nghenghiep,
                                  HA_I = ha.HA_I,
                                  HA_II_A = ha.HA_II_A
                              };
            return Json(bn_huyetapp.ToList(), JsonRequestBehavior.AllowGet);
        }
        //
        //Get: /Hypertension/Import
        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Import(HttpPostedFileBase uploadFile)
        {
            StringBuilder strValidations = new StringBuilder(string.Empty);
            try
            {
                if (uploadFile.ContentLength > 0)
                {
                    //string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads"),
                    //Path.GetFileName(uploadFile.FileName));
                    //uploadFile.SaveAs(filePath);

                    //ExcelDataReader works on binary excel file
                    Stream stream = uploadFile.InputStream;
                    //We need to written the Interface.
                    IExcelDataReader reader = null;
                    if (uploadFile.FileName.EndsWith(".xls"))
                    {
                        //reads the excel file with .xls extension
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (uploadFile.FileName.EndsWith(".xlsx"))
                    {
                        //reads excel file with .xlsx extension
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //Shows error if uploaded file is not Excel file
                        ModelState.AddModelError("File", "This file format is not supported");
                        //return View();
                    }
                    //treats the first row of excel file as Coluymn Names
                    //reader.IsFirstRowAsColumnNames = true;

                    //Adding reader data to DataSet()
                    DataSet result = reader.AsDataSet();
                    reader.Close();

                    //Standardized data

                    var table = result.Tables[0];
                    var numrow = table.Rows.Count;
                    var break_firstline = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        if (row[table.Columns[0].ColumnName] != null && !string.IsNullOrEmpty(Convert.ToString(row[table.Columns[0].ColumnName])))
                        {
                            //break first row
                            if (break_firstline > 0)
                            {
                                //hospital
                                benhvien hp = new benhvien();
                                //patient
                                benhnhan pa = new benhnhan();
                                //benh su
                                benhsu bes = new benhsu();
                                //Huyetap
                                huyetap ha = new huyetap();
                                for (int i = 0; i < table.Columns.Count; i++)
                                {
                                    var col = row[table.Columns[i].ColumnName];
                                    if (i == 0)
                                    {
                                        //dau thoi gian
                                    }
                                    else if (i == 1)
                                    {
                                        //benh vien
                                        hp.tenbv = Convert.ToString(row[table.Columns[i].ColumnName]);
                                        hp.idbv = StandHAModels.generateBVID(8);

                                        //check insert hospital at here
                                        //if exist

                                        //else
                                    }
                                    else if (i == 2)
                                    {
                                        //khoa
                                    }
                                    else if (i == 3)
                                    {
                                        //giuong
                                    }
                                    else if (i == 4)
                                    {
                                        //so luu tru
                                        pa.soluutru = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 5)
                                    {
                                        //ma y te
                                    }
                                    else if (i == 6)
                                    {
                                        //ma benh nhan
                                    }
                                    else if (i == 7)
                                    {
                                        //ho va ten
                                        pa.tenbn = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 8)
                                    {
                                        //sinh ngay
                                        try
                                        {
                                            DateTime d = new DateTime(int.Parse(Convert.ToString(row[table.Columns[i].ColumnName])), 1, 1);
                                            pa.ngaysinh = d;
                                        }
                                        catch
                                        {

                                        }

                                    }
                                    else if (i == 9)
                                    {
                                        //gioi tinh
                                        String gender = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (gender == "nam")
                                        {
                                            pa.gioitinh = true;
                                        }
                                        else if (gender == "nu")
                                        {
                                            pa.gioitinh = false;
                                        }
                                        else
                                        {
                                            pa.gioitinh = true;
                                        }
                                    }
                                    else if (i == 10)
                                    {
                                        //nghe nghiep
                                        pa.nghenghiep = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 11)
                                    {
                                        //dan toc
                                        pa.dantoc = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 12)
                                    {
                                        //dia chi
                                        pa.diachi = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 13)
                                    {
                                        //huyen
                                    }
                                    else if (i == 14)
                                    {
                                        //thanh pho
                                    }
                                    else if (i == 15)
                                    {
                                        //tinh
                                    }
                                    else if (i == 16)
                                    {
                                        //noi lam viec
                                        pa.noilamviec = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 17)
                                    {
                                        //ngay vao vien
                                    }
                                    else if (i == 18)
                                    {
                                        //dien thoai
                                        pa.dienthoai = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 19)
                                    {
                                        //ly do vao vien
                                        ha.HA_I = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 20)
                                    {
                                        //A.Benh su
                                        ha.HA_II_A = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 21)
                                    {
                                        //Bản thân có mắc bệnh đái tháo đường không, rối loạn lipit máu, bệnh mạch vành, bệnh thận, có hút thuốc lá không
                                        string HA_II_B_1 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_II_B_1 == "co")
                                        {
                                            ha.HA_II_B_1 = true;
                                        }
                                        else if (HA_II_B_1 == "khong")
                                        {
                                            ha.HA_II_B_1 = false;
                                        }
                                    }
                                    else if (i == 22)
                                    {
                                        //* Diễn giải mục 1
                                        ha.HA_II_B_1_1 = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 23)
                                    {
                                        //2. Có dùng thuốc gì? Thuốc nội tiết, thuốc cường giao cảm, salbutamol, costisol
                                        string HA_II_B_2 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_II_B_2 == "co")
                                        {
                                            ha.HA_II_B_2 = true;
                                        }
                                        else if (HA_II_B_2 == "khong")
                                        {
                                            ha.HA_II_B_2 = false;
                                        }
                                    }
                                    else if (i == 24)
                                    {
                                        //* Diễn giải mục 2
                                        ha.HA_II_B_2_1 = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 25)
                                    {
                                        //3. Có thừa cân, béo phì (chiều cao, cân nặng BMI), lối sống ít vận động, ăn uống có thể liên quan đến tăng huyết áp
                                        string HA_II_B_3 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_II_B_3 == "co")
                                        {
                                            ha.HA_II_B_3 = true;
                                        }
                                        else if (HA_II_B_3 == "khong")
                                        {
                                            ha.HA_II_B_3 = false;
                                        }

                                    }
                                    else if (i == 26)
                                    {
                                        //* Diễn giải mục 3
                                        ha.HA_II_B_3_1 = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 27)
                                    {
                                        //4. Nếu là nữ có thai hay không?
                                        string HA_II_B_4 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_II_B_4 == "co")
                                        {
                                            ha.HA_II_B_4 = true;
                                        }
                                        else if (HA_II_B_4 == "khong")
                                        {
                                            ha.HA_II_B_4 = false;
                                        }
                                    }
                                    else if (i == 28)
                                    {
                                        //* Diễn giải mục 4
                                        ha.HA_II_B_4_1 = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 29)
                                    {
                                        //5. Tuổi xuất hiện cao huyết áp
                                        ha.HA_II_B_5 = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 30)
                                    {
                                        //6. Gia đình có ai mắc bệnh mãn tính gì không?
                                        string HA_II_B6 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_II_B6 == "co")
                                        {
                                            ha.HA_II_B_6 = true;
                                        }
                                        else if (HA_II_B6 == "khong")
                                        {
                                            ha.HA_II_B_6 = false;
                                        }
                                    }
                                    else if (i == 31)
                                    {
                                        //* Diễn giải mục 6
                                        ha.HA_II_B_6_1 = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 32)
                                    {
                                        //Mạch toàn thân (lần/phút)
                                        try
                                        {
                                            ha.HA_III_1_1 = float.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }


                                    }
                                    else if (i == 33)
                                    {
                                        //Nhiệt độ (độ C)
                                        try
                                        {
                                            ha.HA_III_1_2 = float.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 34)
                                    {
                                        //Huyết áp ngưỡng thấp (mmHg)
                                        try
                                        {
                                            ha.HA_III_1_3_1 = int.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 35)
                                    {
                                        //Huyết áp ngưỡng cao (mmHg)
                                        try
                                        {
                                            ha.HA_III_1_3_1 = int.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 36)
                                    {
                                        //Nhịp thở (lần/phút)
                                        try
                                        {
                                            ha.HA_III_1_4 = int.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 37)
                                    {
                                        //Cân nặng (Kg)
                                        try
                                        {
                                            ha.HA_III_1_5 = int.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 38)
                                    {
                                        //Chiều cao (mét)
                                        try
                                        {
                                            ha.HA_III_1_6 = int.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 39)
                                    {
                                        //2. Khám các bộ phận
                                        ha.HA_III_2 = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 40)
                                    {
                                        //- Công thức máu
                                        ha.HA_IV_1 = Convert.ToString(row[table.Columns[i].ColumnName]);
                                    }
                                    else if (i == 41)
                                    {
                                        //Glucose máu
                                        try
                                        {
                                            ha.HA_IV_2 = float.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 42)
                                    {
                                        //Ure
                                        try
                                        {
                                            ha.HA_IV_3 = float.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 43)
                                    {
                                        //CRP
                                        try
                                        {
                                            ha.HA_IV_4 = float.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 44)
                                    {
                                        //Acid uric
                                        try
                                        {
                                            ha.HA_IV_5 = float.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 45)
                                    {
                                        //Creatinin
                                        try
                                        {
                                            ha.HA_IV_6 = float.Parse(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else if (i == 46)
                                    {
                                        //7. Cholesteol bao nhiêu
                                        string HA_IV_7 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_IV_7 == "cao")
                                        {
                                            ha.HA_IV_7 = true;
                                        }
                                        else if (HA_IV_7 == "binhthuong")
                                        {
                                            ha.HA_IV_7 = false;
                                        }
                                    }
                                    else if (i == 47)
                                    {
                                        //* Diễn giải mục 7

                                    }
                                    else if (i == 48)
                                    {
                                        //8. Triglycerid bao nhiêu :
                                        string HA_IV_8 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_IV_8 == "cao")
                                        {
                                            ha.HA_IV_8 = true;
                                        }
                                        else if (HA_IV_8 == "binhthuong")
                                        {
                                            ha.HA_IV_8 = false;
                                        }
                                    }
                                    else if (i == 50)
                                    {
                                        //* Diễn giải mục 8

                                    }
                                    else if (i == 51)
                                    {
                                        //9. HDL-C bao nhiêu
                                        string HA_IV_9 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_IV_9 == "binhthuong")
                                        {
                                            ha.HA_IV_9 = true;
                                        }
                                        else if (HA_IV_9 == "khongbinhthuong")
                                        {
                                            ha.HA_IV_9 = false;
                                        }
                                    }
                                    else if (i == 52)
                                    {
                                        //* Diễn giải mục 9

                                    }
                                    else if (i == 53)
                                    {
                                        //10. LDL-C bao nhiêu
                                        string HA_IV_10 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_IV_10 == "caohonbinhthuong")
                                        {
                                            ha.HA_IV_10 = true;
                                        }
                                        else if (HA_IV_10 == "binhthuong")
                                        {
                                            ha.HA_IV_10 = false;
                                        }
                                    }
                                    else if (i == 54)
                                    {
                                        //* Diễn giải mục 10

                                    }
                                    else if (i == 55)
                                    {
                                        //11 a. XN: Điện giải đồ Na
                                        string HA_IV_11 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_IV_11 == "khonglam")
                                        {
                                            ha.HA_IV_11 = false;
                                        }
                                        else
                                        {
                                            ha.HA_IV_11 = true;
                                        }
                                    }
                                    else if (i == 56)
                                    {
                                        //11 b. XN: Điện giải đồ Kali

                                    }
                                    else if (i == 57)
                                    {
                                        //* Diễn giải mục 11b Kali bao nhiêu 

                                    }
                                    else if (i == 58)
                                    {
                                        //12. X-quang tim phổi
                                        string HA_IV_12 = StandString.FinalStandString(Convert.ToString(row[table.Columns[i].ColumnName]));
                                        if (HA_IV_12 == "binhthuong")
                                        {
                                            ha.HA_IV_12 = true;
                                        }
                                        else if (HA_IV_12 == "khongbinhthuong")
                                        {
                                            ha.HA_IV_12 = false;
                                        }
                                    }
                                    else if (i == 59)
                                    {
                                        //* Diễn giải mục 12

                                    }

                                }
                                System.Diagnostics.Debug.WriteLine(hp.tenbv);

                                //Compare let insert data to db
                                HospitalModels hphandler = new HospitalModels();
                                List<benhvien> lshp = hphandler.getAll();
                                benhvien check_hp = null;
                                for (int i = 0; i < lshp.Count; i++)
                                {
                                    benhvien hp_in_db = lshp[i];
                                    //System.Diagnostics.Debug.WriteLine(StandString.FinalStandString(hp_in_db.tenbv));
                                    if (StandString.FinalStandString(hp_in_db.tenbv).Contains(StandString.FinalStandString(hp.tenbv)))
                                    {
                                        check_hp = hp_in_db;
                                    }
                                }
                                if (check_hp != null)
                                {
                                    pa.idbv = check_hp.idbv;

                                }
                                else
                                {
                                    HospitalModels hpm = new HospitalModels();
                                    hpm.insert(hp);
                                    pa.idbv = hp.idbv;
                                }
                                pa.idbn = StandString.generateBNID(8);
                                bes.idbn = pa.idbn;
                                bes.idbs = StandString.generateBESID(8);
                                ha.idbs = bes.idbs;
                                ha.idhuyetap = bes.idbs;
                                //insert to db
                                PatientModels pa_model = new PatientModels();
                                pa_model.create(pa);
                                BenhsuModels bes_model = new BenhsuModels();
                                bes_model.insert(bes);
                                HuyetapModels ha_model = new HuyetapModels();
                                ha_model.insert(ha);
                            }
                            break_firstline++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View();
        }
        public ActionResult StatGender()
        {
            return View();
        }
        public ActionResult StatFamily()
        {
            return View();
        }
        public ActionResult StatHistory()
        {
            return View();
        }
        public ActionResult StatIndexs()
        {
            return View();
        }

        //
        public ActionResult jsonStatGender()
        {
            TayBacDBContext dbContext = new TayBacDBContext();
            var bn_huyetapp = from ha in dbContext.huyetaps
                              join bs in dbContext.benhsus on ha.idbs equals bs.idbs
                              join bn in dbContext.benhnhans on bs.idbn equals bn.idbn
                              group bn.idbn by bn.gioitinh into g
                              select new
                              {
                                  gioitinh = g.Key,
                                  num = g.Count()
                              };
            return Json(bn_huyetapp.ToList(), JsonRequestBehavior.AllowGet);
        }
        //
        public ActionResult jsonStatFamily()
        {
            TayBacDBContext dbContext = new TayBacDBContext();
            var bn_huyetapp = from ha in dbContext.huyetaps
                              join bs in dbContext.benhsus on ha.idbs equals bs.idbs
                              join bn in dbContext.benhnhans on bs.idbn equals bn.idbn
                              group bn.idbn by ha.HA_II_B_6 into g
                              select new
                              {
                                  HA_II_B_6 = g.Key,
                                  num = g.Count()
                              };
            return Json(bn_huyetapp.ToList(), JsonRequestBehavior.AllowGet);
        }
        //
        //[Permission(Constants.G_ADMIN), Permission(Constants.G_MANAGER)]
        public ActionResult jsonStatHistory()
        {
            TayBacDBContext dbContext = new TayBacDBContext();
            var bn_huyetapp = from ha in dbContext.huyetaps
                              join bs in dbContext.benhsus on ha.idbs equals bs.idbs
                              join bn in dbContext.benhnhans on bs.idbn equals bn.idbn
                              group bn.idbn by ha.HA_II_B_1 into g
                              select new
                              {
                                  HA_II_B_1 = g.Key,
                                  num = g.Count()
                              };
            return Json(bn_huyetapp.ToList(), JsonRequestBehavior.AllowGet);
        }
        //
        public ActionResult jsonStatIndexs()
        {
            TayBacDBContext dbContext = new TayBacDBContext();
            var bn_huyetapp = (from ha in dbContext.huyetaps
                               join bs in dbContext.benhsus on ha.idbs equals bs.idbs
                               join bn in dbContext.benhnhans on bs.idbn equals bn.idbn
                               //group bn.idbn by ha.HA_III_1_1 into g
                               select new
                               {
                                   HA_III_1_1 = ha.HA_III_1_1,//mach
                                   HA_III_1_2 = ha.HA_III_1_2,//nhiet do
                                   HA_III_1_3_1 = ha.HA_III_1_3_1,// huyet ap
                                   HA_III_1_3_2 = ha.HA_III_1_3_2,// huyet ap
                                   HA_III_1_4 = ha.HA_III_1_4, // nhip tho
                                   HA_III_1_5 = ha.HA_III_1_5, // can nang
                                   HA_III_1_6 = ha.HA_III_1_6 //chieu cao

                               }).ToList();
            //mach
            int HA_III_1_1_nhanh = 0;
            int HA_III_1_1_binhthuong = 0;
            int HA_III_1_1_cham = 0;
            //nhiet  do
            //huyet ap
            //nhip tho
            int HA_III_1_4_cham = 0;
            int HA_III_1_4_binhthuong = 0;
            int HA_III_1_4_nhanh = 0;
            //BMI
            int BMI_gay = 0;
            int BMI_binhthuong = 0;
            int BMI_thuacan = 0;
            foreach (var item in bn_huyetapp)
            {
                //mach
                if (item.HA_III_1_1 > 100)//nhanh
                {
                    HA_III_1_1_nhanh++;
                }
                else if (item.HA_III_1_1 >= 60 && item.HA_III_1_1 <= 100) // binh thuong
                {
                    HA_III_1_1_binhthuong++;
                }
                else if (item.HA_III_1_1 < 60) //cham
                {
                    HA_III_1_1_cham++;
                }

                //nhip tho
                if (item.HA_III_1_4 < 15)
                {
                    HA_III_1_4_cham++;
                }
                else if (item.HA_III_1_4 >= 15 && item.HA_III_1_4 <= 18)
                {
                    HA_III_1_4_binhthuong++;
                }
                else if (item.HA_III_1_4 > 18)
                {
                    HA_III_1_4_nhanh++;
                }

                //BMI
                Double bmi = Convert.ToDouble(item.HA_III_1_5) / Math.Pow(Convert.ToDouble(item.HA_III_1_6), Convert.ToDouble(2));
                if (bmi < 18.5)
                {
                    BMI_gay++;
                }
                else if (bmi >= 18.5 && bmi <= 24.99)
                {
                    BMI_binhthuong++;
                }
                else if (bmi >= 25)
                {
                    BMI_thuacan++;
                }
            }
            List<Array> ls_indexs = new List<Array>();
            int[] mach = new int[3];
            mach[0] = HA_III_1_1_nhanh;
            mach[1] = HA_III_1_1_binhthuong;
            mach[2] = HA_III_1_1_cham;
            ls_indexs.Add(mach);
            //
            int[] nhiptho = new int[3];
            nhiptho[0] = HA_III_1_4_nhanh;
            nhiptho[1] = HA_III_1_4_binhthuong;
            nhiptho[2] = HA_III_1_4_cham;
            ls_indexs.Add(nhiptho);
            //BMI
            int[] arr_bmi = new int[3];
            arr_bmi[0] = BMI_thuacan;
            arr_bmi[1] = BMI_binhthuong;
            arr_bmi[2] = BMI_gay;
            ls_indexs.Add(arr_bmi);

            return Json(ls_indexs, JsonRequestBehavior.AllowGet);
        }
    }
}
