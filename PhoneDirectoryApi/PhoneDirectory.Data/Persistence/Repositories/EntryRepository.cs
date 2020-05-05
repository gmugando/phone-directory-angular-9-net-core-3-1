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

			// Here I count all items present in the database for the given query, to return as part of the pagination data.
			int totalItems = await queryable.CountAsync();

			// Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
			// and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
			List<Entry> entries = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
													.Take(query.ItemsPerPage)
													.ToListAsync();

			// Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
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
