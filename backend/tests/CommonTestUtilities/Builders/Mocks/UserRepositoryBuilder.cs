using eTable.Domain.Interfaces;
using Moq;

namespace CommonTestUtilities.Builders.Mocks
{
    public class UserRepositoryBuilder
    {
        private readonly Mock<IUserRepository> _userRepository;

        public UserRepositoryBuilder() => _userRepository = new Mock<IUserRepository>();

        public IUserRepository Build() => _userRepository.Object;

        public void ExistsUserWithEmail(string email)
        {
            _userRepository.Setup(repo => repo.ExistsUserWithEmail(email)).ReturnsAsync(true);
        }
    }
}
