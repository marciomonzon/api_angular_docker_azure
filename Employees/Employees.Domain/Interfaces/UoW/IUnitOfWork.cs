namespace Employees.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        Task<int> CommmitAsync();
        int Commit();
        void RollBack();
    }
}
