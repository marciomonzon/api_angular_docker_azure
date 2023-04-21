namespace Employees.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        Task<bool> CommitAsync();
        bool Commit();
        void RollBack();
    }
}
