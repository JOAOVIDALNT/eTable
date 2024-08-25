namespace eTable.API.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
