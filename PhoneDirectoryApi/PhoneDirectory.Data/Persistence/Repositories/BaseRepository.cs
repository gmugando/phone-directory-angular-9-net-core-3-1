using PhoneDirectory.Data.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Data.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PhoneBookContext _context;

        public BaseRepository(PhoneBookContext context)
        {
            _context = context;
        }
    }
}
