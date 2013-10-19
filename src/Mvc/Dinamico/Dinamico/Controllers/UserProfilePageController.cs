using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using System.Web.Security;
using Dinamico.Models;

namespace Dinamico.Controllers
{
    [Controls(typeof(Models.UserProfilePage))]
    public class UserProfilePageController : ContentController<Models.UserProfilePage>
    {
        public override ActionResult Index()
        {
            return View(CurrentItem.TemplateKey, CurrentItem);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //
            HandleUserProfileSave(filterContext);
            
            base.OnResultExecuting(filterContext);
        }

        private void HandleUserProfileSave(ResultExecutingContext ctx)
        {
            var item = CurrentItem;
            if (item.GetType().ToString().Contains("UserProfilePage"))
            {
                var user = item as UserProfilePage;
                ProcessNewUser(user);

            }
        }

        private void ProcessNewUser(UserProfilePage user)
        {
            MembershipUser muser = System.Web.Security.Membership.FindUsersByName(user.UserName)[user.UserName];
            if (muser == null)
            {
                var password = new RandomPasswordGenerator().RandomString(8);
                var newUser = Membership.CreateUser(user.UserName, password, user.Email);

                Roles.AddUserToRole(user.UserName, "Members");
            }
        }
    }
}
