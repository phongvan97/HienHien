using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TayBac_28_06_17.Models.EntityModels;
using TayBac_28_06_17.Commons;

namespace TayBac_28_06_17.Models.DBContext
{
    public class DbInit : CreateDatabaseIfNotExists<TayBacDBContext>
    {
        protected override void Seed(TayBacDBContext context)
        {

            benhvien bv = new benhvien()
            {
                idbv = "idbv",
                tenbv = "tenbv"
            };
            context.benhviens.Add(bv);
            context.SaveChanges();
            user user1 = new user()
            {
                account = "hienhien",
                pass = "123456",
                idbv = "idbv",
                tennd = "tennd",
                idnd = "idnd",
                kieuuser=Constants.G_ADMIN
                

            };
            context.users.Add(user1);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}