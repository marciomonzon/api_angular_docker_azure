using Employees.Domain.Interfaces;
using Employees.Domain.Interfaces.UoW;

namespace Employees.Infrastructure.Persistence.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IEmployeeRepository EmployeeRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            EmployeeRepository = employeeRepository;
        }

        public async Task<int> CommmitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
