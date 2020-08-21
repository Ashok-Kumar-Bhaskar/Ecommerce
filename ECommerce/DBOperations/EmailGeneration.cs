using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ECommerce.DBOperations
{
  public class EmailGeneration
  {
    public static void sendEmail(string emailID, string name)
    {
      var fromEmail = new MailAddress("ashkumpsiog@gmail.com", "Mirror.com");
      var toEmail = new MailAddress(emailID);
      var fromEmailPassword = "passwordpsiog";

      string subject = "Order Confirmation";
      string body = "<br/><br/> " + "Hi " + name + ", " + "<br/>" +
          "You order has been confirmed and Mirror.com promises you to deliver your orders " +
          "within 3 days." + "<br/>" +

          "<br/>" +
          "Warm Regards";
      var smtp = new SmtpClient
      {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
      };
      using (var message = new MailMessage(fromEmail, toEmail)
      {
        Subject = subject,
        Body = body,
        IsBodyHtml = true
      })
        smtp.Send(message);

    }
  }
}