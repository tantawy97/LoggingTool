using AutoMapper;
using LoggingTool.Dtos;
using LoggingTool.Model;

namespace LoggingTool.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginDetails,Login>();

        }
    }
}
