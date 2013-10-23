using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using Dinamico.Models;


/// <summary>
/// Summary description for Email
/// </summary>
/// 
namespace Services
{
    public class EmailService
    {
        public EmailService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string RetrieveHttpContent(string Url)
        {
            string MergedText = "";

            //System.Net.WebClient Http = new System.Net.WebClient();
            //// Download the Web resource and save it into a data buffer.
            //byte[] Result = Http.DownloadData(Url);
            //MergedText = Encoding.UTF8.GetString(Result);
            //return MergedText;

            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                client.DownloadFile(Url, @"g:\temp\localfile.html");

                // Or you can get the file content without saving it:
                MergedText = client.DownloadString(Url);
                //...
            }

            return MergedText;
        }

        public static string MailMergeNewMember(string memberFullName, string portalAliasLink)
        {
            string path = @"http://" + HttpContext.Current.Request.Url.Authority + "/Dinamico/Themes/Metro/EmailTemplates/FDTemplate.htm";
            string html = EmailService.RetrieveHttpContent(path);

            //create a regular expression with the match string
            Regex regexp1 = new Regex("@@SubHeader", RegexOptions.IgnoreCase);
            Regex regexp2 = new Regex("@@BodyText", RegexOptions.IgnoreCase);

            //replace the source text with this string
            html = regexp1.Replace(html, memberFullName);
            html = regexp2.Replace(html, portalAliasLink);

            return html;
        }

        public static string MailMergeGeneral(string header, string subHeader, string bodyText, string emailGUID, string domainAuthority, string companyName, string mainImage, string linkUrl)
        {
            string domain = domainAuthority;
            //if (string.IsNullOrEmpty(familyWebsiteName))
            //{
            //    try
            //    {
            //        if (MySession.Current.FamilyWebsiteName != null)
            //        {
            //            familyWebsiteName = MySession.Current.FamilyWebsiteName;
            //        }
            //    }
            //    catch { }
            //}
            
            string path = @"http://" + domain + "/Dinamico/Themes/Metro/EmailTemplates/metro.html";
            string html = EmailService.RetrieveHttpContent(path);

            //create a regular expression with the match string
            Regex regexp0 = new Regex("@@Header", RegexOptions.IgnoreCase);
            Regex regexp1 = new Regex("@@SubHeader", RegexOptions.IgnoreCase);
            Regex regexp2 = new Regex("@@BodyText", RegexOptions.IgnoreCase);
            Regex regexp3 = new Regex("@@EmailGUID", RegexOptions.IgnoreCase);
            Regex regexp4 = new Regex("@@Domain", RegexOptions.IgnoreCase);
            Regex regexp6 = new Regex("@@FamilyWebsiteName", RegexOptions.IgnoreCase);
            Regex regexp7 = new Regex("@@MainImage", RegexOptions.IgnoreCase);
            Regex regexp8 = new Regex("@@LinkUrl", RegexOptions.IgnoreCase);

            //replace the source text with this string
            html = regexp0.Replace(html, header);
            html = regexp1.Replace(html, subHeader);
            html = regexp2.Replace(html, bodyText);
            html = regexp3.Replace(html, emailGUID);
            html = regexp4.Replace(html, domain);
            html = regexp6.Replace(html, companyName);
            html = regexp7.Replace(html, mainImage);
            html = regexp8.Replace(html, linkUrl);

            return html;
        }


        public static string MailMergeInvitation(string sender, string invitationLink, string familyTitle, string senderEmail, string customSenderNote, string userName, string password)
        {
            string path = @"http://" + HttpContext.Current.Request.Url.Authority + "/scripts/emailtemplates/invitation.htm";
            string html = EmailService.RetrieveHttpContent(path);

            //create a regular expression with the match string

            Regex regexp1 = new Regex("@@Sender", RegexOptions.IgnoreCase);
            Regex regexp2 = new Regex("@@InvitationLink", RegexOptions.IgnoreCase);
            Regex regexp3 = new Regex("@@FamilyTitle", RegexOptions.IgnoreCase);
            Regex regexp4 = new Regex("@@SenderEmail", RegexOptions.IgnoreCase);
            Regex regexp5 = new Regex("@@CustomSenderNote", RegexOptions.IgnoreCase);
            Regex regexp6 = new Regex("@@UserName", RegexOptions.IgnoreCase);
            Regex regexp7 = new Regex("@@Password", RegexOptions.IgnoreCase);
            Regex regexp8 = new Regex("@@MainImage", RegexOptions.IgnoreCase);
            Regex regexp9 = new Regex("@@SubImage", RegexOptions.IgnoreCase);

            //replace the source text with this string
            html = regexp1.Replace(html, sender);
            html = regexp2.Replace(html, invitationLink);
            html = regexp3.Replace(html, familyTitle);
            html = regexp4.Replace(html, senderEmail);
            html = regexp5.Replace(html, customSenderNote);
            html = regexp6.Replace(html, userName);
            html = regexp7.Replace(html, password);
            html = regexp7.Replace(html, password);
            return html;
        }



