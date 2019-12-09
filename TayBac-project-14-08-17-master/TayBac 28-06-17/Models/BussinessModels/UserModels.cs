using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TayBac_28_06_17.Models.DBContext;
using TayBac_28_06_17.Models.EntityModels;
using TayBac_28_06_17.Commons;

namespace TayBac_28_06_17.Models.BussinessModels
{
    
    public class UserModels
    {
        private TayBacDBContext dbContext = null;
        public UserModels()
        {
            dbContext = new TayBacDBContext();
        }
        public bool saveImg(string id, byte[] img)
        {
            user u = dbContext.users.Find(id);
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
        public user detail(string id)
        {
            return dbContext.users.Find(id);
        }
        public bool delete(string id)
        {
            try
            {
                var user = dbContext.users.Find(id);
                if (user.kieuuser == Constants.G_ADMIN)
                {
                    return false;
                }
                dbContext.users.Remove(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool insert(user user)
        {
            user.idnd = createUserId(user);
            dbContext.users.Add(user);
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private string createUserId(user u)
        {
            return u.account;
        }
        public int changePass(string id, string oldPass, string newPass1, string newPass2)
        {
            var user = dbContext.users.Find(id);
            if (user == null)
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
            if (!oldPass.Equals(user.pass))
            {
                return -3;
            }
            user.pass = newPass1;
            try
            {
                dbContext.SaveChanges();

            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }
        public int update(user user, int options)
        {
            var u = dbContext.users.Find(user.idnd);
            if (u == null)
            {
                return 0;
            }
            if (String.IsNullOrEmpty(user.idbv))
            {
                user.idbv = u.idbv;
            }
            if (String.IsNullOrEmpty(user.tennd))
            {
                user.tennd = u.tennd;
            }
            if (!String.IsNullOrEmpty(user.pass))
            {
                u.pass = user.pass;
            }
            u.tennd = user.tennd;
            u.dienthoai = user.dienthoai;
            u.email = user.email;
            u.ngaysinh = user.ngaysinh;
            u.idbv = user.idbv;
            u.chucvu = user.chucvu;
            u.idxa = user.idxa;
            u.idtinh = user.idtinh;
            u.idhuyen = user.idhuyen;
            u.updatetime = user.updatetime;
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
        public int updateAdmin(user user)
        {
            var u = dbContext.users.Find(user.idnd);
            if (u == null)
            {
                return 0;
            }
            //Neu khong la admin
            if (u.kieuuser != Constants.G_ADMIN)
            {
                return -3;
            }
            if (String.IsNullOrEmpty(user.idbv))
            {
                return -1;
            }
            if (String.IsNullOrEmpty(user.tennd))
            {
                return -2;
            }
            if (!String.IsNullOrEmpty(user.pass))
            {
                u.pass = user.pass;
            }
            u.tennd = user.tennd;
            u.dienthoai = user.dienthoai;
            u.email = user.email;
            u.ngaysinh = user.ngaysinh;
            u.idbv = user.idbv;
            u.chucvu = user.chucvu;
            u.xa = user.xa;
            u.tinh = user.tinh;
            u.huyen = user.huyen;
            u.updatetime = user.updatetime;
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
        public List<user> getAll()
        {

            return dbContext.users.ToList();
        }
    }
}