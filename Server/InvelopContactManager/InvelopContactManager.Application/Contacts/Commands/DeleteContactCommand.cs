using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Commands
{
    public class DeleteContactCommand : IRequest<BaseResponse<ContactEditResponseDto>>
    {
        public int Id { get; set; }
    }
}