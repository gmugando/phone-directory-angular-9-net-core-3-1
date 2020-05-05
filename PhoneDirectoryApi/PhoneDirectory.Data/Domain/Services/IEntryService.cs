using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Models.Queries;
using PhoneDirectory.Data.Domain.Services.Comms;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Domain.Services
{
    public interface IEntryService
    {
        Task<QueryResult<Entry>> ListAsync(EntriesQuery query);
        Task<EntryResponse> SaveAsync(Entry entry);
        Task<EntryResponse> UpdateAsync(int id, Entry entry);
        Task<EntryResponse> DeleteAsync(int id);
    }
}
