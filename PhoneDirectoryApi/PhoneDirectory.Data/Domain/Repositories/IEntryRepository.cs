using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Models.Queries;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Domain.Repositories
{
    public interface IEntryRepository
    {
        Task<QueryResult<Entry>> ListAsync(EntriesQuery query);
        Task AddAsync(Entry product);
        Task<Entry> FindByIdAsync(int id);
        void Update(Entry product);
        void Remove(Entry product);
    }
}
