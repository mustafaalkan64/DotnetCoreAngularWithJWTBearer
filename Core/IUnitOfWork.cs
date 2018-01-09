using System.Threading.Tasks;

namespace AspnetCoreProject.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}