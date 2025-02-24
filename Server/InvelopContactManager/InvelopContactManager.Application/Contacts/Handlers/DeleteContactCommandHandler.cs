using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Common;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, BaseResponse>
    {
        private readonly InvelopDbContext _dbContext;

        public DeleteContactCommandHandler(InvelopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _dbContext.Contacts.SingleOrDefault(x => x.Id == request.Id);
            if (contact == null)
            {
                return ResponseHelper.Failure("Contact with the provided id was not found");
            }

            try
            {
                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync();

                return ResponseHelper.Success("Successfully deleted contact");
            }
            catch (Exception)
            {
                return ResponseHelper.Failure("An error occurred while trying to delete the contact");
            }
        }
    }
}