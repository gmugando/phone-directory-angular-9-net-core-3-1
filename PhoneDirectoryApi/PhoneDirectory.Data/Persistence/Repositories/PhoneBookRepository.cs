using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Repositories;
using PhoneDirectory.Data.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Persistence.Repositories
{
    public class PhoneBookRepository : BaseRepository, IPhoneBookRepository
    {
        public PhoneBookRepository(PhoneBookContext context) : base(context) { }

        public async Task<IEnumerable<PhoneBook>> ListAsync()
        {
            return await _context.PhoneBook
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(PhoneBook phonebook)
        {
            await _context.PhoneBook.AddAsync(phonebook);
        }

        public async Task<PhoneBook> FindByIdAsync(int id)
        {
            return await _context.PhoneBook.FindAsync(id);
        }

        public void Update(PhoneBook phonebook)
        {
            _context.PhoneBook.Update(phonebook);
        }

        public void Remove(PhoneBook phonebook)
        {
            _context.PhoneBook.Remove(phonebook);
        }
    }
}
