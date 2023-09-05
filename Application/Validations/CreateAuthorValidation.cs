using Application.RequestModels;
using Application.RequestModels.AuthorRequestModels;
using Application.RequestModels.BookRequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class CreateAuthorValidation : AbstractValidator<CreateAuthorRequestModel>
    {
        public CreateAuthorValidation()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MinimumLength(3);
        }
    }

    public class UpdateAuthorValidation : AbstractValidator<UpdateAuthorRequestModel>
    {
        public UpdateAuthorValidation()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MinimumLength(3);
        }
    }

    public class CreateBookValidation : AbstractValidator<CreateBookRequestModel>
    {
        public CreateBookValidation()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MinimumLength(3);

            RuleFor(a => a.AuthorId).NotEmpty().NotNull().WithMessage("You didn't correct put Author ");

            RuleFor(c => c.CategoryId).NotNull().NotEmpty().WithMessage("You didn't correct put Author ");

            RuleFor(c => c.Count).NotNull().NotEmpty();
        }
    }

    public class UpdateBookValidation : AbstractValidator<UpdateBookRequestModel>
    {
        public UpdateBookValidation()
        {
            RuleFor(n => n.Name).NotEmpty().NotNull().MinimumLength(3);

            RuleFor(a => a.AuthorId).NotEmpty().NotNull().WithMessage("You didn't correct put Author ");

            RuleFor(c => c.CategoryId).NotNull().NotEmpty().WithMessage("You didn't correct put Author ");

            RuleFor(c => c.Count).NotNull().NotEmpty();
        }
    }

    public class CreateCategoryValidation:AbstractValidator<CreateCategoryRequestModel>
    {
        public CreateCategoryValidation()
        {
            RuleFor(n => n.Name).NotEmpty().NotNull().MinimumLength(3);
        }
    }

    public class UpdateCategoryValidation : AbstractValidator<CreateCategoryRequestModel>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(n => n.Name).NotEmpty().NotNull().MinimumLength(3);
        }
    }

}
