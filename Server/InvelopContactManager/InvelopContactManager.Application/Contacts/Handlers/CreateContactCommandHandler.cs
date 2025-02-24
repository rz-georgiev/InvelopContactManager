using FluentValidation;
using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Application.Contacts.Validators;
using InvelopContactManager.Common;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, BaseResponse<ContactEditResponseDto>>
    {
        private readonly InvelopDbContext _dbContext;
        private readonly IValidator<CreateContactCommand> _validator;

        public CreateContactCommandHandler(InvelopDbContext dbContext, IValidator<CreateContactCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        /// <summary>
        /// Handles creation of new contacts and ensures that validations are executed.
        /// </summary>
        public async Task<BaseResponse<ContactEditResponseDto>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseHelper.Failure<ContactEditResponseDto>(string.Join(", ", validationResult.Errors));
            }
            
            try
            {
                var contact = new Contact(request.FirstName,
                request.Surname,
                request.Dob,
                request.Address,
                request.PhoneNumber,
                request.Iban);

                await _dbContext.Contacts.AddAsync(contact, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var response = new ContactEditResponseDto
                {
                    ContactId = contact.Id
                };

                return ResponseHelper.Success(response);
            }
            catch (Exception)
            {
                return ResponseHelper.Failure<ContactEditResponseDto>("Contact was not saved successfully, please check your input data");
            }
        }
    }
}