using CommonTestUtilities.Builders.Configs;
using CommonTestUtilities.Builders.Mocks;
using CommonTestUtilities.Builders.Requests;
using eTable.Application.Services;
using eTable.Application.Services.Interfaces;
using eTable.Exception.Exceptions;
using eTable.Exception.Resources;
using FluentAssertions;

namespace Services.Test.User
{
    public class UserServiceTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RegisterUserRequestBuilder.Build();

            var service = CreateService();

            var result = await service.RegisterUser(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
        }

        [Fact]
        public async Task Error_Email_Already_Registered()
        {
            var request = RegisterUserRequestBuilder.Build();

            var service = CreateService(request.Email);

            Func<Task> act = async () => await service.RegisterUser(request);

            (await act.Should().ThrowAsync<ErrorOnValidationException>())
                .Where(e => e.ErrorMessages.Count == 1 && e.ErrorMessages.Contains(ResourceMessageException.EMAIL_ALREADY_REGISTERED));
        }

        [Fact]
        public async Task Error_Name_Empty()
        {
            var request = RegisterUserRequestBuilder.Build();
            request.Name = string.Empty;

            var service = CreateService();

            Func<Task> act = async () => await service.RegisterUser(request);

            (await act.Should().ThrowAsync<ErrorOnValidationException>())
                .Where(e => e.ErrorMessages.Count == 1 && e.ErrorMessages.Contains(ResourceMessageException.NAME_EMPTY));
        }

        private static UserService CreateService(string? email = null)
        {
            var mapper = MapperBuilder.Build();
            var passwordEncrypter = PasswordEncrypterBuilder.Build();
            var userRepository = new UserRepositoryBuilder();
            var unitOfWork = UnitOfWorkBuilder.Build();

            if (!string.IsNullOrEmpty(email))
            {
                userRepository.ExistsUserWithEmail(email);
            }

            return new UserService(userRepository.Build(), unitOfWork, mapper, passwordEncrypter);
        }
    }
}