        public static string MailMerge(string header, string row1, string row2, string row3)
        {
            string path = @"http://" + HttpContext.Current.Request.Url.Authority + "/scripts/emailtemplates/emailGeneral.htm";
            string html = EmailService.RetrieveHttpContent(path);

            //create a regular expression with the match string
            Regex regexp1 = new Regex("@@header", RegexOptions.IgnoreCase);
            Regex regexp2 = new Regex("@@row1", RegexOptions.IgnoreCase);
            Regex regexp3 = new Regex("@@row2", RegexOptions.IgnoreCase);
            Regex regexp4 = new Regex("@@row3", RegexOptions.IgnoreCase);

            //replace the source text with this string
            html = regexp1.Replace(html, header);
            html = regexp2.Replace(html, row1);
            html = regexp3.Replace(html, row2);
            html = regexp4.Replace(html, row3);

            return html;
        }

        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="mailTo"></param>
        /// <param name="subject"></param>
        /// <param name="bodyText"></param>
        /// <returns></returns>
        /// 
        /// 
        //public static string sendMail(string mailFrom, string mailTo, string mailToCc, string mailToBcc, string mailReplyTo, string subject, string subHeader, string bodyText)
        //{
        //    return sendMail(mailFrom, mailTo, mailToCc, mailToBcc, mailReplyTo, subject, subHeader, bodyText, null, "", "");
        //}

