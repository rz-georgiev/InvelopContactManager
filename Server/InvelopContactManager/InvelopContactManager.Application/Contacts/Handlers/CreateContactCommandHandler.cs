using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, BaseResponse<ContactEditResponseDto>>
    {
        public async Task<BaseResponse<ContactEditResponseDto>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}