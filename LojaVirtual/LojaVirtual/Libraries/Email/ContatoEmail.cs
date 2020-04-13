using LojaVirtual.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("username", "password");
            smtpClient.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add("thais.c.tozatto@gmail.com");
            mailMessage.From = new MailAddress("thais.c.tozatto@gmail.com");
            mailMessage.Subject = string.Concat("Contato (Loja Virtual) - E-mail: ", contato.Email);
            mailMessage.Body = string.Concat("<h2>Contato - Loja Virtual</h2><br/><b>Nome: </b>", contato.Nome, "<br/><b>E-mail: </b>", contato.Email, "<br/><b>Texto</b><br/>", contato.Texto,"<br/>E-mail enviado automaticamente pelo site LojaVirtual.");
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Priority = MailPriority.High;

            smtpClient.Send(mailMessage);
        }
    }
}
