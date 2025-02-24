using InvelopContactManager.Application.Contacts.Queries;
using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, BaseResponse<ContactResponseDto>>
    {
        public async Task<BaseResponse<ContactResponseDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}