using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dinamico.Controllers
{
    public class ManagementController : Controller
    {
        //
        // GET: /Management/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetVersionInfo()
        {
            //return Content("dddddddddddddddddd");
            return View("LayoutPartials/PageMessage");
        }

    }
}
