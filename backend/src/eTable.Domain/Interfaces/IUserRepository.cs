using eTable.Domain.Models.Entities;

namespace eTable.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsUserWithEmail(string email);
    }
}
