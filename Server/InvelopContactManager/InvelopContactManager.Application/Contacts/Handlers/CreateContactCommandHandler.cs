using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Common;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, BaseResponse<ContactEditResponseDto>>
    {
        private readonly InvelopDbContext _dbContext;

        public CreateContactCommandHandler(InvelopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<ContactEditResponseDto>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact(request.FirstName,
                request.Surname,
                request.Dob,
                request.Address,
                request.PhoneNumber,
                request.Iban);

            try
            {
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