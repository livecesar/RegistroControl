using System;
using System.Threading.Tasks;

namespace RegistroControl.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }

        void Savechanges();

        Task SavechangesAsync();
    }
}
