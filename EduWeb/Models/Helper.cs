using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace EduWeb.Models
{
    public static class Helper
    {
        public static string ToMD5(this string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));

            }

            return sbHash.ToString();
        }

        public static void SendMail(string toEmail, string fromEmail, string passEmail, string titleEmail, string contentEmail)
        {
            MailMessage mail = new MailMessage();  // tạo đối tượng mail
            mail.To.Add(toEmail); // gửi đến email
            mail.From = new MailAddress(fromEmail);
            mail.Subject = titleEmail; // tiêu đề mail
            mail.Body = contentEmail; // phần thân của mail ở trên
            mail.IsBodyHtml = true; // cho phép viết mã HTML trong email
            SmtpClient smtp = new SmtpClient(); // tạo đối tượng gửi mail
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(fromEmail, passEmail); // tài khoản gmail của bạn
            smtp.EnableSsl = true;
            smtp.Send(mail); // gửi mail
        }
    }
}