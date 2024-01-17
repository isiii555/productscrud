using FluentValidation;
using ProductsMvc.Models;
using ProductsMvc.Models.ViewModels;

namespace ProductsMvc.Validators;

public class CreateProductValidator : AbstractValidator<ProductViewModel>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).MinimumLength(5).MaximumLength(15)
            .WithMessage("Product name length must be between 5 and 10 characters");

        RuleFor(p => p.Price).NotEmpty().WithMessage("Field must be filled");

        RuleFor(p => p.TagIds).NotEmpty().WithMessage("Field must be filled");

        RuleFor(p => p.Image).NotEmpty().WithMessage("Field must be filled");

        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Field must be filled");

        RuleFor(p => p.Description).NotEmpty().WithMessage("Field must be filled");
    }
}