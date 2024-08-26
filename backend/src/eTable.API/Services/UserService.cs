using AutoMapper;
using eTable.API.Models.Requests;
using eTable.API.Models.Responses;
using eTable.API.Repositories.Interfaces;
using eTable.API.Services.Interfaces;

namespace eTable.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork uow, IMapper mapper)
        {
            _userRepository = userRepository;
            _uow = uow;
            _mapper = mapper;
        }
        public Task<RegisterUserResponseDTO> RegisterUser(RegisterUserRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
