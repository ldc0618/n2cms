using System;
using System.Web.UI;
using N2.Resources;
using N2.Web;

namespace N2.Edit
{
	public partial class Framed : MasterPage
	{
		public override string ID
		{
			get { return base.ID ?? "F"; }
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			Register.JQuery(Page);

            if(Request.QueryString["returnUrl"] != null)
                Session["LastContentPageUrl"] = Request.QueryString["returnUrl"];

            if (Session["LastContentPageUrl"] == null)
                Session["LastContentPageUrl"] = "/";
		}

		protected override void OnPreRender(EventArgs e)
		{
			if (h1 != null)
			{
				h1.InnerHtml = Page.Title;
				h1.Visible = !string.IsNullOrEmpty(Page.Title);
			}

            hlBack.NavigateUrl = Session["LastContentPageUrl"].ToString();

			base.OnPreRender(e);
		}

		protected string MapCssUrl(string cssFileName)
		{
			return Url.ToAbsolute(N2.Context.Current.ManagementPaths.GetEditInterfaceUrl() + "../Resources/Css/" + cssFileName);
		}
	}
}