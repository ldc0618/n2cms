using System.Web.Mvc;
using System.Linq;
using N2.Web;
using N2.Web.Mvc;
using N2;
using N2.Edit;
using N2.Edit.Versioning;
using N2.Security;


namespace Dinamico.Controllers
{
	[Controls(typeof(Models.ContentPage))]
	public class ContentPagesController : ContentController<Models.ContentPage>
	{
        protected IEditUrlManager ManagementPaths;

		public override ActionResult Index()
		{

            if (string.IsNullOrEmpty(SessionService.Current.DisplayName))
            {
                return Redirect("/Membership/LogOff");
            }

            ViewBag.HasNewerVersion = false;
            if (CurrentItem.VersionOf.HasValue)
            {
                ViewBag.PublishedVersion = CurrentItem.VersionOf;
            }
            else
            {
                //bool canEdit = N2.Security.Permission..Edit & GetRolePermissions(contentitem)==Permissions.Edit) && (contentitem.GetPrincipalPermissions(principal)&Permissions.Edit==Permissions.Edit)
                //var isPublicableByUser = CurrentPage. new N2.Security.SecurityManager().SecurityEnforcer()..SecurityManager().IsEditor(User).isIsAuthorized(User, CurrentPage, Permission.Publish);
                var page = Find.ClosestPage(CurrentItem);
                ViewBag.PublishedUrl = page.RewrittenUrl;
                ViewBag.PublishedVersion = page.VersionIndex;
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
