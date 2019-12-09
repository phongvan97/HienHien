using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class BenhsuModels
    {
        private TayBacDBContext dbContext = null;
        public BenhsuModels()
        {
            dbContext = new TayBacDBContext();
        }
        public benhsu getByID(string id)
        {
            return dbContext.benhsus.Find(id);
        }
        public bool insert(benhsu benhsu)
        {
            dbContext.benhsus.Add(benhsu);
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
    }
}