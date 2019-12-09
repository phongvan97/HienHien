using System;
using System.Collections.Generic;
using System.Linq;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class DoctorModels
    {
        private TayBacDBContext dbContext = null;
        public DoctorModels()
        {
            dbContext = new TayBacDBContext();
        }
        public bool saveImg(string id, byte[] img)
        {
            bacsy u = dbContext.bacsies.Find(id);
            //  u.image = new byte[img.Length];
            u.image = img;
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
                var doctor = dbContext.bacsies.Find(id);
                dbContext.bacsies.Remove(doctor);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public int update(bacsy doctor)
        {
            var d = dbContext.bacsies.Find(doctor.idbsy);
            if (d == null)
            {
                return 0;
            }
            if (String.IsNullOrEmpty(doctor.idbv))
            {
                doctor.idbv = d.idbv;
            }
            if (String.IsNullOrEmpty(doctor.tenbs))
            {
                doctor.tenbs = d.tenbs;
            }
            if (!String.IsNullOrEmpty(doctor.pass))
            {
                d.pass = doctor.pass;
            }
            d.tenbs = doctor.tenbs;
            d.dienthoai = doctor.dienthoai;
            d.email = doctor.email;
            d.ngaysinh = doctor.ngaysinh;
            d.idbv = doctor.idbv;
            d.chucvu = doctor.chucvu;
            d.idxa = doctor.idxa;
            d.idtinh = doctor.idtinh;
            d.idhuyen = doctor.idhuyen;
            d.updatetime = doctor.updatetime;
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
            var doctor = dbContext.bacsies.Find(id);
            if (doctor == null)
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
            if (!oldPass.Equals(doctor.pass))
            {
                return -3;
            }
            doctor.pass = newPass1;
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
        public bool insert(bacsy doctor)
        {
            
            dbContext.bacsies.Add(doctor);
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
        public string createDoctorId()
        {
            string id = "BS" + DateTime.Now.Second + dbContext.bacsies.Count();
            return id;
        }
        public bacsy detail(string id)
        {
            return dbContext.bacsies.Find(id);
        }
        public bool create(bacsy doctor)
        {
            dbContext.bacsies.Add(doctor);
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

        public List<bacsy> getAll()
        {
            return dbContext.bacsies.ToList();
        }
    }
}