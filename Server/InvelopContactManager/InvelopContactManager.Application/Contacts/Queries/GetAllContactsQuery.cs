using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Queries
{
    public class GetAllContactsQuery : IRequest<BaseResponse<ContactResponseDto>>
    {
        public int Id { get; set; }
    }
}