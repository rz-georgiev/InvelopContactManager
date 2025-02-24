using AutoMapper;
using InvelopContactManager.Application.Contacts.Queries;
using InvelopContactManager.Common;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, BaseResponse<ContactResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly InvelopDbContext _dbContext;
        
        public GetContactByIdQueryHandler(IMapper mapper, InvelopDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<ContactResponseDto>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _dbContext.Contacts.SingleOrDefaultAsync(x => x.Id == request.Id);

            var result = _mapper.Map<ContactResponseDto>(contact);

            return ResponseHelper.Success(result);
        }
    }
}