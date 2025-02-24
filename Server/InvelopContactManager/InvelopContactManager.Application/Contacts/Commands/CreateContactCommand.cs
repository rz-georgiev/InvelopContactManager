using InvelopContactManager.Domain.Models;
using MediatR;

namespace InvelopContactManager.Application.Contacts.Commands
{
    public class CreateContactCommand : IRequest<BaseResponse<ContactEditResponseDto>>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Iban { get; set; }
    }

}