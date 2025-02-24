using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Commands
{
    public class GetContactQuery : IRequest<BaseResponse<ContactResponseDto>>
    {
        public int Id { get; set; }
    }
}