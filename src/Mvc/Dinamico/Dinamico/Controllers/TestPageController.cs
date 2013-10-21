using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using Services;
using System;

namespace Dinamico.Controllers
{
    [Controls(typeof(Models.TestPage))]
    public class TestPageController : ContentController<Models.ContentPage>
    {

        public override ActionResult Index()
        {
            return View(CurrentItem.TemplateKey, CurrentItem);
        }

        public ActionResult SendMail()
        {
            //var sendMail = EmailService.sendMail("Lorem ipsum from Vauzo", "admin@familydetails.com", "ldc0618@cox.net", "", "", "admin@familydetails.com", "Activate your intanet account", "Activate your intanet account", "John Doe has invited to join", "localhost:8700", "Target Corp", "activate.jpg", "activate.jpg");
            var status = EmailService.sendTextMail("ldc0618@cox.net", "", "ldc0618@gmail.com", "Jim Bonzo has invited you to join ABC Intranet", "John Doe has invited to join<br> <a href='www.vauzo.com/activate'>Activate Account</a>");
            return Content(status);
        }
    }
}
