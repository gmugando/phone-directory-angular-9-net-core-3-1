using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Models.Queries;
using PhoneDirectory.Data.Domain.Repositories;
using PhoneDirectory.Data.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Data.Persistence.Repositories
{
	public class EntryRepository : BaseRepository, IEntryRepository
	{
		public EntryRepository(PhoneBookContext context) : base(context) { }

		public async Task<QueryResult<Entry>> ListAsync(EntriesQuery query)
		{
			IQueryable<Entry> queryable = _context.Entries
													.Include(p => p.PhoneBook)
													.AsNoTracking();

			// AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
			// tracking makes the code a little faster
			if (query.PhoneBookId.HasValue && query.PhoneBookId > 0)
			{
				queryable = queryable.Where(p => p.PhoneBookId == query.PhoneBookId);
			}

			if (query.EntryName != null)
				queryable = queryable.Where(p => p.Name.Contains(query.EntryName));

			int totalItems = await queryable.CountAsync();

			List<Entry> entries = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
													.Take(query.ItemsPerPage)
													.ToListAsync();

			return new QueryResult<Entry>
			{
				Items = entries,
				TotalItems = totalItems,
			};
		}

		public async Task<Entry> FindByIdAsync(int id)
		{
			return await _context.Entries
								 .Include(p => p.PhoneBook)
								 .FirstOrDefaultAsync(p => p.EntryId == id); // Since Include changes the method's return type, we can't use FindAsync
		}

		public async Task AddAsync(Entry entry)
		{
			await _context.Entries.AddAsync(entry);
		}

		public void Update(Entry entry)
		{
			_context.Entries.Update(entry);
		}

		public void Remove(Entry entry)
		{
			_context.Entries.Remove(entry);
		}
	}
}
