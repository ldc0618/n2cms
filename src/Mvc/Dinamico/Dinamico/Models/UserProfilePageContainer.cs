using System.Collections.Generic;
using System.Linq;
using N2.Collections;
using N2.Integrity;
using N2.Web.Mvc;
using N2.Definitions;
using Dinamico.Models;

namespace N2.Templates.Mvc.Models.Pages
{
	[PageDefinition("User Profile Pages Container",
		Description = "An employee directory.",
		SortOrder = 150,
		IconClass = "n2-icon-list blue")]
	[RestrictParents(typeof (IStructuralPage))]
	[SortChildren(SortBy.PublishedDescending)]
	[GroupChildren(GroupChildrenMode.AlphabeticalIndex)]
	public class UserProfilePageContainer : UserProfilePage
	{
        public IList<UserProfilePage> NewsItems
		{
            get { return GetChildren(new TypeFilter(typeof(UserProfilePage))).OfType<UserProfilePage>().ToList(); }
		}
	}
}