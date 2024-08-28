﻿using AutoMapper;
using eTable.Application.Services.Interfaces;
using eTable.Communication.Requests;
using eTable.Communication.Responses;
using eTable.Domain.Interfaces;
using eTable.Domain.Models.Entities;
using eTable.Exception.Exceptions;
using eTable.Exception.Resources;
using eTable.Infrastructure.Data.Validators;

namespace eTable.Application.Services
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

            var userObj = _mapper.Map<User>(request);

            await _userRepository.CreateAsync(userObj);

            await _uow.Commit();


            return new RegisterUserResponseDTO();
        }

        private async Task Validate(RegisterUserRequestDTO request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var emailExists = await _userRepository.ExistsUserWithEmail(request.Email);

            if (emailExists)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessageException.EMAIL_ALREADY_REGISTERED));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }


        }
    }
}
