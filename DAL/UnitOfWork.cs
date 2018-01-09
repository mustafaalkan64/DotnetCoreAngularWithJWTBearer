using System.Threading.Tasks;
using AspnetCoreProject.Core;

namespace AspnetCoreProject.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ExampleDbContext context;
        public UnitOfWork(ExampleDbContext context)
        {
            this.context = context;

        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}