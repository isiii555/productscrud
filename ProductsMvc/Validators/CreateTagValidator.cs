using FluentValidation;

using ProductsMvc.Models;
using ProductsMvc.Models.ViewModels;

namespace ProductsMvc.Validators;

public class CreateTagValidator : AbstractValidator<TagViewModel>
{
    public CreateTagValidator()
    {
        RuleFor(t => t.Name).NotEmpty().WithMessage("Field must be filled");
    }
}