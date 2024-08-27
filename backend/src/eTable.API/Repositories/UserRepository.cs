using eTable.API.Data;
using eTable.API.Models.Entities;
using eTable.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eTable.API.Repositories
{
    public class UserRepository(AppDbContext db) : Repository<User>(db), IUserRepository
    {
        public async Task<bool> ExistsUserWithEmail(string email) => await _db.Users.AnyAsync(x => x.Email.Equals(email));
    }
}
