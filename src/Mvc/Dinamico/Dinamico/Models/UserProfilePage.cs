using N2;
using N2.Details;
using N2.Persistence;
using N2.Definitions;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System;
using Castle.DynamicProxy;

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

        [Required]
        [Display(Name = "Display name")]
        [EditableText(Title = "Display Name", SortOrder=1, Placeholder="Display Name", ContainerName = Defaults.Containers.Content)]
        public override string Title { get; set; }

        [Required]
        [EditableText(Title = "User Name", SortOrder = 2, ContainerName = Defaults.Containers.Content)]
        public virtual string UserName { get; set; }

        [Required]
        [EditableText(Title = "First Name", SortOrder = 3, ContainerName = Defaults.Containers.Content)]
        public virtual string FirstName { get; set; }

        [Required]
        [EditableText(Title = "Last Name", SortOrder = 4, ContainerName = Defaults.Containers.Content)]
        public virtual string LastName { get; set; }

        [Required]
        [EditableText(Title = "Email", SortOrder = 5, ContainerName = Defaults.Containers.Content)]
        public virtual string Email { get; set; }

        [EditableText(Title = "Location", ContainerName = Defaults.Containers.Content)]
        public virtual string Location { get; set; }

        [EditableText(Title = "Job Title", ContainerName = Defaults.Containers.Content)]
        public virtual string JobTitle { get; set; }

        [EditableText(Title = "Skills", ContainerName = Defaults.Containers.Content)]
        public virtual string Skills { get; set; }

        [EditableText(Title = "Loves",ContainerName = Defaults.Containers.Content)]
        public virtual string Loves { get; set; }


        [EditableText(Title = "Activation Code", SortOrder = 999, IsViewEditable = false, ContainerName = Defaults.Containers.Metadata, ReadOnly=true)]
        public virtual string ActivationCode { get; set; }

        [EditableText(Title = "Activation Date", SortOrder = 999, IsViewEditable = false, ContainerName = Defaults.Containers.Metadata, ReadOnly = true)]
        public virtual DateTime? ActivationDate { get; set; }

        //[EditableDate(Title = "Start Date")]
        //public virtual DateTime? StartDate { get; set; }

        [EditableDate("Start Date", 22, ShowTime = false, UseTodayAsDefault = true, ContainerName = Defaults.Containers.Content)]
        public virtual DateTime? EventDate
        {
            get { return (DateTime?)GetDetail("StartDate"); }
            set { SetDetail("StartDate", value); }
        }

        [EditableNumber(Title = "Total Points", ContainerName = Defaults.Containers.Content)]
        public virtual int TotalPoints { get; set; }

        [EditableText(Title = "Office Phone", ContainerName = Defaults.Containers.Content)]
        public virtual string OfficePhone { get; set; }

        [EditableText(Title = "Mobile Phone", ContainerName = Defaults.Containers.Content)]
        public virtual string MobilePhone { get; set; }

        /// <summary>
        /// Main content of this content item.
        /// </summary>
        [EditableFreeTextArea]
        [DisplayableTokens]
        public virtual string Text { get; set; }
    }
}