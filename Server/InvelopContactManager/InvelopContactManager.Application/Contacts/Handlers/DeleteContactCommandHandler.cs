using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Commands
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}