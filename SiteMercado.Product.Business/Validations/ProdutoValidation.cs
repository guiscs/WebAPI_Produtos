using SiteMercado.Product.Data.Models;
using FluentValidation;

namespace SiteMercado.Product.Business.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(c => c.NM_PRODUTO)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.VL_PRODUTO)
            .GreaterThan(-1).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
