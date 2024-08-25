using eTable.API.Data;
using eTable.API.Models.Entities;
using eTable.API.Repositories.Interfaces;

namespace eTable.API.Repositories
{
    public class UserRepository(AppDbContext db) : Repository<User>(db), IUserRepository
    {
    }
}
