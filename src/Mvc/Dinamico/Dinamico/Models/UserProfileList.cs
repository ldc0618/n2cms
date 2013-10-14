using System;
using System.Collections.Generic;
using System.Linq;
using N2.Collections;
using N2.Details;
using N2.Integrity;
using N2.Templates.Mvc.Models.Pages;
using System.Web.UI.WebControls;

namespace N2.Templates.Mvc.Models.Parts
{
	[PartDefinition("User Profile List",
		Description = "A news list box that can be displayed in a column.",
		SortOrder = 160,
		IconUrl = "~/Content/Img/newspaper_go.png")]
	[WithEditableTitle("Title", 10, Required = false)]
	public class UserProfileList : SidebarItem
	{
		public enum HeadingLevel
		{
			One = 1,
			Two = 2,
			Three = 3,
			Four = 4
		}

	}
}