        public static string sendMail(string header, string mailFrom, string mailTo, string mailToCc, string mailToBcc, string mailReplyTo, string subject, string subHeader, string bodyText, string domainAuthority, string companyName, string mainImage, string subImage)
        {
            if (domainAuthority == null)
            {
                domainAuthority = HttpContext.Current.Request.Url.Authority;
            }

            string emailGUID = System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 9);
            try
            {
                string smtpUser = ConfigurationSettings.AppSettings["SMTP_USER"];
                string smtpPwd = ConfigurationSettings.AppSettings["SMTP_PWD"];


                string SmtpPort = ConfigurationSettings.AppSettings["SMTP_PORT"];
                System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
                //string bccEmail = "outboundBCC@familydetails.com";

                mail.To = mailTo;
                mail.Cc = mailToCc;
                mail.Bcc = mailToBcc;
                mail.Headers.Add("Reply-To", mailReplyTo);


                //if (mailTo.IndexOf("@familydetails.com") == -1 && mailTo.IndexOf("ldc0618") == -1)
                //{
                //only copy on emails that are'nt already coming to me
                //mail.Bcc += bccEmail;
                //}

                //mail.From = mailFrom;
                MailAddress from = new MailAddress("support@vauzo.com", "Vauzo");
                mail.From ="support@vauzo.com";
                mail.Subject = subject;
                string body = MailMergeGeneral(header, subHeader, bodyText, emailGUID, domainAuthority, companyName, mainImage, subImage);
                mail.Body = body;
                mail.BodyFormat = MailFormat.Html;
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpUser);
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPwd);
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", SmtpPort);

                //Console.WriteLine("mail user:" + smtpUser + SmtpPort);


                string server = ConfigurationSettings.AppSettings["SMTP_SERVER"];
                SmtpMail.SmtpServer = server;
                //Console.WriteLine(server);
                //SmtpMail.SmtpServer.Insert( 0, server );

                SmtpMail.Send(mail);


                CreateEmailLog(mailFrom, mailTo, mailToCc, mailToBcc, mailReplyTo, subject, bodyText, emailGUID);
                if (bodyText.IndexOf("@@EmailGUID") != -1)
                    return emailGUID;
                return "success";
            }
            catch (Exception ex)
            {
                if (bodyText.IndexOf("@@EmailGUID") != -1)
                    return emailGUID;
                return ex.Message.ToString();
            }
        }

        public static string sendTextMail(string mailTo, string mailToCc, string mailReplyTo, string subject, string bodyText)
        {
   

            string emailGUID = System.Guid.NewGuid().ToString().Replace("-", "").Substring(0, 9);
            try
            {
                string smtpUser = ConfigurationSettings.AppSettings["SMTP_USER"];
                string smtpPwd = ConfigurationSettings.AppSettings["SMTP_PWD"];


                string SmtpPort = ConfigurationSettings.AppSettings["SMTP_PORT"];
                System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
                //string bccEmail = "outboundBCC@familydetails.com";

                mail.To = mailTo;
                mail.Cc = mailToCc;
                mail.Headers.Add("Reply-To", mailReplyTo);


                //if (mailTo.IndexOf("@familydetails.com") == -1 && mailTo.IndexOf("ldc0618") == -1)
                //{
                //only copy on emails that are'nt already coming to me
                //mail.Bcc += bccEmail;
                //}

                //mail.From = mailFrom;
                MailAddress from = new MailAddress("support@vauzo.com", "Vauzo");
                mail.From = "support@vauzo.com";
                mail.Subject = subject;
                mail.Body = bodyText;
                mail.BodyFormat = MailFormat.Html;
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpUser);
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPwd);
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", SmtpPort);

                //Console.WriteLine("mail user:" + smtpUser + SmtpPort);


                string server = ConfigurationSettings.AppSettings["SMTP_SERVER"];
                SmtpMail.SmtpServer = server;
                //Console.WriteLine(server);
                //SmtpMail.SmtpServer.Insert( 0, server );

                SmtpMail.Send(mail);


                CreateEmailLog(mail.From, mailTo, mailToCc, "", mailReplyTo, subject, bodyText, emailGUID);
                if (bodyText.IndexOf("@@EmailGUID") != -1)
                    return emailGUID;
                return "success";
            }
            catch (Exception ex)
            {
                if (bodyText.IndexOf("@@EmailGUID") != -1)
                    return emailGUID;
                return ex.Message.ToString();
            }
        }

        protected static void CreateEmailLog(string mailFrom,
            string mailTo,
            string mailToCc,
            string mailToBcc,
            string mailReplyTo,
            string subject,
            string bodyText,
            string emailGUID)
        {
            /*
            CREATE PROC [dbo].[usp_EmailLogInsert] 
            @EmailFrom varchar(100),
            @EmailTo varchar(1000),
            @EmailCC varchar(300),
            @EmailBCC varchar(300),
            @EmailReplyTo varchar(100),
            @EmailSubject varchar(300),
            @EmailBody varchar(MAX),
            @EmailGUID varchar(100),
            @EmailRead bit,
            @EmalLinkClicked bit,
            @TimeStamp smalldatetime
                     * */
            //DatabaseFactory.CreateDatabase().ExecuteNonQuery("usp_EmailLogInsert",
            //    mailFrom, mailTo, mailToCc, mailToBcc, mailReplyTo, subject, bodyText, emailGUID, 0, 0, DateTime.Now);
        }

        public static void SendInvitationEmail(UserProfilePage user, string password)
        {
            string domain = HttpContext.Current.Request.Url.Authority;
            var code = string.Format("{0}", password);
            var startPage = N2.Context.Current.Persister.Get<StartPage>(3) as StartPage;
            var intranetName = startPage.IntranetName;
            var companyName = startPage.CompanyName;
            var sender = SessionService.Current.DisplayName;
            var subject = string.Format("{0} from {1} has invited you to join {2} hosted by Vauzo", sender, companyName, intranetName);

            string body = string.Format("Hi {0},<br><br>{1}<br><br> Please activate your account by clicking on the link below:<br><a href='http://{2}/activate?code={3}'>Activate Account</a><br><br>" +
                "After activation your account you can login using the credentials below:<br><br>Username: {4}<br>Password: {5}<br><br>" +
                "Vauzo is a hosted intranet service. Click <a href='http://www.vauzo.com'>here</a> for more info.<br><br>Thanks!<br>The Vauzo Team", user.FirstName, subject, domain, code, user.UserName, password);
            
            var status = EmailService.sendTextMail(user.Email, "", "no-reply@vauzo.com", subject, body);
            //Services.EmailService.MailMergeInvitation("support@vauzo.com", 
        }

        public static void ForgotPasswordEmail(string email)
        {
            var profile = new ProfileService().GetProfileByEmail(email);
            var user = System.Web.Security.Membership.GetUser(profile.UserName);
            var password = user.GetPassword();
            string domain = HttpContext.Current.Request.Url.Authority;
            var code = string.Format("{0}", password);
            var startPage = N2.Context.Current.Persister.Get<StartPage>(3) as StartPage;
            var intranetName = startPage.IntranetName;
            var companyName = startPage.CompanyName;
            var sender = SessionService.Current.DisplayName;
            var subject = string.Format("Password retrieval for {0}", intranetName);

            string body = string.Format("Hi {0},<br><br>{1}<br><br> You can login here: <br><a href='http://{2}/login'>http://{2}/login</a><br><br>" +
                "Your credentials are below:<br><br>Username: {4}<br>Password: {5}<br><br>" +
                "Vauzo is a hosted intranet service. Click <a href='http://www.vauzo.com'>here</a> for more info.<br><br>Thanks!<br>The Vauzo Team<br>" +
                "<a href='mailto:support@vauzo.com'>support@vauzo.com</a>", 
                profile.FirstName , subject, domain, code, user.UserName, password);

            var status = EmailService.sendTextMail(user.Email, "", "no-reply@vauzo.com", subject, body);
            //Services.EmailService.MailMergeInvitation("support@vauzo.com", 
        }
    }

}



