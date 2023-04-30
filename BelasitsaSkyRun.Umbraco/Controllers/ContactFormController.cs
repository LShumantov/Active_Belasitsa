using BelasitsaSkyRun.Umbraco.Models;
using System;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace BelasitsaSkyRun.Umbraco.Controllers
{
    public class ContactFormController : SurfaceController
    {
        [HttpGet]
        public ActionResult ContactUsTemplate()
        {
            ContactUsModel model = new ContactUsModel();

            return View("~/Views/Shared/ContactUsForm.cshtml", model);
        }

        [HttpPost]
        public ActionResult ContactUsTemplate(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                string subject = string.Format("{0} - {1}", model.Email, model.Name);

                string body = string.Format("<b>Email: </b>{2}<br/><b>Name: </b>{1}<br/><b>Message: </b> <br/><br/> {0}",
                    model.Message.Replace("\r", "").Replace("\n", "<br />"),
                    model.Name,
                    model.Email);

                SendEmail(model.Email, model.Name, subject, body);

                Response.Redirect("/mk/thankyoupage/");
            }
            return View("~/Views/Shared/ContactUsForm.cshtml", model);
        }





        public string SendEmail(string email, string displayName, string subject, string body)
        {
            if (!string.IsNullOrEmpty(body) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(displayName) &&
                !string.IsNullOrEmpty(subject))
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    MailAddress to = new MailAddress("lyubomir.shumantov@klevret.com");
                    MailAddress from = new MailAddress(email, displayName);
                    MailMessage message = new MailMessage(from, to);
                    message.Subject = subject;      //"Using the new SMTP client.";
                    message.Body = body;            // @"Using this new feature, you can send an e-mail message from an application very easily.";
                    message.IsBodyHtml = true;
                    SmtpClient client = new System.Net.Mail.SmtpClient();

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                                    ex.ToString());
                    }

                }
                return "TODO: Return Url";

            }
            return null;
        }
    }
}