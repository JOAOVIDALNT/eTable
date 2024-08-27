using AutoMapper;
using eTable.API.Exceptions;
using eTable.API.Models.Requests;
using eTable.API.Models.Responses;
using eTable.API.Repositories.Interfaces;
using eTable.API.Services.Interfaces;
using eTable.API.Validators;
using MyCookBook.Exceptions;
using System.Runtime.CompilerServices;

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
        public async Task<RegisterUserResponseDTO> RegisterUser(RegisterUserRequestDTO request)
        {
            await Validate(request);

            return new RegisterUserResponseDTO();
        }

        private async Task Validate(RegisterUserRequestDTO request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var emailExists = await _userRepository.ExistsUserWithEmail(request.Email);

            if (emailExists)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_ALREADY_REGISTERED));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }


        }
    }
}
