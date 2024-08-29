using CommonTestUtilities.Requests;
using eTable.Exception.Resources;
using eTable.Infrastructure.Data.Validators;
using FluentAssertions;

namespace Validators.Test.User
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            // ARRANGE
            var validator = new RegisterUserValidator();
            var request = RegisterUserRequestBuilder.Build();

            // ACT
            var result = validator.Validate(request);

            // ASSERT
            result.IsValid.Should().BeTrue();
        }


        [Fact]
        public void Error_Email_Should_Be_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RegisterUserRequestBuilder.Build();
            request.Email = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.EMAIL_EMPTY));
        }

        [Fact]
        public void Error_Email_Should_Be_Invalid()
        {
            var validator = new RegisterUserValidator();

            var request = RegisterUserRequestBuilder.Build();
            request.Email = "email.com";

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.EMAIL_INVALID));
        }

        [Fact]
        public void Error_Name_Should_Be_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RegisterUserRequestBuilder.Build();
            request.Name = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.NAME_EMPTY));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void Error_Password_Should_Be_Invalid(int passwordLength)
        {
            var validator = new RegisterUserValidator();

            var request = RegisterUserRequestBuilder.Build(passwordLength);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PASSWORD_LENGTH));
        }
    }
}
