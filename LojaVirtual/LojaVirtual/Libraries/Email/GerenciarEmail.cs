using LojaVirtual.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Text;

namespace LojaVirtual.Libraries.Email
{
    public class GerenciarEmail
    {
        SmtpClient _smtpClient;
        IConfiguration _configuration;
        public GerenciarEmail(SmtpClient smtpClient, IConfiguration configuration)
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
        }

        public void EnviarContatoPorEmail(Contato contato)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(_configuration.GetValue<string>("Email:Username"));
            mailMessage.From = new MailAddress(_configuration.GetValue<string>("Email:Username"));
            mailMessage.Subject = string.Concat("Contato (Loja Virtual) - E-mail: ", contato.Email);
            mailMessage.Body = string.Concat("<h2>Contato - Loja Virtual</h2><br/><b>Nome: </b>", contato.Nome, "<br/><b>E-mail: </b>", contato.Email, "<br/><b>Texto</b><br/>", contato.Texto,"<br/>E-mail enviado automaticamente pelo site LojaVirtual.");
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Priority = MailPriority.High;

            _smtpClient.Send(mailMessage);
        }

        public void EnviarSenhaParaColaboradorPorEmail(Colaborador colaborador)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(colaborador.Email);
            mailMessage.From = new MailAddress(_configuration.GetValue<string>("Email:Username"));
            mailMessage.Subject = "Colaborador (Loja Virtual) - Senha";
            mailMessage.Body = string.Concat("<h2>Colaborador - Loja Virtual</h2><br/>Sua senha é: <h3><b>", colaborador.Senha,"</b></h3><br/>E-mail enviado automaticamente pelo site LojaVirtual.");
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Priority = MailPriority.High;

            _smtpClient.Send(mailMessage);
        }
    }
}
