namespace Sample.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        //IEmployeeRepository Employees { get; }
        int CommitChanges();
    }
}
