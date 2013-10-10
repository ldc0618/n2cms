using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dinamico.Dinamico
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View("/dinamico/Themes/Metro/Views/Shared/LayoutPartials/LogOn.cshtml");
        }

        public ActionResult Validate(string username, string password, int? rememberMe, string returnUrl)
        {
            if (FormsAuthentication.Authenticate(username, password)
                    || (System.Web.Security.Membership.ValidateUser(username, password) && System.Web.Security.Membership.GetUser(username).IsApproved))
            {
                return Content("true");
            }

            return Content("false");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Auth(string username, string password, int? rememberMe, string returnUrl)
        {
            bool remember = rememberMe.HasValue && rememberMe.Value == 1 ? true : false;
            try
            {
                if (FormsAuthentication.Authenticate(username, password)
                    || (System.Web.Security.Membership.ValidateUser(username, password) && System.Web.Security.Membership.GetUser(username).IsApproved))
                {
                    //e.Authenticated = true;
                    //Travis Pettijohn - Oct 2010 - pettijohn.com
                    //Using FormsAuthentication.RedirectFromLoginPage crashes the Azure dev fabric load balancer (dfloadbalancer.exe).
                    //Switching up the logic to set the cookie and redirect here with endResponse set to TRUE fixes the glitch. 
                    //FormsAuthentication.RedirectFromLoginPage(username, rememberMe);
                    FormsAuthentication.SetAuthCookie(username, remember);
                    string returnUrl2 = FormsAuthentication.GetRedirectUrl(username, remember);
                    Response.Redirect(returnUrl2, true);
                }
            }
            catch (Exception ex)
            {
                N2.Engine.Logger.Warn(ex);
                //e.Authenticated = false;
                Response.Redirect("/", true);
            }

            return Redirect("/");
        }

    }
}
