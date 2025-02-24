using InvelopContactManager.Application.Contacts.Queries;
using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, BaseResponse<ContactResponseDto>>
    {
        public async Task<BaseResponse<ContactResponseDto>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}