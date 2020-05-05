using PhoneDirectory.Data.Domain.Repositories;
using PhoneDirectory.Data.Persistence.Context;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhoneBookContext _context;

        public UnitOfWork(PhoneBookContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
