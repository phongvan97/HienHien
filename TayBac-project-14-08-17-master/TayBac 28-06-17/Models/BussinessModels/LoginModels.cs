using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Commons;

namespace TayBac_28_06_17.Models.BussinessModels
{
    public class LoginModels
    {
        TayBacDBContext dbContext = null;
        public LoginModels()
        {
            dbContext = new TayBacDBContext();
        }
        public object CheckAccount(string username, string pass, string group)
        {
            var u = dbContext.users.Find("1");
            if (group == Constants.G_DOCTOR)
            {
                var doctor = dbContext.bacsies.Where(s => s.idbsy == username && s.pass == pass).SingleOrDefault();
                if (doctor != null)
                {
                    return doctor;
                }
                return null;
            }
            if (group == Constants.G_STAFF)
            {
                var staff = dbContext.users.Where(s => s.account == username && s.pass == pass && s.kieuuser == Constants.G_STAFF).SingleOrDefault();
                if (staff != null)
                {
                    return staff;
                }
                return null;
            }
            if (group == Constants.G_MANAGER)
            {
                var manager = dbContext.users.Where(m => m.account == username && m.pass == pass && m.kieuuser == Constants.G_MANAGER).SingleOrDefault();
                if (manager != null)
                {
                    return manager;
                }
                return null;
            }
            if (group == Constants.G_ADMIN)
            {
                var admin = dbContext.users.Where(a => a.account == username && a.pass == pass && a.kieuuser == Constants.G_ADMIN).SingleOrDefault();
                if (admin != null)
                {
                    return admin;
                }
                return null;

            }
            if (group == Constants.G_PATIENT)
            {
                var patient = dbContext.benhnhans.Where(p => p.idbn == username && p.pass == pass).SingleOrDefault();
                if (patient != null)
                {
                    return patient;
                }
                return null;
            }
            return null;
        }

    }
}