using eTable.Application.Configs;

namespace CommonTestUtilities.Builders.Configs
{
    public class PasswordEncrypterBuilder
    {
        public static PasswordEncrypter Build() => new PasswordEncrypter("abcd1234");
    }
}
