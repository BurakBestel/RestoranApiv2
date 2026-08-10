using FluentValidation;
using RestoranAPiV2.Entities;

namespace RestoranAPiV2.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("İsim boş bırakılamaz");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("En az 2 karakter girin.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş bırakılamaz").GreaterThan(0).WithMessage("Fiyat 0 dan büyük olmalı");
        }

    }
}
