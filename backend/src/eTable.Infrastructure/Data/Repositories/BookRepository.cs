using eTable.Domain.Interfaces;
using eTable.Domain.Models.Entities;

namespace eTable.Infrastructure.Data.Repositories
{
    public class BookRepository(AppDbContext db) : Repository<Book>(db), IBookRepository
    {
    }
}
