using FluentValidation;
using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Common;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, BaseResponse<ContactEditResponseDto>>
    {
        private readonly InvelopDbContext _dbContext;
        private readonly IValidator<UpdateContactCommand> _validator;

        public UpdateContactCommandHandler(InvelopDbContext dbContext, IValidator<UpdateContactCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        /// <summary>
        /// Handles udate of existing contacts and ensures that validations are executed.
        /// </summary>
        public async Task<BaseResponse<ContactEditResponseDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ResponseHelper.Failure<ContactEditResponseDto>(string.Join(", ", validationResult.Errors));
            }

            var contact = _dbContext.Contacts.SingleOrDefault(x => x.Id == request.Id);
            if (contact == null)
            {
                return ResponseHelper.Failure<ContactEditResponseDto>("Contact with the provided id was not found");
            }

            try
            {
                contact.UpdateContact(request.FirstName, request.Surname, request.Dob, request.Address, request.PhoneNumber, request.Iban);

                _dbContext.Contacts.Update(contact);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new BaseResponse<ContactEditResponseDto>
                {
                    IsOk = true,
                    Result = new ContactEditResponseDto
                    {
                        ContactId = contact.Id
                    }
                };
            }
            catch (Exception)
            {
                return ResponseHelper.Failure<ContactEditResponseDto>("Please check your data input");
            }
        }
    }
}