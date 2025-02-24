using FluentValidation;
using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Domain.Models;

namespace InvelopContactManager.Application.Contacts.Validators
{
    public class DeleteContactValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactValidator()
        {
            RuleFor(x => x.Id).Must(x => x >= int.MinValue && x <= int.MaxValue).WithMessage("A valid id is required");
        }
    }
}