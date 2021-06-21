using System;
using System.Threading.Tasks;
using RegistroControl.Core.Interfaces;
using RegistroControl.Infrastructure.Data;

namespace RegistroControl.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RegistroControlContext _context;
        private readonly IStudentRepository _studentRepository;

        public UnitOfWork(RegistroControlContext contex)
        {
            _context = contex;
        }

        public IStudentRepository StudentRepository => _studentRepository ?? new StudentRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void Savechanges()
        {
            _context.SaveChanges();
        }

        public async Task SavechangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
