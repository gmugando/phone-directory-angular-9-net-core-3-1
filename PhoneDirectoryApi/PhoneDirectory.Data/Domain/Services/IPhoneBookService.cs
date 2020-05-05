using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Services.Comms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Domain.Services
{
    public interface IPhoneBookService
    {
        Task<IEnumerable<PhoneBook>> ListAsync();
        Task<PhoneBookResponse> SaveAsync(PhoneBook phonebook);
        Task<PhoneBookResponse> UpdateAsync(int id, PhoneBook phonebook);
        Task<PhoneBookResponse> DeleteAsync(int id);
    }
}
