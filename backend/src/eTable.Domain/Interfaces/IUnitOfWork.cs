namespace eTable.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
