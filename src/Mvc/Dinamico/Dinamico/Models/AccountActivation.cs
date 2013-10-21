using System;

namespace Dinamico.Models
{
	/// <summary>
	/// This definition is registered by <see cref="Registrations.FreeFormRegistration"/>.
	/// </summary>
    public class AccoutActivation : PageModelBase
	{
		public virtual int UserId { get; set; }

		// submit

		public virtual DateTime CreateDate { get; set; }

		// email

		public virtual string ActivationCode { get; set; }
	}
}