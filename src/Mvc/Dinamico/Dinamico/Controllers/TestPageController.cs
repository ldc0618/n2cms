using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;

namespace Dinamico.Controllers
{
    [Controls(typeof(Models.TestPage))]
    public class TestPageController : ContentController<Models.ContentPage>
    {

        public override ActionResult Index()
        {
            return View(CurrentItem.TemplateKey, CurrentItem);
        }
    }
}
