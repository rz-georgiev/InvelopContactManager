using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Common;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, BaseResponse<ContactEditResponseDto>>
    {
        private readonly InvelopDbContext _dbContext;

        public UpdateContactCommandHandler(InvelopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<ContactEditResponseDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _dbContext.Contacts.SingleOrDefault(x => x.Id == request.Id);
            if (contact == null)
            {
                return ResponseHelper.Failure<ContactEditResponseDto>("Contact with the provided id was not found");
            }

            contact.UpdateContact(request.FirstName, request.Surname, request.Dob, request.Address, request.PhoneNumber, request.Iban);

            try
            {
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
                return ResponseHelper.Failure<ContactEditResponseDto>("Contact was not saved successfully, please check your input data");
            }
        }
    }
}