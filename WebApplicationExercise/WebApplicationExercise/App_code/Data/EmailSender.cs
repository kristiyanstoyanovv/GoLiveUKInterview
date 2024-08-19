using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using WebApplicationExercise.App_Code.Models;

namespace WebApplicationExercise.App_Code.Data
{

    public class EmailSender
    {
        private MailMessage _mail;
        private SmtpClient smtpClient;

        public EmailSender() {
            _mail = new MailMessage();
            _mail.From = new MailAddress("playlistgeneratorr@gmail.com");
            _mail.IsBodyHtml = true;

            //SMTP Settings
            smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            // Username and password for the gmail account, I know that sending this to people is a bad practice.
            // It's a empty account created for this purpose only. Created a long time ago for another project.
            // Deleted credentials because of security reasons.
            smtpClient.Credentials = new NetworkCredential(null, null);
        }

        /// <summary>
        /// Sends an email with the form data to the specified recipient.
        /// </summary>
        /// <param name="recipient">The email address of the recipient.</param>
        /// <param name="form">The FormModel containing form data.</param>
        /// <returns>True if the email is successfully sent, otherwise false.</returns>
        public bool sendEmail(string recipient,FormModel form)
        {
            _mail.Subject = form.subject;
            _mail.Body = generateHtmlBody(form);
            _mail.To.Add(recipient);

            try
            {
                smtpClient.Send(_mail);

                // Return true indicating successful email sending
                return true;
            }
            catch { }

            // Return false indicating failure to send the email
            return false;
        }

        /// <summary>
        /// Generates an HTML email body based on the provided FormModel.
        /// </summary>
        /// <param name="form">The FormModel containing form data.</param>
        /// <returns>The HTML email body as a string.</returns>
        private string generateHtmlBody(FormModel form)
        {
            string emailTemplate = @"
            <!DOCTYPE html>
            <html lang=""en"">
            <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            </head>
            <body>

            <div style=""display: flex; align-items: center; justify-content: center;"">
                <div style=""width: 25%;"" class=""card"">
                    <div class=""card-body"">
                        <h2 style=""text-align: center;"">GoLiveUK Interview</h2>
                        <hr>
                        <p><strong>Email:</strong> " + form.email + @"</p>
                        <p><strong>First Name:</strong> " + form.firstName + @"</p>
                        <p><strong>Last Name:</strong> " + form.lastName + @"</p>
                        <p><strong>Subject:</strong> " + form.subject + @"</p>
                        <hr>
                        <p><strong>Message:</strong></p>
                        <p>" + form.message + @"</p>
                        <hr>
                        <footer>
                            <p style=""font-style: italic;"">GoLiveUK Interview Task, developed by: Kristiyan Stoyanov</p>
                        </footer>
                    </div>
                </div>
            </div>
            </body>
            </html>";

            return emailTemplate;
        }
    }
}