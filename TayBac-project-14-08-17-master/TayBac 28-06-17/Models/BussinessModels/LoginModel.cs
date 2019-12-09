using System.Linq;
using TayBac_28_06_17.Commons;
using TayBac_28_06_17.Models.DBContext;
namespace TayBac_28_06_17.Models.BussinessModels
{
    public class LoginModel
    {
        private TayBacDBContext dbContext = null;

        public LoginModel()
        {
            dbContext = new TayBacDBContext();
        }
        public object CheckAccount(string id, string pass, string group)
        {
            if (group == Constants.G_ADMIN)
            {
                var admin = dbContext.users.Where(a => a.idnd == id && a.pass == pass && a.kieuuser == "ADMIN").SingleOrDefault();
                if (admin != null)
                {
                    return admin;
                }

            }
            if (group == Constants.G_STAFF)
            {
                var staff = dbContext.users.Where(s => s.idnd == id && s.pass == pass && s.kieuuser == "STAFF").SingleOrDefault();
                if (staff != null)
                {
                    return staff;
                }
            }
            if (group == Constants.G_DOCTOR)
            {
                var doctor = dbContext.bacsies.Where(s => s.idbsy == id && s.pass == pass).SingleOrDefault();
                if (doctor != null)
                {
                    return doctor;
                }
            }
            if (group == Constants.G_PATIENT)
            {
                var patient = dbContext.benhnhans.Where(p => p.idbn == id && p.pass == pass).SingleOrDefault();
                if (patient != null)
                {
                    return patient;
                }

            }
            return null;
        }

    }
}