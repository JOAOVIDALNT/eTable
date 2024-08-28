using AutoMapper;
using eTable.Domain.Models.Entities;
using eTable.Communication.Requests;

namespace eTable.Application.Configs
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            RequestToModel();
        }

        private void RequestToModel()
        {
            CreateMap<RegisterUserRequestDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
