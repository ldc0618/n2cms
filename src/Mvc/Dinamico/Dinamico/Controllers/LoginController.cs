using Dinamico.Models;
using Services;
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
            ViewBag.AccountJustActivated = null;
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

        public ActionResult ChangePassword(string password, string returnUrl)
        {
            ViewBag.OldPasswordBad = false;
            ViewBag.PasswordMismatch = false;
            ViewBag.PasswordChangedSucess = false;
            return View("/dinamico/Themes/Metro/Views/Shared/LayoutPartials/ChangePassword.cshtml");
        }

        [ValidateAntiForgeryToken]
        public ActionResult ChangePasswordSubmit(string oldPassword, string newPassword, string newPasswordConfirm, string returnUrl)
        {
            ViewBag.OldPasswordBad = false;
            ViewBag.PasswordMismatch = false;
            ViewBag.PasswordChangedSucess = false;
            string view = "/dinamico/Themes/Metro/Views/Shared/LayoutPartials/ChangePassword.cshtml";
            string username = SessionService.Current.UserName;
            if (FormsAuthentication.Authenticate(username, oldPassword)
                    || (System.Web.Security.Membership.ValidateUser(username, oldPassword)
                    && System.Web.Security.Membership.GetUser(username).IsApproved))
            {            }
            else
            {
                ViewBag.OldPasswordBad = true;
                return View(view);
            }

            if (newPassword != newPasswordConfirm)
            {
                ViewBag.PasswordMismatch = true;
                return View(view);
            }

            var user = System.Web.Security.Membership.GetUser(username);

            string tempPW = user.ResetPassword();
            bool ok = user.ChangePassword(tempPW, newPassword);

            ViewBag.PasswordChangedSucess = user.ChangePassword(tempPW, newPassword);
            
            return View(view);
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
                    var user = System.Web.Security.Membership.GetUser(username);
                    var profile = new ProfileService().GetProfileByEmail(user.Email);

                    //var footerPages = N2.Find.Items.Where.Type.Eq(typeof(UserProfilePage)).And(x => x.Details.ContainsKey("Email") && (bool)x.Details["Email"].Value == user.Email).Select(x => x as UserProfilePage);


                    SessionService.Current.UserName = user.UserName;
                    SessionService.Current.UserEmail = user.Email;
                    SessionService.Current.ProfileId = profile.ID;
                    SessionService.Current.DisplayName = profile.Title;
                    SessionService.Current.ProfileUrl = profile.Url;


                    //e.Authenticated = true;
                    //Travis Pettijohn - Oct 2010 - pettijohn.com
                    //Using FormsAuthentication.RedirectFromLoginPage crashes the Azure dev fabric load balancer (dfloadbalancer.exe).
                    //Switching up the logic to set the cookie and redirect here with endResponse set to TRUE fixes the glitch. 
                    //FormsAuthentication.RedirectFromLoginPage(username, rememberMe);
                    FormsAuthentication.SetAuthCookie(username, remember);
                    string returnUrl2 = FormsAuthentication.GetRedirectUrl(username, remember);
                    returnUrl2 = returnUrl2 == "/default.aspx" ? "/" : returnUrl2;
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


        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string email)
        {
            ViewBag.PasswordSentMessageHeader = "Whoops!";
            ViewBag.PasswordSentMessageCss = "error";
            ViewBag.AccountJustActivated = null;
            ViewBag.PasswordSentMessage = EmailService.ForgotPasswordEmail(email);

            if (ViewBag.PasswordSentMessage.Contains("Success"))
            {
                ViewBag.PasswordSentMessageHeader = "Success!";
                ViewBag.PasswordSentMessageCss = "success";
            }
            
            return View("/dinamico/Themes/Metro/Views/Shared/LayoutPartials/LogOn.cshtml");
        }

        public ActionResult CheckSessoinValid()
        {

            var valid = "0";
            if (!string.IsNullOrEmpty(SessionService.Current.DisplayName))
            {
                valid = "1";
                //Response.Redirect("/Membership/LogOff");
            }

            return Json(valid, JsonRequestBehavior.AllowGet);
        }
    }
}
