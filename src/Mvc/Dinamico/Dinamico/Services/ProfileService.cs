using Dinamico.Models;
using N2.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
	public class ProfileService
	{
        public UserProfilePage GetProfileByEmail(string email)
        {
            var profiles = N2.Find.Items.Where.Type.Eq(typeof(UserProfilePage)).Select();
            foreach (var profile in profiles)
            {
                var pro = profile as UserProfilePage;
                if (pro.Email == email)
                    return pro;
            }

            return null;
        }

        public UserProfilePage GetProfileByActivationCode(string code)
        {
            var profiles = N2.Find.Items.Where.Type.Eq(typeof(UserProfilePage)).Select();
            foreach (var profile in profiles)
            {
                var pro = profile as UserProfilePage;
                if (pro.ActivationCode == code)
                    return pro;
            }

            return null;
        }
	}
}