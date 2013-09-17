using N2;
using N2.Details;
using N2.Persistence;
using N2.Definitions;
using System.Web.UI.WebControls;

namespace Dinamico.Models
{
    [PageDefinition]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class TestPage : PageModelBase, IContentPage, IStructuralPage
    {
        /// <summary>
        /// Image used on the page and on listings.
        /// </summary>
        [EditableMediaUpload(PreferredSize = "wide")]
        [Persistable(Length = 256)] // to minimize select+1
        public virtual string Image { get; set; }

        /// <summary>
        /// Title that replaces the regular title when not empty.
        /// </summary>
        [EditableText(Title = "SEO Title", ContainerName = Defaults.Containers.Metadata)]
        public virtual string SeoTitle { get; set; }

        /// <summary>
        /// Summary text displayed in listings.
        /// </summary>
        [EditableText(TextMode = TextBoxMode.MultiLine, Columns = 80, Rows = 2, ValidationExpression = ".*{0,1000", ValidationMessage = "Max 100 characters")]
        [Persistable(Length = 1024)] // to minimize select+1
        public virtual string Summary { get; set; }

        /// <summary>
        /// Main content of this content item.
        /// </summary>
        [EditableFreeTextArea]
        [DisplayableTokens]
        public virtual string Text { get; set; }
    }
}