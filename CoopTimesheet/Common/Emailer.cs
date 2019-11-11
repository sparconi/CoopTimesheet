using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using MailerTest;

namespace CoopTimesheet.Common
{
	public class Emailer
	{
		public static bool SendEmailOnError(string errorMessage, string errorPath, string exceptionMessage)
		{
            //Mailer m = new Mailer();

            //m.ToList("paul.mcdermott@co-operative.coop");
            //m.From("projectlog@co-operative.coop");

            //m.AddSMTPHost("mailer1.co-op.co.uk");
            //m.AddSMTPHost("mailer2.co-op.co.uk");

            //HttpContext current = HttpContext.Current;
            //string authUser = current.Request.ServerVariables["AUTH_USER"];
            //string appPath = current.Request.ServerVariables["APPL_PHYSICAL_PATH"];

            //string MessageBody = "User\n------------------------------------------------------------\n" + authUser +
            //        "\n\nApplication\n------------------------------------------------------------\n" + appPath +
            //        "\n\nPath\n------------------------------------------------------------\n" + errorPath +
            //        "\n\nError details\n------------------------------------------------------------\n" + 
            //        "\n" + exceptionMessage;

            //bool result = m.SendEmail("ProjectLog: Unhandled error", MessageBody, true);

            //return result;

            MailAddress fromEmail = new MailAddress("wasp_user@coop.co.uk", "WASP");
            MailAddress toEmail = new MailAddress("paul.mcdermott@co-operative.coop", "Paul McDermott");
            MailMessage message = new MailMessage(fromEmail, toEmail);
            HttpContext current = HttpContext.Current;

            string authUser = current.Request.ServerVariables["AUTH_USER"];
            string appPath = current.Request.ServerVariables["APPL_PHYSICAL_PATH"];

            message.Subject = "ProjectLog: Unhandled error";
            message.Priority = MailPriority.High;
            message.Body =
                "User\n------------------------------------------------------------\n" + authUser +
                "\n\nApplication\n------------------------------------------------------------\n" + appPath +
                "\n\nPath\n------------------------------------------------------------\n" + errorPath +
                "\n\nError details\n------------------------------------------------------------\n" + 
                "\n" + exceptionMessage;


            try
            {
                SmtpClient emailClient = new SmtpClient("smtp.live.co-op.local")   //("TESS")
                                            {
                                                UseDefaultCredentials = false,
                                                Credentials = new NetworkCredential(@"COOP.CO.UK\Wasp_User", "password")
                                            };
                emailClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
		}

        public static bool SendEmailAttachments(string EmailAddress, string ProjectSubject, string ProjectBody)
        {
            MailAddress fromEmail = new MailAddress("ProjectLog@co-operative.coop", "ProjectLog");
            MailAddress toEmail = new MailAddress(EmailAddress);
            MailAddress ccEmail = new MailAddress("ts_projects@co-operative.coop");
            MailAddress bccEmail = new MailAddress("paul.mcdermott@co-operative.coop");
            MailMessage message = new MailMessage(fromEmail, toEmail);
            HttpContext current = HttpContext.Current;

            string authUser = current.Request.ServerVariables["AUTH_USER"];
            string appPath = current.Request.ServerVariables["APPL_PHYSICAL_PATH"];

            message.Subject = "ProjectLog: Engagement File Attachments - " + ProjectSubject;
            message.CC.Add(ccEmail);
            message.Bcc.Add(bccEmail);
            message.Priority = MailPriority.High;
            message.Body = ProjectBody;
            //"The Project " + ProjectSubject + " has been accepted. You now need to fill in the attached files and uploaded these into the the appropriate section for this project. Once all 5 documents are uploaded, You will then be able to submitted to Project.";

            message.Attachments.Add(new Attachment(@"\\cobalt\wg_corp_inf\Projects\PLOG Engagement Documents - Do Not Delete or Amend\TSEF Application Flow Temlpate.doc"));
            message.Attachments.Add(new Attachment(@"\\cobalt\wg_corp_inf\Projects\PLOG Engagement Documents - Do Not Delete or Amend\TSEF Application None Functional Detail.doc"));
            message.Attachments.Add(new Attachment(@"\\cobalt\wg_corp_inf\Projects\PLOG Engagement Documents - Do Not Delete or Amend\TSEF IS Continuity.doc"));
            message.Attachments.Add(new Attachment(@"\\cobalt\wg_corp_inf\Projects\PLOG Engagement Documents - Do Not Delete or Amend\TSEF IS SEC.doc"));
            message.Attachments.Add(new Attachment(@"\\cobalt\wg_corp_inf\Projects\PLOG Engagement Documents - Do Not Delete or Amend\TSEF Project Team Org Structure.doc"));

            try
            {
                SmtpClient emailClient = new SmtpClient("smtp.live.co-op.local")   //("TESS")
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(@"COOP.CO.UK\Wasp_User", "password")
                };
                emailClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
	}
}