using PhoneDirectory.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Domain.Repositories
{
    public interface IPhoneBookRepository
    {
        Task<IEnumerable<PhoneBook>> ListAsync();
        Task AddAsync(PhoneBook category);
        Task<PhoneBook> FindByIdAsync(int id);
        void Update(PhoneBook category);
        void Remove(PhoneBook category);
    }
}
