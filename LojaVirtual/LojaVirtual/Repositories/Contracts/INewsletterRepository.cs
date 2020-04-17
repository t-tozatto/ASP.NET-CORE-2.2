using LojaVirtual.Models;
using System.Collections.Generic;

namespace LojaVirtual.Repositories.Contracts
{
    public interface INewsletterRepository
    {
        void Cadastrar(NewsletterEmail newsletterEmail);

        IEnumerable<NewsletterEmail> ObterTodasNewsletter();
    }
}
