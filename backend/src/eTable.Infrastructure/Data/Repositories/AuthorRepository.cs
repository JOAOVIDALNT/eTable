using eTable.Domain.Interfaces;
using eTable.Domain.Models.Entities;

namespace eTable.Infrastructure.Data.Repositories
{
    public class AuthorRepository(AppDbContext db) : Repository<Author>(db), IAuthorRepository
    {   
    }
}
