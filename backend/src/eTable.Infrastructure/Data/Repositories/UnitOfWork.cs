using eTable.Infrastructure.Data;
using eTable.Domain.Interfaces;

namespace eTable.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db) => _db = db;

        public async Task Commit() => await _db.SaveChangesAsync();
    }
}
