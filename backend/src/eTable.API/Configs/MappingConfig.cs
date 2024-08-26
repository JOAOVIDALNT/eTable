using AutoMapper;
using eTable.API.Models.Entities;
using eTable.API.Models.Requests;

namespace eTable.API.Configs
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
