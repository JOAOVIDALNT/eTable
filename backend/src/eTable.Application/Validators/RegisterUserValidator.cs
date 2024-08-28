using eTable.Communication.Requests;
using FluentValidation;
using eTable.Exception.Resources;

namespace eTable.Infrastructure.Data.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequestDTO>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessageException.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessageException.EMAIL_EMPTY);
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessageException.PASSWORD_LENGTH);
            When(user => !string.IsNullOrEmpty(user.Email), () =>
            {
                RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessageException.EMAIL_INVALID);
            });
        }
    }
}
