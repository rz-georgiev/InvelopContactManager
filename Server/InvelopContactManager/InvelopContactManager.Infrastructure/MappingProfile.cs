using AutoMapper;
using InvelopContactManager.Domain.Models;

namespace InvelopContactManager.Infrastructure
{
    public class MappingProfile : Profile
    {  
        public MappingProfile()
        {
            CreateMap<Contact, ContactResponseDto>();
        }
    }
}