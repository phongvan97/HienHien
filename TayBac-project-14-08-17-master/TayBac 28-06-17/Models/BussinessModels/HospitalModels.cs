using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class HospitalModels
    {
        private TayBacDBContext dbContext = null;
        public HospitalModels()
        {
            dbContext = new TayBacDBContext();
        }
        public bool insert(benhvien h)
        {
            try
            {
                dbContext.benhviens.Add(h);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool delete(string id)
        {
            benhvien h = dbContext.benhviens.Find(id);
            try
            {
                //  dbContext.Hospital.Remove(h);
                h.trangthai = false;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public benhvien details(string id)
        {
            return dbContext.benhviens.Find(id);
        }
        public IEnumerable<SelectListItem> getListHospitals()
        {
            var model = dbContext.benhviens.Select(h => new SelectListItem
            {
                Value = h.idbv,
                Text = h.tenbv
            });

            return model;
        }
        public int update(benhvien hospital)
        {
            var h = dbContext.benhviens.Find(hospital.idbv);
            if (h == null)
            {
                return 0;
            }

            if (String.IsNullOrEmpty(hospital.tenbv))
            {
                return -2;
            }
            h.tenbv = hospital.tenbv;
            h.IP = hospital.IP;
            h.dienthoai = hospital.dienthoai;
            h.fax = hospital.fax;
            h.idhuyen = hospital.idhuyen;
            h.idxa = hospital.idxa;
            h.idtinh = hospital.idtinh;
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
        public List<benhvien> getAll()
        {
            return dbContext.benhviens.ToList();
        
        }
        //
        public int numberHps(string tenbv)
        {
            var q = dbContext.benhviens.Where(x => x.tenbv.Contains(tenbv));
            return q.Count();
        }
    }
}