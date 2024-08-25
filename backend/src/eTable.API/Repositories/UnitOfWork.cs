using eTable.API.Data;
using eTable.API.Repositories.Interfaces;

namespace eTable.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db) => _db = db;

        public async Task Commit() => await _db.SaveChangesAsync();
    }
}
