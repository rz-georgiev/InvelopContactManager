using FluentValidation;
using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Domain.Models;

namespace InvelopContactManager.Application.Contacts.Validators
{
    public class CreateContactValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(x => x.Dob)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateTime.UtcNow).WithMessage("Date of birth cannot be in the future.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(x => x.Iban)
                .NotEmpty().WithMessage("IBAN is required.");
        }
    }
}