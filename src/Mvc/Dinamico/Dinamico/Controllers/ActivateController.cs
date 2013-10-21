using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using Services;
using System;
using Dinamico.Models;
using System.Web.Security;

namespace Dinamico.Controllers
{
    //[Controls(typeof(Models.TestPage))]
    public class ActivateController : ContentController<Models.ContentPage>
    {

        public override ActionResult Index()
        {
            var code = Request.QueryString["code"] != null ? Request.QueryString["code"] : string.Empty;
            var id = Request.QueryString["id"] != null ? Request.QueryString["id"] : string.Empty;

            

            return View("/dinamico/Themes/Metro/Views/Shared/LayoutPartials/LogOn.cshtml");
        }

        public ActionResult Resend(int userid)
        {
            var user = N2.Context.Current.Persister.Get<UserProfilePage>(userid);
            var sender = N2.Context.Current.Persister.Get<UserProfilePage>(Session[SessionVars.Keys.ProfileId]) as UserProfilePage;
            EmailService.SendInvitationEmail(user, sender.Title, user.ActivationCode);
            
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
