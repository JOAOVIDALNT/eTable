using eTable.Domain.Interfaces;
using eTable.Domain.Models.Entities;

namespace eTable.Infrastructure.Data.Repositories
{
    public class GenreRepository(AppDbContext db) : Repository<Genre>(db), IGenreRepository
    {
    }
}
