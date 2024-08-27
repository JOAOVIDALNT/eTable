using eTable.API.Models.Entities;

namespace eTable.API.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsUserWithEmail(string email);
    }
}
