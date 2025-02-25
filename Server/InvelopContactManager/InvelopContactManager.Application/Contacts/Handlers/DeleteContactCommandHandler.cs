using FluentValidation;
using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Common.Helpers;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, BaseResponse<ContactEditResponseDto>>
    {
        private readonly InvelopDbContext _dbContext;
        private readonly IValidator<DeleteContactCommand> _validator;

        public DeleteContactCommandHandler(InvelopDbContext dbContext, IValidator<DeleteContactCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        /// <summary>
        /// Handles deletion of existing contacts and ensures that validations are executed.
        /// </summary>
        public async Task<BaseResponse<ContactEditResponseDto>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
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
                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync();

                return ResponseHelper.Success<ContactEditResponseDto>(new ContactEditResponseDto
                {
                    ContactId = contact.Id
                });
            }
            catch (Exception)
            {
                return ResponseHelper.Failure<ContactEditResponseDto>("An error occurred while trying to delete the contact");
            }
        }
    }
}