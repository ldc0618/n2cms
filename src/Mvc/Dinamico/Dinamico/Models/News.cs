using System.Web.UI.WebControls;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Templates.Mvc.Services;
using N2.Web.Mvc;
using N2.Persistence;
using System.Collections.Generic;
using System;

namespace N2.Templates.Mvc.Models.Pages
{
	[PageDefinition("News", Description = "A news page.", SortOrder = 155,
		IconClass = "n2-icon-file blue")]
	[RestrictParents(typeof (NewsContainer))]
	public class News : ContentPageBase, ISyndicatable
	{
		public News()
		{
			Visible = false;
			Syndicate = true;
		}

		[Obsolete("Use Summary")]
		[DisplayableLiteral]
		public virtual string Introduction { get { return Summary; } }

		[Persistable(PersistAs = PropertyPersistenceLocation.Detail)]
		public virtual bool Syndicate { get; set; }

		[EditableTags(SortOrder = 200)]
		public virtual IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Image used on the page and on listings.
        /// </summary>
        [EditableMediaUpload(PreferredSize = "wide")]
        [Persistable(Length = 256)] // to minimize select+1
        public virtual string Image { get; set; }
	}
}