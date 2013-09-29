using System.Web.Mvc;
using System.Linq;
using N2.Web;
using N2.Web.Mvc;
using N2;
using N2.Edit;
using N2.Edit.Versioning;


namespace Dinamico.Controllers
{
	[Controls(typeof(Models.ContentPage))]
	public class ContentPagesController : ContentController<Models.ContentPage>
	{
        protected IEditUrlManager ManagementPaths;

		public override ActionResult Index()
		{


            ViewBag.HasNewerVersion = false;
            if (CurrentItem.VersionOf.HasValue)
            {
                ViewBag.LatestDraftVersion = CurrentItem.VersionOf;
            }
            else
            {
                var page = Find.ClosestPage(CurrentItem);
                var version = Engine.Resolve<N2.Edit.Versioning.DraftRepository>().FindDrafts(page).FirstOrDefault();
                if (version != null && version.Saved > CurrentItem.Updated)
                {
                    ViewBag.HasNewerVersion = true;
                    ViewBag.LatestDraftVersion = version.VersionIndex; // version.Version.FindPartVersion(CurrentItem);
                    //string url = N2.Web.Url.ToAbsolute(ManagementPaths.GetEditExistingItemUrl(version.Version.FindPartVersion(CurrentItem)));
                }
            }

			return View(CurrentItem.TemplateKey, CurrentItem);
		}


	}
}
