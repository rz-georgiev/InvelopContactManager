using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Application.Contacts.Queries;
using InvelopContactManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvelopContactManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("GetById")]
        public async Task<BaseResponse<ContactResponseDto>> GetById(int id)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery { Id = id });
            return contact;
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponse<IEnumerable<ContactResponseDto>>> GetAll()
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery { });
            return contacts;
        }

        [HttpPost("CreateContact")]
        public async Task<BaseResponse<ContactEditResponseDto>> CreateContact([FromBody] CreateContactCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("UpdateContact")]
        public async Task<BaseResponse<ContactEditResponseDto>> CreateContact([FromBody]  UpdateContactCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}