using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;
using TayBac_28_06_17.Commons;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class HuyetapModels
    {
        private TayBacDBContext dbContext = null;
        public HuyetapModels()
        {
            dbContext = new TayBacDBContext();
        }
        public bool insert(huyetap ha)
        {
            dbContext.huyetaps.Add(ha);
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool update(huyetap ha)
        {
            try
            {
                dbContext.huyetaps.Attach(ha);
                dbContext.Entry(ha).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool delete(huyetap ha)
        {
            try
            {
                dbContext.huyetaps.Remove(ha);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public huyetap getByID(string id)
        {
            return dbContext.huyetaps.Find(id);
        }
        public bool checkHospital(String str)
        {

            return false;
        }
    }
}