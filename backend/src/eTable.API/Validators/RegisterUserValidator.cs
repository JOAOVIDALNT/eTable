using eTable.API.Models.Requests;
using FluentValidation;

namespace eTable.API.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequestDTO>
    {
        public RegisterUserValidator()
        {

        }
    }
}
