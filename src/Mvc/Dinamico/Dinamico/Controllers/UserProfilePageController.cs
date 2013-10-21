using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using System.Web.Security;
using Dinamico.Models;
using Services;
using System;
using N2;

namespace Dinamico.Controllers
{
    [Controls(typeof(Models.UserProfilePage))]
    public class UserProfilePageController : ContentController<Models.UserProfilePage>
    {
        public override ActionResult Index()
        {
            return View(CurrentItem.TemplateKey, CurrentItem);
        }

        //protected override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    //
        //    HandleUserProfileSave(filterContext);
            
        //    base.OnResultExecuting(filterContext);
        //}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HandleUserProfileSave(filterContext);
            base.OnActionExecuting(filterContext);
        }

        private void HandleUserProfileSave(ActionExecutingContext ctx)
        {
            var item = CurrentItem;
            var password = new RandomPasswordGenerator().RandomString(8);
            if (item.GetType().ToString().Contains("UserProfilePage"))
            {
                var user = item as UserProfilePage;
                if (string.IsNullOrEmpty(user.ActivationCode))
                {
                    item.ActivationCode = password;
                    N2.Context.Persister.Save(item);
                }
                ProcessNewUser(user, password);

            }
        }

        private void ProcessNewUser(UserProfilePage user, string password)
        {
            MembershipUser muser = System.Web.Security.Membership.FindUsersByName(user.UserName)[user.UserName];
            if (muser == null)
            {
                //var password = new RandomPasswordGenerator().RandomString(8);
                var guid1 = System.Guid.NewGuid().ToString();
                var guid2 = System.Guid.NewGuid().ToString();
                var status = new  MembershipCreateStatus();

                var newUser = new N2.Security.ContentMembershipProvider().CreateUser(user.UserName, password, user.Email, guid1, guid2, true, null, out status);

                Roles.AddUserToRole(user.UserName, "Members");

                var sender = User.Identity.Name;
                
                EmailService.SendInvitationEmail(user, sender, user.ActivationCode);
                 
            }
        }

        private void CreateActivationRecord()
        {
            
        }


    }
}
