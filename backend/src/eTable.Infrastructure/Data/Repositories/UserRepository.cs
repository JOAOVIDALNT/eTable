using eTable.Infrastructure.Data;
using eTable.Domain.Models.Entities;
using eTable.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eTable.Infrastructure.Data.Repositories
{
    public class UserRepository(AppDbContext db) : Repository<User>(db), IUserRepository
    {
        public async Task<bool> ExistsUserWithEmail(string email) => await _db.Users.AnyAsync(x => x.Email.Equals(email));
    }
}
