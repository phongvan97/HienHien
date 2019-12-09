using System.Linq;
using System.Web;
using System.Web.Mvc;
using TayBac_28_06_17.Commons;

namespace TayBac_28_06_17.AuthorizationAttributes
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        private string[] permistion;
        public PermissionAttribute(params string[] roles)
        {
            permistion = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            
            var AccountGroup = HttpContext.Current.Session[Constants.SESSION_GROUPID];

            if (AccountGroup != null)
            {
                string group = AccountGroup.ToString();
                return permistion.Contains(group);
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Login/NotAuthorize.cshtml"
            };
        }

    }
}