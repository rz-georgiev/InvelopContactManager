using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Commands
{
    public class DeleteContactCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}