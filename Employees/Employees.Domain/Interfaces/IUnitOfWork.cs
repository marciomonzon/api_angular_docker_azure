namespace Employees.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        Task<int> CommmitAsync();
        int Commit();
        void RollBack();
    }
}
