using FluentValidation;
using HizliSec.Entities.Concrete;

namespace HizliSec.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
