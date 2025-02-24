using AutoMapper;
using InvelopContactManager.Application.Contacts.Queries;
using InvelopContactManager.Common.Helpers;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InvelopContactManager.Application.Contacts.Handlers
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, BaseResponse<IEnumerable<ContactResponseDto>>>
    {
        private readonly IMapper _mapper;
        private readonly InvelopDbContext _dbContext;

        public GetAllContactsQueryHandler(IMapper mapper, InvelopDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<IEnumerable<ContactResponseDto>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _dbContext.Contacts.ToListAsync();

            var result =  _mapper.Map<IEnumerable<ContactResponseDto>>(contacts);

            return ResponseHelper.Success(result);
        }
    }
}