using N2;
using N2.Details;
using N2.Persistence;
using N2.Definitions;
using System.Web.UI.WebControls;

namespace Dinamico.Models
{
    
    [PageDefinition("User Profile Page")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class UserProfilePage : PageModelBase, IContentPage, IStructuralPage
    {
        /// <summary>
        /// Image used on the page and on listings.
        /// </summary>
        [EditableMediaUpload(PreferredSize = "wide")]
        [Persistable(Length = 256)] // to minimize select+1
        public virtual string Image { get; set; }

        [EditableText(Title = "Display Name", ContainerName = Defaults.Containers.Content)]
        public override string Title { get; set; }

        [EditableText(Title = "First Name", ContainerName = Defaults.Containers.Content)]
        public virtual string FirstName { get; set; }

        [EditableText(Title = "Last Name", ContainerName = Defaults.Containers.Content)]
        public virtual string LastName { get; set; }

        [EditableText(Title = "Location", ContainerName = Defaults.Containers.Content)]
        public virtual string Location { get; set; }
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