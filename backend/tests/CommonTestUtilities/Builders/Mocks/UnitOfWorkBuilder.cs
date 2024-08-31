using eTable.Domain.Interfaces;
using Moq;

namespace CommonTestUtilities.Builders.Mocks
{
    public class UnitOfWorkBuilder
    {
        public static IUnitOfWork Build()
        {
            var mock = new Mock<IUnitOfWork>();

            return mock.Object;
        }
    }
}
