using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Libraries.Validacao
{
    public class EmailUnicoColaboradorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Colaborador colaborador = (Colaborador)validationContext.ObjectInstance;
            IColaboradorRepository colaboradorRepository = (IColaboradorRepository)validationContext.GetService(typeof(IColaboradorRepository));

            if (colaboradorRepository.ObterColaboradorPorEmaill(colaborador.Email, colaborador.Id) > 0)
                return new ValidationResult("E-mail já existente!");
            else
                return ValidationResult.Success;
        }
    }
}
