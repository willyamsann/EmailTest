using System;
using System.IO;
using System.Net.Mail;

namespace EmailTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                MailMessage mail = new MailMessage(); //EMAIL
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com"); //SERVIDOR
                mail.From = new MailAddress("emailFrom");
                var emails = new StreamReader("C:\\email\\emails.txt");
    
                foreach(var email in emails.ReadLine().Split(","))
                {
                    mail.To.Add(email); //

                }

                mail.Subject = "ASSUNTO DO EMAIL NOVO"; //
                mail.IsBodyHtml = true; //

                var body = File.ReadAllText("C:\\email\\email.html");
                body = body.Replace("@Name", "Willyam Santos");
                body = body.Replace("@Descricao", "Tranquilo demais....");

                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("email", "senha");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                Console.WriteLine("SEND MAIL");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
       
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
