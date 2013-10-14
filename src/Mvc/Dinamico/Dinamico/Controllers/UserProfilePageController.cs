using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;

namespace Dinamico.Controllers
{
    [Controls(typeof(Models.UserProfilePage))]
    public class UserProfilePageController : ContentController<Models.UserProfilePage>
    {
        public override ActionResult Index()
        {
            return View(CurrentItem.TemplateKey, CurrentItem);
        }
    }
}
