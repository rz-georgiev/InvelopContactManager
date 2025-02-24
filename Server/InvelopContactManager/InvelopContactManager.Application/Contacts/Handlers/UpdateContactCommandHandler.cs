using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Commands
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, BaseResponse<ContactEditResponseDto>>
    {
        public async Task<BaseResponse<ContactEditResponseDto>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}