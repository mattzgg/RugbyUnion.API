using System;
using System.Threading.Tasks;

namespace RugbyUnion.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
