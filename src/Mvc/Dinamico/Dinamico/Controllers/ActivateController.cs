using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using Services;
using System;
using Dinamico.Models;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace Dinamico.Controllers
{
    //[Controls(typeof(Models.TestPage))]
    public class ActivateController : ContentController<Models.ContentPage>
    {

        public override ActionResult Index()
        {
            var code = Request.QueryString["code"] != null ? Request.QueryString["code"] : string.Empty;
            if (!string.IsNullOrEmpty(code))
            {
                //activate account
                var profile = new Services.ProfileService().GetProfileByActivationCode(code);
                profile.ActivationDate = DateTime.Now;
                N2.Context.Persister.Save(profile);
            }

            ViewBag.AccountJustActivated = "true";

            return View("/dinamico/Themes/Metro/Views/Shared/LayoutPartials/LogOn.cshtml");
        }

        public ActionResult Resend(int userid)
        {
            var user = N2.Context.Current.Persister.Get<UserProfilePage>(userid);
            EmailService.SendInvitationEmail(user, user.ActivationCode);
            
            return Content(string.Format("Invitation resent to {0} at {1}", user.Title, user.Email)); 
        }

        private void ActivateAccount(UserProfilePage user)
        {
            var account = N2.Context.Current.Persister.Get<UserProfilePage>(user.ID);
        }

        public ActionResult AddTest()
        {
            var record = new AccoutActivation();
            var parent = N2.Find.RootItem;
            parent.Children.Add(record);

            N2.Context.Persister.Save(parent);

            return Content("ok");
        }


    }
}
