using N2.Details;
using N2.Integrity;
using N2.Definitions;
using System;
using N2;
using N2.Persistence.Serialization;

namespace Dinamico.App_Code
{
    public class XPage : ContentItem
    {
        public string Title { get; set; }

        [FileAttachment, EditableFileUploadAttribute("Image", 90, CssClass = "main")]
        public virtual string Image
        {
            get { return (string)(GetDetail("Image") ?? string.Empty); }
            set { SetDetail("Image", value, string.Empty); }
        }
    }
}