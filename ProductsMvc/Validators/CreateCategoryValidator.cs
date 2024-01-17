using FluentValidation;
using ProductsMvc.Models;
using ProductsMvc.Models.ViewModels;

namespace ProductsMvc.Validators;

public class CreateCategoryValidator : AbstractValidator<CategoryViewModel>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Field must be filled");
    }
}