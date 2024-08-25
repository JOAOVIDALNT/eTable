using eTable.API.Data;
using eTable.API.Models.Entities;
using eTable.API.Repositories.Interfaces;

namespace eTable.API.Repositories
{
    public class BookRepository(AppDbContext db) : Repository<Book>(db), IBookRepository
    {
    }
}
