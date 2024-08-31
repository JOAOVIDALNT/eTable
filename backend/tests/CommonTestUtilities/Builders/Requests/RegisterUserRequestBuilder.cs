using Bogus;
using eTable.Communication.Requests;

namespace CommonTestUtilities.Builders.Requests
{
    public class RegisterUserRequestBuilder
    {
        public static RegisterUserRequestDTO Build(int passwordLength = 10)
        {
            return new Faker<RegisterUserRequestDTO>(locale: "pt_BR")
                .RuleFor(user => user.Name, (f) => f.Person.FirstName)
                .RuleFor(user => user.Email, (f, u) => f.Internet.Email(u.Name))
                .RuleFor(user => user.Password, (f) => f.Internet.Password(passwordLength));
        }
    }
}
