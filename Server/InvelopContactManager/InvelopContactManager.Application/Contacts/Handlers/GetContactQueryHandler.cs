using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Commands
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, BaseResponse<ContactResponseDto>>
    {
        public async Task<BaseResponse<ContactResponseDto>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}