using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Application.Contacts.Queries;
using InvelopContactManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvelopContactManager.API.Controllers
{
    /// <summary>
    /// Controller that manages all Contacts operations
    /// </summary>
    /// <param name="mediator"></param>
    [ApiController]
    [Route("[controller]")]
    public class ContactsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        /// <summary>
        /// Used to get contact by specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<BaseResponse<ContactResponseDto>> GetById(int id)
        {
            var contact = await _mediator.Send(new GetContactByIdQuery { Id = id });
            return contact;
        }

        /// <summary>
        /// Used to get all contacts in the database without a search criteria
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<BaseResponse<IEnumerable<ContactResponseDto>>> GetAll()
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery { });
            return contacts;
        }


        /// <summary>
        /// Used to create new contacts in the database with the provided request data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateContact")]
        public async Task<BaseResponse<ContactEditResponseDto>> CreateContact([FromBody] CreateContactCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// Used to update existing contacts data with the provided input
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UpdateContact")]
        public async Task<BaseResponse<ContactEditResponseDto>> UpdateContactContact([FromBody] UpdateContactCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// Used to delete existing contacts data with the provided id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteContact/{id}")]
        public async Task<BaseResponse> DeleteContact([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteContactCommand { Id = id });
            return response;
        }
    }
}