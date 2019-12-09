using System;
using System.Collections.Generic;
using System.Linq;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class PatientModels
    {
        private TayBacDBContext dbContext = null;
        public PatientModels()
        {
            dbContext = new TayBacDBContext();
        }
        public bool saveImg(string id, byte[] img)
        {
            benhnhan p = dbContext.benhnhans.Find(id);
            //  u.image = new byte[img.Length];
            p.image = img;
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool delete(string id)
        {
            try
            {
                var p = dbContext.benhnhans.Find(id);
                dbContext.benhnhans.Remove(p);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<benhnhan> getAll()
        {
            return dbContext.benhnhans.ToList();
        }
        public bool insert(benhnhan p)
        {

            try
            {
                dbContext.benhnhans.Add(p);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string createPatienId()
        {
            string id = "BN" + DateTime.Now.Second + dbContext.benhnhans.Count();
            return id;
        }
        public int update(benhnhan patient)
        {
            var p = dbContext.benhnhans.Find(patient.idbn);
            if (p == null)
            {
                return 0;
            }
            if (String.IsNullOrEmpty(patient.idbv))
            {
                patient.idbv = p.idbv;
            }
            if (String.IsNullOrEmpty(patient.tenbn))
            {
                patient.tenbn = p.tenbn;
            }
            p.tenbn = patient.tenbn;
            p.dienthoai = patient.dienthoai;
            p.email = patient.email;
            p.ngaysinh = patient.ngaysinh;
            p.idxa = patient.idxa;
            p.idtinh = patient.idtinh;
            p.idhuyen = patient.idhuyen;
            p.nghenghiep = patient.nghenghiep;
            p.noilamviec = patient.noilamviec;
            try
            {
                dbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int changePass(string id, string oldPass, string newPass1, string newPass2)
        {
            var patient = dbContext.benhnhans.Find(id);
            if (patient == null)
            {
                return 0;
            }
            if (String.IsNullOrEmpty(newPass1))
            {
                return -1;
            }
            if (!newPass1.Equals(newPass2))
            {
                return -2;
            }
            if (!oldPass.Equals(patient.pass))
            {
                return -3;
            }
            patient.pass = newPass1;
            try
            {
                dbContext.SaveChanges();

            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }
        public benhnhan detail(string id)
        {
            return dbContext.benhnhans.Find(id);
        }

        public bool create(benhnhan patient)
        {
            dbContext.benhnhans.Add(patient);
            try
            {
                dbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}